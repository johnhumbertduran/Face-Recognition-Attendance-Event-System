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
            }
            connection.Close();
        }
        FaceRec faceRec = new FaceRec();
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
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
                    textBox2.Text = dr.GetString(2);
                    textBox2.Text = dr.GetString(2);
                    //MessageBox.Show("read?");
                }
                else
                {
                    textBox2.Text = "";
                    pictureBox2.Image = null;
                }
            }
            connection.Close();
        }
    }
}
