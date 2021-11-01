using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Face_Recognition_Attendance_Event_System
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Username and password are empty!");
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("Username is empty!");
            }
            else if(textBox1.Text != "" && textBox2.Text == "")
            {
                MessageBox.Show("Password is empty!");
            }else{
                connection.Open();
                string check_number = "SELECT username,password FROM userstbl WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "' AND reg_check='1'";
                command = new OleDbCommand(check_number, connection);
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.Read() == true)
                {
                    Admin check = new Admin();
                    check.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
            connection.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DetectFace check = new DetectFace();
            check.Show();
            Hide();
        }
    }
}
