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
    public partial class FormToplama : Form
    {
        public FormToplama()
        {
            InitializeComponent();
        }

        

        private void textboxSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || e.KeyChar == '-'|| e.KeyChar == ',' || e.KeyChar == 8)
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
            else if(eksiAdedi == 1 && !(textboxSayi.Text.StartsWith("-")))
            {
                MessageBox.Show("Ondalıklı bir değerde eksi işareti yalnızca başta olabilir!");
                textboxSayi.Text = "0";
            }
        }

        private void hesaplamaIslemi()
        {
            btnC11.Text = Convert.ToString(Convert.ToDouble(btnA11.Text) + Convert.ToDouble(btnB11.Text));
            btnC12.Text = Convert.ToString(Convert.ToDouble(btnA12.Text) + Convert.ToDouble(btnB12.Text));
            btnC13.Text = Convert.ToString(Convert.ToDouble(btnA13.Text) + Convert.ToDouble(btnB13.Text));
            btnC21.Text = Convert.ToString(Convert.ToDouble(btnA21.Text) + Convert.ToDouble(btnB21.Text));
            btnC22.Text = Convert.ToString(Convert.ToDouble(btnA22.Text) + Convert.ToDouble(btnB22.Text));
            btnC23.Text = Convert.ToString(Convert.ToDouble(btnA23.Text) + Convert.ToDouble(btnB23.Text));
            btnC31.Text = Convert.ToString(Convert.ToDouble(btnA31.Text) + Convert.ToDouble(btnB31.Text));
            btnC32.Text = Convert.ToString(Convert.ToDouble(btnA32.Text) + Convert.ToDouble(btnB32.Text));
            btnC33.Text = Convert.ToString(Convert.ToDouble(btnA33.Text) + Convert.ToDouble(btnB33.Text));
        }

        private void checkTextBoxIsEmpty()
        {
            if(textboxSayi.Text=="")
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
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA12.Text = textboxSayi.Text;
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA13.Text = textboxSayi.Text;
        }

        private void btnA21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA21.Text = textboxSayi.Text;
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA22.Text = textboxSayi.Text;
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA23.Text = textboxSayi.Text;
        }

        private void btnA31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA31.Text = textboxSayi.Text;
        }

        private void btnA32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA32.Text = textboxSayi.Text;
        }

        private void btnA33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnA33.Text = textboxSayi.Text;
        }

        private void btnB11_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB11.Text = textboxSayi.Text;
        }

        private void btnB12_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB12.Text = textboxSayi.Text;
        }

        private void btnB13_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB13.Text = textboxSayi.Text;
        }

        private void btnB21_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB21.Text = textboxSayi.Text;
        }

        private void btnB22_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB22.Text = textboxSayi.Text;
        }

        private void btnB23_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB23.Text = textboxSayi.Text;
        }

        private void btnB31_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB31.Text = textboxSayi.Text;
        }

        private void btnB32_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB32.Text = textboxSayi.Text;
        }

        private void btnB33_Click(object sender, EventArgs e)
        {
            checkTextBoxIsEmpty();
            btnB33.Text = textboxSayi.Text;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            hesaplamaIslemi();
        }

    }
}
