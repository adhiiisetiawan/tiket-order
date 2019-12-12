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
    public partial class HalamanLogin : Form
    {
        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=tiket;";
        MySqlConnection dbCon = new MySqlConnection(connectionString);

        private String GetHashedText(string inputData)
        {
            byte[] tmpSource;
            byte[] tmpData;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
            tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpData);
        }

        public HalamanLogin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string kiriman;
            dbCon.Open();
//                        MySqlCommand cmd = dbCon.CreateCommand();
  //                    string sql = "SELECT * FROM member WHERE username like '" + textBox1.Text + "'" +
    //                    " AND password like '" + textBox2.Text+"'";
      //            cmd.CommandText = sql;

            MySqlCommand cmd = new MySqlCommand("select * from member where username=@username and" +
                " password=@password", dbCon);

            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", GetHashedText(textBox2.Text));
            {

            }
            MySqlDataReader reader = cmd.ExecuteReader();
           


            if (reader.Read())
            {
                MessageBox.Show("Login berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kiriman = reader["nama_member"].ToString();
                //Form4 f4 = new Form4();
                //f4.kiriman(kiriman);
          
                HalamanTIket f1 = new HalamanTIket(kiriman);
                Keranjang krj = new Keranjang(null,null,null);
                f1.Show();
                this.Hide();

            } else if ((textBox1.Text == "admin") && (textBox2.Text=="admin"))
            {
                MessageBox.Show("Login berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HalamanAdmin admin = new HalamanAdmin();
                admin.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username dan Password tidak cocok", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dbCon.Close();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            HalamanDaftar f3 = new HalamanDaftar();
            f3.Show();
            this.Hide();
        }
    }
}
