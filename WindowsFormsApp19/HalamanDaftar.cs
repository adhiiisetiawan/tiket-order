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
using System.Security.Cryptography;

namespace WindowsFormsApp19
{
    public partial class HalamanDaftar : Form
    {
        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=tiket;";
        MySqlConnection dbCon = new MySqlConnection(connectionString);
        public HalamanDaftar()
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

        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO member (username, password, nama_member, no_hp, email) VALUES (@username, @password, @nama_member, @no_hp, @email)";
            try
            {
                //open the database
                dbCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", GetHashedText(pass.Text));
                cmd.Parameters.AddWithValue("@nama_member", name.Text);
                cmd.Parameters.AddWithValue("@no_hp", hp.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil ditambahkan");
                HalamanTIket f1 = new HalamanTIket();
                f1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                //show any error message
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
