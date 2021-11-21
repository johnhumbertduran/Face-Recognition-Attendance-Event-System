using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;
using System.Data.OleDb;

namespace Face_Recognition_Attendance_Event_System
{
    public partial class DetectFace : Form
    {
        public DetectFace()
        {
            InitializeComponent();
            connection.Open();
            string get_last_id = "SELECT * FROM eventtbl ORDER BY ID Desc";
            command = new OleDbCommand(get_last_id, connection);
            //command.ExecuteNonQuery();
            OleDbDataReader read2 = command.ExecuteReader();
            if (read2.Read() == true)
            {
                textBox3.Text = read2.GetString(1);
                textBox4.Text = read2.GetString(2);
            }
            connection.Close();
        }
        FaceRec faceRec = new FaceRec();
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbCommand command1 = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
        OleDbDataAdapter check_attendance = new OleDbDataAdapter();
        private void button2_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = true;
            faceRec.getPersonName(textBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = false;
            textBox1.Text = null;
            textBox2.Text = "";
            pictureBox2.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn check = new LogIn();
            faceRec.isTrained = false;
            check.Show();
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            string check_number = "SELECT * FROM userstbl WHERE student_number='" + textBox1.Text + "'";
            command = new OleDbCommand(check_number, connection);
            OleDbDataReader dr = command.ExecuteReader();
            if (textBox1.Text != null)
            {
                if (dr.Read() == true)
                {
                    textBox2.Text = dr.GetString(2) + " " + dr.GetString(3);

                    string check_attendance = "SELECT * FROM attendancetbl WHERE student_number='" + textBox1.Text + "' AND event_date='" + textBox4.Text + "' ";
                    command1 = new OleDbCommand(check_attendance, connection);
                    OleDbDataReader check_attendance_date = command1.ExecuteReader();
                    if (check_attendance_date.Read() == true)
                    {
                        //MessageBox.Show(check_attendance_date.GetString(1));
                        if ((check_attendance_date.GetString(1) == textBox1.Text) && (check_attendance_date.GetString(4) == textBox4.Text))
                        {
                            connection.Close();
                            MessageBox.Show(textBox2.Text + " is already registered", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string register_attendance = "INSERT INTO attendancetbl([student_number], [student_name], [event_name], [event_date], [event_time]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                            command = new OleDbCommand(register_attendance, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("Succesfully saved attendance for " + textBox2.Text, "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //MessageBox.Show("save this");
                        }
                        connection.Close();
                    }
                    else
                    {
                        string register_attendance = "INSERT INTO attendancetbl([student_number], [student_name], [event_name], [event_date], [event_time]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                        command = new OleDbCommand(register_attendance, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Succesfully saved attendance for " + textBox2.Text, "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("False");
                        //MessageBox.Show(check_attendance_date.GetString(3));
                        //connection.Close();
                    }

                    
                        //if ((textBox1.Text == check_attendance_date.GetString(2)) && (textBox4.Text == check_attendance_date.GetString(5)))
                        //{
                            //MessageBox.Show(check_attendance_date.GetString(3) + " is already registered", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //connection.Close();
                        //}
                        //else
                        //{
                            //string register_attendance = "INSERT INTO attendancetbl([student_number], [student_name], [event_name], [event_date]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                            //command = new OleDbCommand(register_attendance, connection);
                            //command.ExecuteNonQuery();
                            //connection.Close();
                            //MessageBox.Show("Succesfully saved attendance for " + dr.GetString(2), "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        connection.Close();
                }
                else
                {
                    connection.Close();
                    textBox2.Text = "";
                    pictureBox2.Image = null;
                }
            }
            connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string register_attendance = "INSERT INTO attendancetbl([student_number], [student_name], [event_name], [event_date]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command = new OleDbCommand(register_attendance, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully registered attendance!", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DetectFace_Load(object sender, EventArgs e)
        {

        }
    }
}
