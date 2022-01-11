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
    public partial class RegisterFace : Form
    {
        public RegisterFace()
        {
            InitializeComponent();
        }
        FaceRec faceRec = new FaceRec();
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            //textBox2.Text = "";
            Admin check = new Admin();
            check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1,pictureBox2);
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(textBox1.Text);
            connection.Open();
            string register_face = "INSERT INTO facetbl([student_number], [student_name]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
            command = new OleDbCommand(register_face, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully registered face!", "Face detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Saved!");
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void DetectFace_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facedbDataSet.facetbl' table. You can move, or remove it, as needed.
            //this.facetblTableAdapter.Fill(this.facedbDataSet.facetbl);
            //dataGridView1.Visible = false;
              
            if (RegisterStudent.pass_check == "1")
            {
                textBox1.Text = RegisterStudent.student_number;
                textBox2.Text = RegisterStudent.student_name;
                RegisterStudent.pass_check = "0";

                // convert to int to subtract the student number
                int test = Int32.Parse(textBox1.Text);
                test = test - 1;

                //return to string to display the difference
                textBox1.Text = test.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = true;
            faceRec.getPersonName(textBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
