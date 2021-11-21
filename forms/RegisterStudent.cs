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
    public partial class RegisterStudent : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void check_id_number()
        {
            connection.Open();
            string get_last = "SELECT * FROM userstbl ORDER BY student_number Desc";
            command = new OleDbCommand(get_last, connection);
            //command.ExecuteNonQuery();
            OleDbDataReader read1 = command.ExecuteReader();
            if (read1.Read() == true)
            {
                int id_number = 20210000;
                if (Int32.Parse(read1.GetString(1)) > id_number)
                {
                    id_number = Int32.Parse(read1.GetString(1));
                    id_number += 1;
                }
                textBox1.Text = id_number.ToString();
            }
            connection.Close();
        }
        public RegisterStudent()
        {
            InitializeComponent();
            check_id_number();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Admin check = new Admin();
            check.Show();
            Hide();
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facedbDataSet.userstbl' table. You can move, or remove it, as needed.
            //this.userstblTableAdapter.Fill(this.facedbDataSet.userstbl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //userstblBindingSource.AddNew();
        }
        public static string student_number = "";
        public static string student_name = "";
        public static string pass_check = "";
        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string register = "INSERT INTO userstbl([student_number], [first_name], [last_name], [course], [student_year], [department], [username], [password], [reg_check]) VALUES ('" + textBox1.Text+"','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ textBox4.Text + "','"+ textBox5.Text + "','"+ textBox6.Text + "','"+ textBox7.Text + "','"+ textBox8.Text + "','2')";
            command = new OleDbCommand(register, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully registered!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            check_id_number();

            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            //textBox5.Text = "";
            //textBox6.Text = "";
            //textBox7.Text = "";
            //textBox8.Text = "";
            student_number = textBox1.Text;
            student_name = textBox2.Text + " " + textBox3.Text;
            pass_check = "1";
            RegisterFace check = new RegisterFace();
            check.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //userstblBindingSource.RemoveCurrent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
    }
}
