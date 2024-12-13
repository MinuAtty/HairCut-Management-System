using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairCut_Management_System
{
    public partial class login : Form
    {
        private string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        public login()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.ToString();
            string userPassword = textBox2.Text.ToString();
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(userPassword))
            {
                DialogResult dialogResult = MessageBox.Show("No empty fields allowed", "You cannot continue", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM user_table WHERE username ='" + userName + "' AND userpassword ='" + userPassword + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Client client = new Client();
                    client.Show();
                    this.Hide();               
                }
                else
                {
                    MessageBox.Show("User Name or User Password incorrect");
                }
                //MessageBox.Show("Connection Success!");
                conn.Close();
            }
        }
    }
}
