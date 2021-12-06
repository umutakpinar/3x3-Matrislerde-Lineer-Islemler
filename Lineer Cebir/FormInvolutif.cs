using System;
using System.Collections;
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
    public partial class FormInvolutif : Form
    {
        public FormInvolutif()
        {
            InitializeComponent();
        }

        double[,] matrixA = new double[3, 3];
        double[,] matrixC = new double[3, 3];

        private void FormInvolutif_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //başlangıçtaki değerleri A matrisine girdim.
                    if ((i == 0 && j == 0) || (i == 1 && j == 1) || (i == 2 && j == 2))  
                    {
                        matrixA[i, j] = 1;
                    }
                    else
                    {
                        matrixA[i, j] = 0;
                    }
                }
            }
        }

        private void textboxSayi_TextChanged(object sender, EventArgs e)
        {
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
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    matrixC[j, k] = (matrixA[j, 0] * matrixA[0, k]) + (matrixA[j, 1] * matrixA[1, k]) + (matrixA[j, 2] * matrixA[2, k]);
                }
            }

            bool kosegenler1mi = true; //başlangıçta birmi matris verdiğim için true verdim
            bool indexler0mi = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i==j)
                    {
                        if (matrixC[i, j] == 1) 
                        {
                            kosegenler1mi = true;
                        }
                        else
                        {
                            kosegenler1mi = false;
                            break;
                        }
                    }
                    else
                    {
                        if (matrixC[i, j] == 0) 
                        {
                            indexler0mi = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (kosegenler1mi == false || indexler0mi == false)
                {
                    break;
                }
            }

            if(kosegenler1mi == true && indexler0mi==true)
            {
                btnSayi.Text = "True";
                btnSayi.BackColor = Color.Green;
            }
            else
            {
                btnSayi.Text = "False";
                btnSayi.BackColor = Color.Red;
            }

        }

        private void resetBtnSayi()
        {
            btnSayi.Text = "-";
            btnSayi.BackColor = Color.White;
        }

        private void checkTextBoxIsEmpty()
        {
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
            resetBtnSayi();
            btnA11.Text = textboxSayi.Text;
            matrixA[0, 0] = Convert.ToDouble(textboxSayi.Text); //Burada her bir  butona tıkladndığında matreislerimdeki değerleri texboxtaki değerle değiştiritorum
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA12.Text = textboxSayi.Text;
            matrixA[0, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA13.Text = textboxSayi.Text;
            matrixA[0, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA21.Text = textboxSayi.Text;
            matrixA[1, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA22.Text = textboxSayi.Text;
            matrixA[1, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA23.Text = textboxSayi.Text;
            matrixA[1, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA31.Text = textboxSayi.Text;
            matrixA[2, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA32.Text = textboxSayi.Text;
            matrixA[2, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            resetBtnSayi();
            btnA33.Text = textboxSayi.Text;
            matrixA[2, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            hesaplamaIslemi();
        }
    }
}
