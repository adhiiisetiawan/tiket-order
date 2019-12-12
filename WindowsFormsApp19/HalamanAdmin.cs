using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp19
{
    public partial class HalamanAdmin : Form
    {
        private static string connectionString = "server=localhost;" +
            "port=3306;" +
            "username=root;" +
            "password='';" +
            "database=tiket; " +
            "convert zero datetime=True";
        private MySqlConnection databaseConnection = new MySqlConnection(connectionString);

        public HalamanAdmin()
        {
            InitializeComponent();
        }

        private String GetHashedText(string inputData)
        {
            byte[] tmpSource;
            byte[] tmpData;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
            tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpData);
        }

        private void HalamanAdmin_Load(object sender, EventArgs e)
        {
            //button_refresh_Click(sender, e);
            //button_RefreshData_Click(sender, e);
            // button_refreshDataPromo_Click(sender, e);

        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            listTiket.Items.Clear();

            string query = "SELECT * FROM data_tiket";

            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection); cmd.CommandTimeout = 60; MySqlDataReader reader = cmd.ExecuteReader();

                // IMPORTANT :                  
                // If your query returns result, use the following processor : 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["id_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["nama_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["harga_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["alamat_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["tanggal_tiket"].ToString());
                        listViewItem.SubItems.Add(reader["stok_tiket"].ToString());

                        listTiket.Items.Add(listViewItem);

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

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO data_tiket " +
                "(nama_tiket, harga_tiket, alamat_tiket, tanggal_tiket, stok_tiket) " +
                "VALUES (@nama_event, @harga_tiket, @alamat_event,@tanggal_event, @stok_tiket)";

            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@nama_event", text_namaEvent.Text);
                cmd.Parameters.AddWithValue("@harga_tiket", text_hargaTiket.Text);
                cmd.Parameters.AddWithValue("@alamat_event", text_alamatEvent.Text);
                cmd.Parameters.AddWithValue("@tanggal_event", date_tanggalTiket.Value);
                cmd.Parameters.AddWithValue("@stok_tiket", text_stokTiket.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");

            }
            catch (Exception ex)
            {
                // Show any error message.                 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }
            HalamanAdmin_Load(sender, e);
        }

        private void button_updateTiket_Click(object sender, EventArgs e)
        {
            string query = "UPDATE data_tiket SET id_tiket = @id_tiket, nama_tiket=@nama_event, harga_tiket=@harga_tiket, alamat_tiket=@alamat_event, " +
                "tanggal_tiket=@tanggal_event, stok_tiket=@stok_tiket WHERE id_tiket=@id_tiket";

            try
            {

                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@id_tiket", text_idTiket.Text);
                cmd.Parameters.AddWithValue("@nama_event", text_namaEvent.Text);
                cmd.Parameters.AddWithValue("@harga_tiket", text_hargaTiket.Text);
                cmd.Parameters.AddWithValue("@alamat_event", text_alamatEvent.Text);
                cmd.Parameters.AddWithValue("@tanggal_event", date_tanggalTiket.Value);
                cmd.Parameters.AddWithValue("@stok_tiket", text_stokTiket.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate");
            }

            catch (Exception ex)
            {
                // Show any error message.                 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }

            HalamanAdmin_Load(sender, e);
        }

        private void listTiket_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = listTiket.SelectedItems[0];
            if (item != null)
            {
                text_idTiket.Text = item.SubItems[0].Text;
                text_namaEvent.Text = item.SubItems[1].Text;
                text_hargaTiket.Text = item.SubItems[2].Text;
                text_alamatEvent.Text = item.SubItems[3].Text;
                date_tanggalTiket.Text = item.SubItems[4].Text;
                text_stokTiket.Text = item.SubItems[5].Text;

                button_refresh_Click(sender, e);

            }
        }

        private void button_hapusTiket_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM data_tiket WHERE id_tiket= @id_tiket";

            try
            {

                // Open the database                     
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@id_tiket", text_idTiket.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
            }

            catch (Exception ex)
            {
                // Show any error message.                     
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }

            HalamanAdmin_Load(sender, e);
        }

        private void button_RefreshData_Click(object sender, EventArgs e)
        {
            listMember.Items.Clear();

            string query = "SELECT * FROM member";

            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection); cmd.CommandTimeout = 60; MySqlDataReader reader = cmd.ExecuteReader();

                // IMPORTANT :                  
                // If your query returns result, use the following processor : 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["id_member"].ToString());
                        listViewItem.SubItems.Add(reader["username"].ToString());
                        listViewItem.SubItems.Add(reader["password"].ToString());
                        listViewItem.SubItems.Add(reader["nama_member"].ToString());
                        listViewItem.SubItems.Add(reader["no_hp"].ToString());
                        listViewItem.SubItems.Add(reader["email"].ToString());

                        listMember.Items.Add(listViewItem);

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

        private void button_TambahMember_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO member " +
               "(username, password, nama_member, no_hp, email) " +
               "VALUES (@username, @password, @nama_member,@no_hp, @email)";

            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@username", text_username.Text);
                cmd.Parameters.AddWithValue("@password", GetHashedText(text_password.Text));
                cmd.Parameters.AddWithValue("@nama_member", text_namaMember.Text);
                cmd.Parameters.AddWithValue("@no_hp", text_nomorHP.Text);
                cmd.Parameters.AddWithValue("@email", text_email.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");

            }
            catch (Exception ex)
            {
                // Show any error message.                 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }

            button_RefreshData_Click(sender, e);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button_HapusMember_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM member WHERE id_member= @id_member";

            try
            {

                // Open the database                     
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@id_member", text_idMember.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
            }

            catch (Exception ex)
            {
                // Show any error message.                     
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }

            HalamanAdmin_Load(sender, e);
        }

        private void listMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = listMember.SelectedItems[0];
            if (item != null)
            {
                text_idMember.Text = item.SubItems[0].Text;
                text_username.Text = item.SubItems[1].Text;
                text_password.Text = item.SubItems[2].Text;
                text_namaMember.Text = item.SubItems[3].Text;
                text_nomorHP.Text = item.SubItems[4].Text;
                text_email.Text = item.SubItems[5].Text;

                button_RefreshData_Click(sender, e);


            }
        }

        private void button_UpdateMember_Click(object sender, EventArgs e)
        {
            string query = "UPDATE member SET id_member = @id_member, username=@username, password=@password, nama_member=@nama_member, " +
                "no_hp=@no_hp, email=@email WHERE id_member=@id_member";

            try
            {

                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@id_member", text_idMember.Text);
                cmd.Parameters.AddWithValue("@username", text_username.Text);
                cmd.Parameters.AddWithValue("@password", GetHashedText(text_password.Text));
                cmd.Parameters.AddWithValue("@nama_member", text_namaMember.Text);
                cmd.Parameters.AddWithValue("@no_hp", text_nomorHP.Text);
                cmd.Parameters.AddWithValue("@email", text_email.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate");
            }

            catch (Exception ex)
            {
                // Show any error message.                 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }

            HalamanAdmin_Load(sender, e);
        }

        private void button_refreshDataPromo_Click(object sender, EventArgs e)
        {
            listPromo.Items.Clear();

            string query = "SELECT * FROM promo";

            try
            {
                // Open the database                 
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(query, databaseConnection); cmd.CommandTimeout = 60; MySqlDataReader reader = cmd.ExecuteReader();

                // IMPORTANT :                  
                // If your query returns result, use the following processor : 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["id_promo"].ToString());
                        listViewItem.SubItems.Add(reader["nama_promo"].ToString());
                        listViewItem.SubItems.Add(reader["kode_promo"].ToString());
                        listViewItem.SubItems.Add(reader["diskon"].ToString());


                        listPromo.Items.Add(listViewItem);

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

        private void Button_logout_Click(object sender, EventArgs e)
        {
            HalamanLogin f2 = new HalamanLogin();
            f2.Show();
            this.Close();
        }

        private void ListPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = listPromo.SelectedItems[0];
            if (item != null)
            {
                text_IDPromo.Text = item.SubItems[0].Text;
                text_namaPromo.Text = item.SubItems[1].Text;
                text_kodePromo.Text = item.SubItems[2].Text;
                text_Diskon.Text = item.SubItems[3].Text;

                button_refreshDataPromo_Click(sender, e);
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }
    }
}
