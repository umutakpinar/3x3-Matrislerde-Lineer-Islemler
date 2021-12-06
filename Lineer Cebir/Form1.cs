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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Kırklareli Universitesi Yazılım Mühendisliği\n" +
                "2. Sınıf I. Dönem Lineer Cebir Dersi\n" +
                "Dönem Ödevi\n" +
                "Recep Umut AKPINAR\n" +
                "1190505805");
        }

        private void createFormAndHideThisForm(Form get_form)
        {
            Form form = get_form;
            form.ShowDialog();
        }

        private void btnToplama_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A ve B matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormToplama());
        }

        private void btnCikarma_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A ve B matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormCikarma());
        }

        private void btnCarpma_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A ve B matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormCarpma());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A sayısının ve B matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormSayiCarpma());
        }

        private void btnDeterminant_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormDeterminant());
        }

        private void btnInvolutif_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormInvolutif());
        }

        private void btnTers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A matrisininin değerlerini değiştirmek için değer kutusuna bir sayı değeri girin. Daha sonra matriste değiştirmek istediğiniz değerin üzerine tıklayın.");
            createFormAndHideThisForm(new FormTers());
        }


    }
}
