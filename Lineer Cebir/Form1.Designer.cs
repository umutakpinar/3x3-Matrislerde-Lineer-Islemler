
namespace Lineer_Cebir
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnToplama = new System.Windows.Forms.Button();
            this.btnCikarma = new System.Windows.Forms.Button();
            this.btnCarpma = new System.Windows.Forms.Button();
            this.btnDeterminant = new System.Windows.Forms.Button();
            this.btnInvolutif = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToplama
            // 
            this.btnToplama.Location = new System.Drawing.Point(63, 53);
            this.btnToplama.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnToplama.Name = "btnToplama";
            this.btnToplama.Size = new System.Drawing.Size(549, 94);
            this.btnToplama.TabIndex = 0;
            this.btnToplama.Text = "Toplama";
            this.btnToplama.UseVisualStyleBackColor = true;
            this.btnToplama.Click += new System.EventHandler(this.btnToplama_Click);
            // 
            // btnCikarma
            // 
            this.btnCikarma.Location = new System.Drawing.Point(63, 159);
            this.btnCikarma.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCikarma.Name = "btnCikarma";
            this.btnCikarma.Size = new System.Drawing.Size(549, 92);
            this.btnCikarma.TabIndex = 1;
            this.btnCikarma.Text = "Çıkarma";
            this.btnCikarma.UseVisualStyleBackColor = true;
            this.btnCikarma.Click += new System.EventHandler(this.btnCikarma_Click);
            // 
            // btnCarpma
            // 
            this.btnCarpma.Location = new System.Drawing.Point(63, 263);
            this.btnCarpma.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCarpma.Name = "btnCarpma";
            this.btnCarpma.Size = new System.Drawing.Size(549, 96);
            this.btnCarpma.TabIndex = 2;
            this.btnCarpma.Text = "Çarpma";
            this.btnCarpma.UseVisualStyleBackColor = true;
            this.btnCarpma.Click += new System.EventHandler(this.btnCarpma_Click);
            // 
            // btnDeterminant
            // 
            this.btnDeterminant.Location = new System.Drawing.Point(63, 479);
            this.btnDeterminant.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDeterminant.Name = "btnDeterminant";
            this.btnDeterminant.Size = new System.Drawing.Size(549, 90);
            this.btnDeterminant.TabIndex = 3;
            this.btnDeterminant.Text = "Determinant Bulma";
            this.btnDeterminant.UseVisualStyleBackColor = true;
            this.btnDeterminant.Click += new System.EventHandler(this.btnDeterminant_Click);
            // 
            // btnInvolutif
            // 
            this.btnInvolutif.Location = new System.Drawing.Point(63, 683);
            this.btnInvolutif.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnInvolutif.Name = "btnInvolutif";
            this.btnInvolutif.Size = new System.Drawing.Size(549, 89);
            this.btnInvolutif.TabIndex = 4;
            this.btnInvolutif.Text = "Involutif mi?";
            this.btnInvolutif.UseVisualStyleBackColor = true;
            this.btnInvolutif.Click += new System.EventHandler(this.btnInvolutif_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lütfen yapmak istediğiniz işlemi seçiniz.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 369);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(549, 100);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sabit Sayı ile Çarpma";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTers
            // 
            this.btnTers.Location = new System.Drawing.Point(63, 581);
            this.btnTers.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnTers.Name = "btnTers";
            this.btnTers.Size = new System.Drawing.Size(549, 90);
            this.btnTers.TabIndex = 7;
            this.btnTers.Text = "Tersini Alma";
            this.btnTers.UseVisualStyleBackColor = true;
            this.btnTers.Click += new System.EventHandler(this.btnTers_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 798);
            this.Controls.Add(this.btnTers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvolutif);
            this.Controls.Add(this.btnDeterminant);
            this.Controls.Add(this.btnCarpma);
            this.Controls.Add(this.btnCikarma);
            this.Controls.Add(this.btnToplama);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3x3 Matrislerde İşlemler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToplama;
        private System.Windows.Forms.Button btnCikarma;
        private System.Windows.Forms.Button btnCarpma;
        private System.Windows.Forms.Button btnDeterminant;
        private System.Windows.Forms.Button btnInvolutif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTers;
    }
}

