using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Remont
{
    public partial class Avto : Form
    {
        public Avto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            string SQL = "Select n_avto,vin,marka,model,god,reg_n,fio_v from Avto where vin like N'" + textBox1.Text + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[1].HeaderText = "VIN";
            dataGridView1.Columns[2].HeaderText = "Марка";
            dataGridView1.Columns[3].HeaderText = "Модель";
            dataGridView1.Columns[4].HeaderText = "Год";
            dataGridView1.Columns[5].HeaderText = "Рег. №";
            dataGridView1.Columns[6].HeaderText = "ФИО владельца";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            string SQL = "Select n_avto,vin,marka,model,god,reg_n,fio_v from Avto where fio_v like N'" + textBox2.Text + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[1].HeaderText = "VIN";
            dataGridView1.Columns[2].HeaderText = "Марка";
            dataGridView1.Columns[3].HeaderText = "Модель";
            dataGridView1.Columns[4].HeaderText = "Год";
            dataGridView1.Columns[5].HeaderText = "Рег. №";
            dataGridView1.Columns[6].HeaderText = "ФИО владельца";
        }
    }
}
