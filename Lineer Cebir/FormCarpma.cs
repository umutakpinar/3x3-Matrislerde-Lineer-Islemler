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
    public partial class FormCarpma : Form
    {
        public FormCarpma()
        {
            InitializeComponent();
        }

        double[,] matrixA = new double[3, 3]; //3x3 boyutlu bir A matrisi tanımladım. Değerleri buna alacağım
        double[,] matrixB = new double[3, 3]; //bunlara UI'daki baslangic degerlerini atıyorum elbette döngüler emtot içinde kullanılmak zorunda bu nedenle laod eventinde yazdım
        double[,] matrixC = new double[3, 3]; //Bu da çarpım matrixi
        private void FormCarpma_Load(object sender, EventArgs e)
        {
            //şimdi her bir matrisime başta gözüken değerlerini atadım.
            for (int i = 0; i < 3; i++) 
            {
                for(int j=0; j<3; j++)
                {
                    matrixA[i, j] = 1;
                    matrixB[i, j] = 1;
                    matrixC[i, j] = 3;
                }
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

        private void hesaplamaIslemi()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    matrixC[j, k] = (matrixA[j, 0] * matrixB[0, k]) + (matrixA[j, 1] * matrixB[1, k]) + (matrixA[j, 2] * matrixB[2, k]);
                }
            }
            btnC11.Text = Convert.ToString(matrixC[0, 0]);
            btnC12.Text = Convert.ToString(matrixC[0, 1]);
            btnC13.Text = Convert.ToString(matrixC[0, 2]);
            btnC21.Text = Convert.ToString(matrixC[1, 0]);
            btnC22.Text = Convert.ToString(matrixC[1, 1]);
            btnC23.Text = Convert.ToString(matrixC[1, 2]);
            btnC31.Text = Convert.ToString(matrixC[2, 0]);
            btnC32.Text = Convert.ToString(matrixC[2, 1]);
            btnC33.Text = Convert.ToString(matrixC[2, 2]);
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textboxSayi.Clear();
        }

        private void btnA11_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA11.Text = textboxSayi.Text;
            matrixA[0, 0] = Convert.ToDouble(textboxSayi.Text); //Burada her bir  butona tıkladndığında matreislerimdeki değerleri texboxtaki değerle değiştiritorum
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA12.Text = textboxSayi.Text;
            matrixA[0, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA13.Text = textboxSayi.Text;
            matrixA[0, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA21.Text = textboxSayi.Text;
            matrixA[1, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA22.Text = textboxSayi.Text;
            matrixA[1, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA23.Text = textboxSayi.Text;
            matrixA[1, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA31.Text = textboxSayi.Text;
            matrixA[2, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA32.Text = textboxSayi.Text;
            matrixA[2, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnA33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA33.Text = textboxSayi.Text;
            matrixA[2, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB11_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB11.Text = textboxSayi.Text;
            matrixB[0, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB12.Text = textboxSayi.Text;
            matrixB[0, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB13.Text = textboxSayi.Text;
            matrixB[0, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB21.Text = textboxSayi.Text;
            matrixB[1, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB22.Text = textboxSayi.Text;
            matrixB[1, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB23.Text = textboxSayi.Text;
            matrixB[1, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB31.Text = textboxSayi.Text;
            matrixB[2, 0] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB32.Text = textboxSayi.Text;
            matrixB[2, 1] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnB33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB33.Text = textboxSayi.Text;
            matrixB[2, 2] = Convert.ToDouble(textboxSayi.Text);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            hesaplamaIslemi();
        }
    }
}
