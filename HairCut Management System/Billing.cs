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
    public partial class Billing : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adpt;
        DataTable dt;
        SqlCommand cmd;

        public Billing()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Appointment Appointment = new Appointment();
            Appointment.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Billing Billing = new Billing();
            Billing.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Employees Employees = new Employees();
            Employees.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logout Logout = new Logout();
            Logout.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cusName, servicename, cost;
            cusName = textBox3.Text.ToString();
            servicename = textBox1.Text.ToString();
            cost = textBox2.Text.ToString();          

            if (String.IsNullOrEmpty(cusName) || String.IsNullOrEmpty(servicename) || String.IsNullOrEmpty(cost))
            {
                MessageBox.Show("No empty fields allowed");
            }
            else
            {
                //conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO billing (cusname, servicename, cost) VALUES ('" + cusName + "', '" + servicename + "' , '" + cost + "')";
                cmd.Connection = conn;
                int a = cmd.ExecuteNonQuery();

                conn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Successfully inserted.");
                    textBox3.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";                   
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cusName = textBox3.Text;

            if (textBox3.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("DELETE billing WHERE cusName = '" + textBox3.Text + "'", conn);
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
            cmd = new SqlCommand("UPDATE billing SET servicename ='" + textBox1.Text + "', cost = '" + textBox2.Text + "' WHERE cusname = '" + textBox1.Text + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            conn.Close();
        }
    }
}
