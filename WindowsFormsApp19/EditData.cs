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
    public partial class EditData : Form
    {
        private static string connectionString = "server=localhost;port=3306;username=root;password=;database=tiket;";
        MySqlConnection dbCon = new MySqlConnection(connectionString);
        public EditData()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        public EditData(string terima)
            : this()
        {
            dbCon.Open();
            MySqlCommand cmd = dbCon.CreateCommand();
            string sql = "SELECT * FROM member WHERE nama_member like '" + terima+"'";
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                id_member.Text = reader.GetValue(0).ToString();
                name.Text = reader.GetValue(3).ToString();
                username.Text = reader.GetValue(1).ToString();
                hp.Text = reader.GetValue(4).ToString();
                email.Text = reader.GetValue(5).ToString();
            }
            dbCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE member SET username = @username, nama_member = @nama_member, no_hp = @no_hp, email = @email WHERE id_member = @id_member";
            try
            {
                //open the database
                dbCon.Open();
                MySqlCommand cmd = new MySqlCommand(query, dbCon);
                cmd.CommandTimeout = 60;
                cmd.Parameters.AddWithValue("@id_member", id_member.Text);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@nama_member", name.Text);
                cmd.Parameters.AddWithValue("@no_hp", hp.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diupdate");
            }
            catch (Exception ex)
            {
                //show any error message
                MessageBox.Show(ex.Message);
            }
            dbCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kiriman;
            kiriman = name.Text;
            HalamanTIket f1 = new HalamanTIket(kiriman);
            f1.Show();
            this.Close();
        }
    }
}
