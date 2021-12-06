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
    public partial class FormDeterminant : Form
    {
        public FormDeterminant()
        {
            InitializeComponent();
        }

        double[,] matrixA = new double[3, 3];
        private void FormDeterminant_Load(object sender, EventArgs e)
        {
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

        private void checkTextBoxIsEmpty()
        {
            if (textboxSayi.Text == "")
            {
                textboxSayi.Text = "0";
                MessageBox.Show("Lütfen indexlere atama yapmadan önce 'Sayı' kutusuna bir sayı değeri girin.");
                hesaplamaIslemi();
            }
        }

        private void hesaplamaIslemi()
        {
            //Burada 3x3 olduğu iççin sarrus yönteminden faydalandım. Her bir işlemi parçalara boldum en sonda eşitledim
            double toplanacak1 = matrixA[0,0] * matrixA[1,1] * matrixA[2,2];
            double toplanacak2 = matrixA[1,0] * matrixA[2,1] * matrixA[0,2];
            double toplanacak3 = matrixA[2,0] * matrixA[0,1] * matrixA[1,2];
            double cikarilacak1 = matrixA[0,2] * matrixA[1,1] * matrixA[2,0];
            double cikarilacak2 = matrixA[1,2] * matrixA[2,1] * matrixA[0,0];
            double cikarilacak3 = matrixA[2,2] * matrixA[0,1] * matrixA[1,0];
            btnSayi.Text = Convert.ToString((toplanacak1+toplanacak2+toplanacak3)-(cikarilacak1+cikarilacak2+cikarilacak3));
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
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            hesaplamaIslemi();
        }
    }
}
