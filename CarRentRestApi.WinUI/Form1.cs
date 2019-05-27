using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentRestApi.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalisan_Click(object sender, EventArgs e)
        {
            CalisanLogin cl = new CalisanLogin();
            cl.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            MusteriLogin ml = new MusteriLogin();
            ml.Show();
        }
    }
}
