using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Serialization;
using CarRentRestApi.Models;

namespace CarRentRestApi.WinUI
{
    public partial class CalisanLogin : Form
    {
        public CalisanLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "beyza" && txtSifre.Text == "1234")
            {
                MessageBox.Show("Admin Girişi Başarılı");
                this.Hide();
                CalisanAnaSayfa cs = new CalisanAnaSayfa();
                cs.ShowDialog();
            }

        }
    }
}
