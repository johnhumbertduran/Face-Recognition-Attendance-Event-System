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
            if ((textBox1.Text == "") || (textBox2.Text == "") || (dateTimePicker1.Text.Length == 0) || (textBox4.Text == "") || (textBox5.Text == "") )
            {
                MessageBox.Show("Please input details!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (textBox1.Text != "" && textBox2.Text == "" && dateTimePicker1.Text.Length == 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event place, date, and time!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (textBox1.Text == "" && textBox2.Text != "" && dateTimePicker1.Text.Length == 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event name, date, and time!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if(textBox1.Text == "" && textBox2.Text == "" && dateTimePicker1.Text.Length != 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event name, place, and time!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (textBox1.Text == "" && textBox2.Text == "" && dateTimePicker1.Text.Length == 0 && textBox4.Text != "")
            //{
            //    MessageBox.Show("Please input event name, place, and date!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if(textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text.Length == 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event date and time!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if(textBox1.Text == "" && textBox2.Text != "" && dateTimePicker1.Text.Length != 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event name and time!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (textBox1.Text == "" && textBox2.Text == "" && dateTimePicker1.Text.Length != 0 && textBox4.Text != "")
            //{
            //    MessageBox.Show("Please input event name and place!", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (textBox1.Text != "" && textBox2.Text == "" && dateTimePicker1.Text.Length != 0 && textBox4.Text == "")
            //{
            //    MessageBox.Show("Please input event place and time", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else if (textBox1.Text != "" && textBox2.Text == "" && dateTimePicker1.Text.Length == 0 && textBox4.Text != "")
            //{
            //    MessageBox.Show("Please input event place and date", "Insufficient Data!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text.Length != 0 && textBox4.Text != "" && textBox5.Text != "")
            {
                connection.Open();
                string create_event = "INSERT INTO eventtbl([event_name], [event_place], [event_date], [event_time_in], [event_time_out]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.Date.ToShortDateString() + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                command = new OleDbCommand(create_event, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully registered!", "Create event", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
