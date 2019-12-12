using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp19
{

    public partial class HalamanDetilTiket : Form
    {

        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=tiket;";
        MySqlConnection dbCon = new MySqlConnection(connectionString);
        public HalamanDetilTiket()
        {
            InitializeComponent();
         

        }

        public HalamanDetilTiket(string tix)

            : this()
            

        {

            dbCon.Open();
            MySqlCommand cmd = dbCon.CreateCommand();
            string judul = "SELECT * from data_tiket where id_tiket = '" + tix + "'";
            cmd.CommandText = judul;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                text_event.Text = reader.GetValue(1).ToString();
                text_date.Text = reader.GetValue(4).ToString();
                text_address.Text = reader.GetValue(3).ToString();
                text_harga.Text = reader.GetValue(2).ToString();
                text_id.Text = reader.GetValue(0).ToString();
            }
            dbCon.Close();
            dbCon.Open();

        }

        public void tix()
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            decimal harga = (Convert.ToDecimal(text_harga.Text));
            decimal total_harga = numericUpDown1.Value * harga;

            try
            {


            }
            finally
            {
                if (numericUpDown1.Value >= 3)
                {
                    total_harga -= 100000;
                    MessageBox.Show("Selamat Anda Mendapat Diskon 100,000", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                total.Text = total_harga.ToString();
            }



            string id = text_id.Text;
            string query = "UPDATE data_tiket SET stok_tiket = stok_tiket - 1 WHERE id_tiket = '" + id + "'";


            try
            {

                MySqlCommand cmd = new
                MySqlCommand(query, dbCon);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public string kiriman(string nama)
        {
            textBox1.Text = nama;
            return textBox1.Text;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            kiriman(textBox1.Text);
            string event1 = text_event.Text;
            string address = text_address.Text;
            string nama = textBox1.Text;

            Keranjang sc = new Keranjang(event1, address, nama);
            sc.Show();
            this.Close();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
