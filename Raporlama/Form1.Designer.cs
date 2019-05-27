namespace Raporlama
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sbtnMusteriFaturasi = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // sbtnMusteriFaturasi
            // 
            this.sbtnMusteriFaturasi.Location = new System.Drawing.Point(23, 21);
            this.sbtnMusteriFaturasi.Name = "sbtnMusteriFaturasi";
            this.sbtnMusteriFaturasi.Size = new System.Drawing.Size(132, 64);
            this.sbtnMusteriFaturasi.TabIndex = 0;
            this.sbtnMusteriFaturasi.Text = "Müşteri Faturası";
            this.sbtnMusteriFaturasi.Click += new System.EventHandler(this.sbtnMusteriFaturasi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 238);
            this.Controls.Add(this.sbtnMusteriFaturasi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbtnMusteriFaturasi;
    }
}

