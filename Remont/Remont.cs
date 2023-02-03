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
    public partial class Remont : Form
    {
        string nmas;
        public Remont()
        {
            InitializeComponent();
        }

        

       

        private void button3_Click(object sender, EventArgs e)
        {
            AddAvto newForm = new AddAvto();
            newForm.Show();
        }


        private void comboBox1_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string); connection1.Open();
            string SQL = "Select n_mast, fio, dolg from Master";
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "n_mast";
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string); 
            connection1.Open();
            string SQL = "Select n_usl, naimen, stoim from Uslugi";
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            comboBox2.DataSource = tb;
            comboBox2.DisplayMember = "naimen";
            comboBox2.ValueMember = "n_usl";
        }

        private void Remont_Activated(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string); 
            connection1.Open();

            string SQL = "Select n_avto,vin,marka,model,god,reg_n,fio_v from Avto";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "№ услуги";
            dataGridView1.Columns[0].Width = 100;
            connection1.Close();
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
