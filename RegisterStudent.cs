using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Face_Recognition_Attendance_Event_System
{
    public partial class RegisterStudent : Form
    {
        public RegisterStudent()
        {
            InitializeComponent();
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
            this.userstblTableAdapter.Fill(this.facedbDataSet.userstbl);
            // TODO: This line of code loads data into the 'facedbDataSet.userstbl' table. You can move, or remove it, as needed.
            //this.userstblTableAdapter.Fill(this.facedbDataSet.userstbl);

        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.userstblTableAdapter.search(this.facedbDataSet.userstbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userstblBindingSource.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userstblBindingSource.EndEdit();
            userstblTableAdapter.Update(facedbDataSet.userstbl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userstblBindingSource.RemoveCurrent();
        }

        private void searchToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.userstblTableAdapter.search(this.facedbDataSet.userstbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
