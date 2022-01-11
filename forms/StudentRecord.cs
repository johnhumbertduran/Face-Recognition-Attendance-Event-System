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
    public partial class StudentRecord : Form
    {
        public StudentRecord()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\Visual Studio Projects\Face Recognition Attendance Event System\bin\Debug\facedb.accdb'");
        
        private void button2_Click(object sender, EventArgs e)
        {
            Admin check = new Admin();
            check.Show();
            Hide();
        }

        private void setDataGrid()
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            string check_data = "SELECT * FROM attendancetbl";
            command = new OleDbCommand(check_data, connection);
            //command.CommandText = check_data;

            //OleDbDataReader da = new OleDbDataAdapter(command);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
        }
        private void StudentRecord_Load(object sender, EventArgs e)
        {
            setDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
