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
    public partial class CreateEvent : Form
    {

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter dr = new OleDbDataAdapter();
        public CreateEvent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin check = new Admin();
            check.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string create_event = "INSERT INTO eventtbl([event_name], [event_date], [event_place]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            command = new OleDbCommand(create_event, connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully registered!", "Create event", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
