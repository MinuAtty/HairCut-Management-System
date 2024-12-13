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
    public partial class Services : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adpt;
        DataTable dt;
        SqlCommand cmd;
        public Services()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client Client = new Client();
            Client.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Services Services = new Services();
            Services.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Appointment Appointment = new Appointment();
            Appointment.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Billing Billing = new Billing();
            Billing.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Employees Employees = new Employees();
            Employees.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Logout Logout = new Logout();
            Logout.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string productName, productPrice, duration, cost;
            productName = textBox1.Text.ToString();
            productPrice = textBox2.Text.ToString();
            duration = textBox3.Text.ToString();
            cost = textBox4.Text.ToString();

            if (String.IsNullOrEmpty(productName) || String.IsNullOrEmpty(productPrice) || String.IsNullOrEmpty(duration) || String.IsNullOrEmpty(cost))
            {
                MessageBox.Show("No empty fields allowed");
            }
            else
            {
                //conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO client (productname, productprice, duration, cost) VALUES ('" + productName + "', '" + productPrice + "' , '" + duration + "' , '" + cost + "')";
                cmd.Connection = conn;
                int a = cmd.ExecuteNonQuery();

                conn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Product successfully inserted.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string productName = textBox1.Text;

            if (textBox1.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("DELETE services WHERE productname = '" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter product name");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UPDATE services SET duration ='" + textBox3.Text + "', cost = '" + textBox4.Text + "' WHERE productName = '" + textBox1.Text + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            conn.Close();
        }
    }
}