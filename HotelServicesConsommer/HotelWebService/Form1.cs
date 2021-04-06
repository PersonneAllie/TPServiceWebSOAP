using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelWebService
{
    public partial class Form1 : Form
    {
        public Form1(ServiceDisponibilite.Offre f,String url, String info)
        {

            InitializeComponent();

            label1.Text = f.idOffre;
            label2.Text = info;
            label3.Text = "OFFRE SUIVANTE";
            pictureBox1.Load(url);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
