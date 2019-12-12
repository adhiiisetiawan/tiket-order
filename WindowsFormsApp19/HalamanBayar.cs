using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class HalamanBayar : Form
    {
        public HalamanBayar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);  
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HalamanBayar f5 = new HalamanBayar();
            MessageBox.Show("Terima Kasih Sudah Membeli", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
