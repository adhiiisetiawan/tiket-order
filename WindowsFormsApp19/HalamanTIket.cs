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
    public partial class HalamanTIket : Form
    {
        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=tiket;";
        MySqlConnection dbCon = new MySqlConnection(connectionString);

        public HalamanTIket()
        {
            InitializeComponent();
        }
        public HalamanTIket(string terima)
            : this()
        {
            label4.Text = terima;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HalamanLogin f2 = new HalamanLogin();
            f2.Show();
            this.Close();
        }
        public void refresh()
        {
            listView1.Items.Clear();
            string query = "SELECT * FROM data_tiket";
            try
            {
                //open the database
                //databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                MySqlDataReader reader = cmd.ExecuteReader();

                //IMPORTANT :
                //if your query returns result, use the following processor :
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["id_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["nama_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["harga_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["alamat_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["tanggal_tiket"].ToString());
                        listView1.Items.Add(listViewItem);
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("No rows found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dbCon.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbCon.Open();
            refresh();
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Form4 f4 = new Form4(2);
        //    f4.Show();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Form4 f4 = new Form4(1);
        //    f4.Show();
        //}

        private void label3_Click(object sender, EventArgs e)
        {
            string kiriman;
            kiriman = label4.Text;
            EditData f6 = new EditData(kiriman);
            f6.Show();
            this.Hide();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string kiriman = listView1.SelectedItems[0].Text;
            HalamanDetilTiket f4 = new HalamanDetilTiket(kiriman);
            f4.Show();
            this.Close();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
