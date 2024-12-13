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
    public partial class Appointment : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adpt;
        DataTable dt;
        SqlCommand cmd;
        public Appointment()
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

        private void button8_Click(object sender, EventArgs e)
        {
            string customerName, customerPhone;
            customerName = textBox1.Text.ToString();
            customerPhone = textBox2.Text.ToString();           

            if (String.IsNullOrEmpty(customerName) || String.IsNullOrEmpty(customerPhone))
            {
                MessageBox.Show("No empty fields allowed");
            }
            else
            {
                //conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO appointment (customername, customerphone) VALUES ('" + customerName + "', '" + customerPhone + "')";
                cmd.Connection = conn;
                int a = cmd.ExecuteNonQuery();

                conn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Customer successfully registered.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string customerName = textBox1.Text;

            if (textBox1.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("DELETE appointment WHERE customerName = '" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter customer name");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UPDATE appointment SET customerphone ='" + textBox2.Text + "' WHERE customerName = '" + textBox1.Text + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            conn.Close();
        }
    }
}
