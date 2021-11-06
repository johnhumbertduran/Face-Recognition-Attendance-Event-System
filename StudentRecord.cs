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
    public partial class StudentRecord : Form
    {
        public StudentRecord()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin check = new Admin();
            check.Show();
            Hide();
        }
    }
}
