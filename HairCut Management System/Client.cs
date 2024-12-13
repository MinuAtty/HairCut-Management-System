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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;

namespace HairCut_Management_System
{
    public partial class Client : Form
    {
        //private string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30";        
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adpt;
        DataTable dt;
        //SqlConnection conn = new SqlConnection();
        SqlCommand cmd;

        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Client Client = new Client();
            Client.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Services Services = new Services();
            Services.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Appointment Appointment = new Appointment();
            Appointment.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Billing Billing = new Billing();
            Billing.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Employees Employees = new Employees();
            Employees.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Logout Logout = new Logout();
            Logout.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string clientName, clientSurname, clientPhone, clientEmail;
            clientName = textBox1.Text.ToString();
            clientSurname = textBox3.Text.ToString();
            clientPhone = textBox2.Text.ToString();
            clientEmail = textBox5.Text.ToString();

            if (String.IsNullOrEmpty(clientName) || String.IsNullOrEmpty(clientSurname) || String.IsNullOrEmpty(clientPhone))
            {
                MessageBox.Show("No empty fields allowed except email address of the client");
            }
            else
            {
                //conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO client (clientname, clientsurname, clientphone, clientemail) VALUES ('" + clientName + "', '" + clientSurname + "' , '" + clientPhone + "' , '" + clientEmail + "')";
                cmd.Connection = conn;
                int a = cmd.ExecuteNonQuery();

                conn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Client successfully registered.");
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string clientName = textBox1.Text;

            if (textBox1.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("DELETE client WHERE clientname = '" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter client name");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UPDATE client SET clientphone ='" + textBox2.Text + "', clientEmail = '" + textBox5.Text + "' WHERE clientName = '" + textBox1.Text + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            conn.Close();
        }
    }
}
