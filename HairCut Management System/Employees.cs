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
using System.Diagnostics.Eventing.Reader;

namespace HairCut_Management_System
{
    public partial class Employees : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Minusha Attygala\Downloads\C# Assesment\HaircutDB\HairDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adpt;
        DataTable dt;
        SqlCommand cmd;

        public Employees()
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

        private void button7_Click(object sender, EventArgs e)
        {
            Billing Billing = new Billing();
            Billing.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Employees Employees = new Employees();
            Employees.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logout Logout = new Logout();
            Logout.Show();
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string employeeName, emplyeeEmail, phone, employeeAddress, position;
            employeeName = textBox1.Text.ToString();
            emplyeeEmail = textBox4.Text.ToString();
            phone = textBox2.Text.ToString();
            employeeAddress = textBox3.Text.ToString();
            position = textBox5.Text.ToString();

            if (String.IsNullOrEmpty(employeeName) || String.IsNullOrEmpty(emplyeeEmail) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(employeeAddress) || String.IsNullOrEmpty(position))
            {
                MessageBox.Show("No empty fields allowed");
            }
            else
            {
                //conn.ConnectionString = CONNECTION_STRING;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO employee (employeeName, emplyeeEmail, phone, employeeAddress, position) VALUES ('" + employeeName + "', '" + emplyeeEmail + "' , '" + phone + "' , '" + employeeAddress + "', '" + position + "')";
                cmd.Connection = conn;
                int a = cmd.ExecuteNonQuery();

                conn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Employee successfully registered.");
                    textBox1.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string employeeName = textBox1.Text;

            if (textBox1.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("DELETE employee WHERE employeeName = '" + textBox1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter employee name");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UPDATE employee SET phone ='" + textBox2.Text + "', employeeAddress = '" + textBox3.Text + "' WHERE employeeName = '" + textBox1.Text + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            conn.Close();
        }
    }
}
