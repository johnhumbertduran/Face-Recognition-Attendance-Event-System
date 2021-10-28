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
        public Admin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LogIn check = new LogIn();
            check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterStudent check = new RegisterStudent();
            check.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateEvent check = new CreateEvent();
            check.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SchoolEvents check = new SchoolEvents();
            check.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DetectFace check = new DetectFace();
            check.Show();
            Hide();
        }
    }
}
