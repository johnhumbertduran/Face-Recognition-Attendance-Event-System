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
        }
        FaceRec faceRec = new FaceRec();
        private void button1_Click(object sender, EventArgs e)
        {
            Admin check = new Admin();
            check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1,pictureBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(textBox1.Text);
            facetblBindingSource.AddNew();
            facetblBindingSource.EndEdit();
            facetblTableAdapter.Update(facedbDataSet1.facetbl);
            MessageBox.Show("Saved!");
        }

        private void DetectFace_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'facedbDataSet1.facetbl' table. You can move, or remove it, as needed.
            this.facetblTableAdapter.Fill(this.facedbDataSet1.facetbl);
            dataGridView1.Visible = false;


        }

        private void faceSearchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.facetblTableAdapter.faceSearch(this.facedbDataSet1.facetbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void faceSearchToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.facetblTableAdapter.faceSearch(this.facedbDataSet1.facetbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = true;
            faceRec.getPersonName(textBox1);

            //if (textBox1.Text != "")
            //{
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\\Visual Studio Projects\\Face Recognition Attendance Event System\\bin\\Debug\\facedb.accdb'"))
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT student_name FROM facetbl WHERE student_number = @param1";
                        command.Parameters.AddWithValue("@param1", textBox1);

                        using (OleDbDataReader reader1 = command.ExecuteReader())
                        {

                            if (reader1.Read())
                            {
                                textBox2.Text = reader1["student_name"].ToString();
                                MessageBox.Show("read?");
                                return;
                        }                            
                            MessageBox.Show(textBox1.Text);
                            //textBox2.Text = reader1["name"].ToString();
                        }
                    }
                    connection.Close();
                }
            
            //}
            //else
            //{
            //MessageBox.Show("No data found");
            //}
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}
