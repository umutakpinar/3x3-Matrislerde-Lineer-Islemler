using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lineer_Cebir
{
    public partial class FormTers : Form
    {
        public FormTers()
        {
            InitializeComponent();
        }

        double[,] matrixA = new double[3, 3];

        private void FormTers_Load(object sender, EventArgs e)
        {
            lblBildirim.Visible = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixA[i, j] = 0; //önce her birine sıfır verdim sonra 0,0 - 1,1 ve 2,2'ye bir vereceğim başlangıç değerlerini atmak için
                }
            }

            int[] numbers = { 0, 1, 2 };
            foreach (int i in numbers)
            {
                matrixA[i, i] = 1;
            }

        }

        
        private void clearBtn()
        {
            Button[] buttons = { btnC11, btnC12, btnC13, btnC21, btnC22, btnC23, btnC31, btnC32, btnC33 };
            foreach(Button btn in buttons)
            {
                btn.Text = "-";
            }
        }


        private void textboxSayi_TextChanged(object sender, EventArgs e)
        {
            lblBildirim.Visible = false;
            //TextBoxSayi içerisinde birden fazla virgül varsa hata vermesi gerekiyor iki tane virgülü olan ifadeyi double değere çeviremem mantıken.
            // içerisinde kaç tane , olduğunu saydırmam lazım.
            int virgulAdedi = 0;
            virgulAdedi = textboxSayi.Text.Count(x => x == ','); //Bu bildiğin matematikteki x öyle ki x eşittir virgül ise demek çok mantıklı. Kaynak: https://keremozer.com/csharp/csharp-da-girilen-bir-cumlede-aranilan-ifade-kac-defa-gecmektedir.html
            if (virgulAdedi > 1)
            {
                MessageBox.Show("Ondalıklı bir değerde birden fazla virgül olamaz!");
                textboxSayi.Text = "0";
            }
            //Ayrıca textbox içerisinde maksimum bir adet - işareti olmalı ve bu da ancak textbox ifadesinin başında olmalı orasında 5-3 yazarsa bu iadeyi de double yapamam
            int eksiAdedi = 0;
            eksiAdedi = textboxSayi.Text.Count(y => y == '-');
            if (eksiAdedi > 1)
            {
                MessageBox.Show("Ondalıklı bir değerde birden fazla eksi işareti olamaz!");
                textboxSayi.Text = "0";
            }
            else if (eksiAdedi == 1 && !(textboxSayi.Text.StartsWith("-")))
            {
                MessageBox.Show("Ondalıklı bir değerde eksi işareti yalnızca başta olabilir!");
                textboxSayi.Text = "0";
            }
        }

        private void textboxSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == ',' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Lütfen yalnızca '0,1,2,3....9' , ',' ve '-' tuşlarınının dışında giriş yapmayın. Ondalıklı bir değer girmek isterseniz virgül yerine nokta kullanın");
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textboxSayi.Clear();
        }

        private void hesaplamaIslemi()
        {
            double determinant = 0;
            //Burada 3x3 olduğu iççin sarrus yönteminden faydalandım. Her bir işlemi parçalara boldum en sonda değişkene eşitledim eşitledim
            double toplanacak1 = matrixA[0, 0] * matrixA[1, 1] * matrixA[2, 2];
            double toplanacak2 = matrixA[1, 0] * matrixA[2, 1] * matrixA[0, 2];
            double toplanacak3 = matrixA[2, 0] * matrixA[0, 1] * matrixA[1, 2];
            double cikarilacak1 = matrixA[0, 2] * matrixA[1, 1] * matrixA[2, 0];
            double cikarilacak2 = matrixA[1, 2] * matrixA[2, 1] * matrixA[0, 0];
            double cikarilacak3 = matrixA[2, 2] * matrixA[0, 1] * matrixA[1, 0];
            
            determinant = (toplanacak1 + toplanacak2 + toplanacak3) - (cikarilacak1 + cikarilacak2 + cikarilacak3);
            
            if(determinant != 0) //determinantımı kontrol ettim 0 değilse işleme devam edebilirim
            {
                double[,] transpozA = new double[3, 3]; //Transpozunu alabilmek için bir matris oluşturdum. BUrada hepsinin içi 0 oldu
                
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        transpozA[i, j] = matrixA[j, i]; //transpozu kaydettim (Bunlar aslında hafizada gereksiz yer tutuyor direkt olarak matrixA üzerinde kednine eşitleyrek de işlem yapabilirdik kodun daha açıklayıcı olması adına bunu yapıyorum)
                    }
                }
                    
                
                double[,] kofaktorA = new double[3, 3];

                kofaktorA[0, 0] = (transpozA[1,1] * transpozA[2,2]) - (transpozA[1,2] * transpozA[2,1]);
                kofaktorA[0, 1] = (transpozA[1,0] * transpozA[2,2]) - (transpozA[1,2] * transpozA[2,0]);
                kofaktorA[0, 2] = (transpozA[1,0] * transpozA[2,1]) - (transpozA[1,1] * transpozA[2,0]);
                kofaktorA[1, 0] = (transpozA[0,1] * transpozA[2,2]) - (transpozA[0,2] * transpozA[2,1]);
                kofaktorA[1, 1] = (transpozA[0,0] * transpozA[2,2]) - (transpozA[0,2] * transpozA[2,0]);
                kofaktorA[1, 2] = (transpozA[0,0] * transpozA[2,1]) - (transpozA[0,1] * transpozA[2,0]);
                kofaktorA[2, 0] = (transpozA[0,1] * transpozA[1,2]) - (transpozA[0,2] * transpozA[1,1]);
                kofaktorA[2, 1] = (transpozA[0,0] * transpozA[1,2]) - (transpozA[0,2] * transpozA[1,0]);
                kofaktorA[2, 2] = (transpozA[0,0] * transpozA[1,1]) - (transpozA[0,1] * transpozA[2,0]);

                double[,] ekMatrixA = new double[3, 3];

                for(int i=0; i<3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if(i==0 && j==1)
                        {
                            ekMatrixA[i, j] = -kofaktorA[i, j];
                        }
                        else if (i == 1 && j == 0)
                        {
                            ekMatrixA[i, j] = -kofaktorA[i, j];
                        }
                        else if (i == 1 && j == 2)
                        {
                            ekMatrixA[i, j] = -kofaktorA[i, j];
                        }
                        else if (i == 2 && j == 1)
                        {
                            ekMatrixA[i, j] = -kofaktorA[i, j];
                        }
                        else
                        {
                            ekMatrixA[i, j] = kofaktorA[i, j];
                        }

                         //ekmatrisin temelini aldım ve alırken de eksi ile çarpmam gerekenelri çarptım.
                    }
                }

                double[,] tersMatrixA = new double[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tersMatrixA[i, j] = (1 / determinant) * ekMatrixA[i, j];  //burada da ters matrisin değerlerini hesapladım
                    }
                }

                btnC11.Text = Convert.ToString(tersMatrixA[0, 0]);
                btnC12.Text = Convert.ToString(tersMatrixA[0, 1]);
                btnC13.Text = Convert.ToString(tersMatrixA[0, 2]);
                btnC21.Text = Convert.ToString(tersMatrixA[1, 0]);
                btnC22.Text = Convert.ToString(tersMatrixA[1, 1]);
                btnC23.Text = Convert.ToString(tersMatrixA[1, 2]);
                btnC31.Text = Convert.ToString(tersMatrixA[2, 0]);
                btnC32.Text = Convert.ToString(tersMatrixA[2, 1]);
                btnC33.Text = Convert.ToString(tersMatrixA[2, 2]);

            }
            else
            {
                MessageBox.Show("Girdiğiniz A matrisinin determinantı sıfıra eşittir. Determinant değeri sıfıra eşit olan kare matrislerin tersi yoktur. det(A) = 0");
                lblBildirim.Visible = true;
            }
        }

        private void checkTextBoxIsEmpty()
        {
            lblBildirim.Visible = false;
            if (textboxSayi.Text == "")
            {
                textboxSayi.Text = "0";
                MessageBox.Show("Lütfen indexlere atama yapmadan önce 'Sayı' kutusuna bir sayı değeri girin.");
                hesaplamaIslemi();
            }
        }

        private void btnA11_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA11.Text = textboxSayi.Text;
            matrixA[0, 0] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA12.Text = textboxSayi.Text;
            matrixA[0, 1] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA13.Text = textboxSayi.Text;
            matrixA[0, 2] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA21.Text = textboxSayi.Text;
            matrixA[1, 0] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA22.Text = textboxSayi.Text;
            matrixA[1, 1] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA23.Text = textboxSayi.Text;
            matrixA[1, 2] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA31.Text = textboxSayi.Text;
            matrixA[2, 0] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA32.Text = textboxSayi.Text;
            matrixA[2, 1] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnA33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA33.Text = textboxSayi.Text;
            matrixA[2, 2] = Convert.ToDouble(textboxSayi.Text);
            clearBtn();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            hesaplamaIslemi();
        }
    }
}
