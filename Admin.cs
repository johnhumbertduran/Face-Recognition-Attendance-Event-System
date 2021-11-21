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
    public partial class Admin : Form
    {

        private Form activeForm;

        public Admin()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(childForm);
            this.panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LogIn check = new LogIn();
            check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //RegisterStudent check = new RegisterStudent();
            //check.Show();
            //Hide();
            OpenChildForm(new RegisterStudent(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CreateEvent check = new CreateEvent();
            //check.Show();
            //Hide();
            OpenChildForm(new CreateEvent(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SchoolEvents check = new SchoolEvents();
            //check.Show();
            //Hide();
            OpenChildForm(new SchoolEvents(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //RegisterFace check = new RegisterFace();
            //check.Show();
            //Hide();
            OpenChildForm(new RegisterFace(), sender);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //StudentRecord check = new StudentRecord();
            //check.Show();
            //Hide();
            OpenChildForm(new StudentRecord(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                label1.Text = "Home";
            }
        }
    }
}
