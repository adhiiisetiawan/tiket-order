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
    public partial class Keranjang : Form
    {
        private static string connectionString = "server=localhost;" +
            "port=3306;" +
            "username=root;" +
            "password='';" +
            "database=tiket; " +
            "convert zero datetime=True";
        private MySqlConnection databaseConnection = new MySqlConnection(connectionString);

        public Keranjang(string event1, string address, string nama)
        {
            InitializeComponent();
            listKeranjang.Items.Clear();
            string query = "SELECT p.id_pembelian, t.nama_tiket, m.nama_member, " +
                "t.alamat_tiket FROM membeli p, data_tiket t, member m where t.id_tiket=p.id_tiket and m.id_member=p.id_member";
            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                MySqlDataReader reader = cmd.ExecuteReader();

                // IMPORTANT :                  
                // If your query returns result, use the following processor : 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["id_pembelian"].ToString());
                        listViewItem.SubItems.Add(reader["nama_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["nama_member"].ToString());
                        listViewItem.SubItems.Add(reader["alamat_tiket"].ToString());

                        listKeranjang.Items.Add(listViewItem);

                    }

                    reader.Close();
                }
                else { MessageBox.Show("No rows found."); }

            }

            catch (Exception ex)
            {
                // Show any error message.                 
                MessageBox.Show(ex.Message);
            }
            finally { databaseConnection.Close(); }
        }

        private void Keranjang_Load(object sender, EventArgs e)
        {
            
        }


        private void Button_refresh_Click(object sender, EventArgs e)
        {

        }
    }
}

