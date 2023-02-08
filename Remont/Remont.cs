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
using Excel = Microsoft.Office.Interop.Excel;

namespace Remont
{
    public partial class Remont : Form
    {
        private Excel.Application excel_app;
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

        private void Remont_Load(object sender, EventArgs e)
        {
            string SQL_izm = "Select max(n_z_n) AS max from Remont";
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            string max = " ";
            int max2 = 0;
            while (dr.Read())
            {
                max = (String.Format("{0}", dr["max"]));
            }
            dr.Close();
            connection1.Close();
            if (max == "") { max2 = 1; }
            else max2 = Convert.ToInt32(max) + 1;
            max = Convert.ToString(max2);
            label9.Text = max;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox3.Text = "1";
            string SQL = "Select stoim from Uslugi Where n_usl= " + comboBox2.SelectedValue;
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlCommand com1 = new SqlCommand(SQL, connection1);
            SqlDataReader dr = com1.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = (string.Format("{0}", dr["stoim"]));
            }
            label8.Text = Convert.ToString(Convert.ToDouble(label7.Text) * Convert.ToDouble(textBox3.Text));
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label8.Text = Convert.ToString(Convert.ToDouble(label7.Text) * Convert.ToDouble(textBox3.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string SQL_izm = "Select max(id) AS max From Remont";
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            string max = " ";
            int max2 = 0;
            while (dr.Read())
            {
                max = (String.Format("{0}", dr["max"]));
            }
            dr.Close();
            connection1.Close();
            if (max == "") { max2 = 1; }
            else max2 = Convert.ToInt32(max) + 1;
            max = Convert.ToString(max2);
            string n_avto = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            SQL_izm = "Insert into Remont (id, n_avto, n_usl, n_mast, data, kol, n_z_n, sum) "
                + "values (" + max + ", " + n_avto
                + ", " + Convert.ToString(comboBox2.SelectedValue) + ", "
                + Convert.ToString(comboBox1.SelectedValue) + ", '"
                + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', " + textBox3.Text + "," + label9.Text + ", " + label8.Text + ")";
            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr1 = command1.ExecuteReader();
            dr1.Close();
            connection1.Close();
            MessageBox.Show("Данные сохранены");
            String SQL = "Select r.id, m.fio, u.naimen, u.stoim, r.kol, u.stoim*r.kol"
                + " from remont r, uslugi u, master m where "
                + " r.n_usl=u.n_usl and m.n_mast=r.n_mast and r.n_z_n=" + label9.Text;
            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb1 = new DataTable();
            adapter.Fill(tb1);
            dataGridView2.Refresh();
            dataGridView2.DataSource = tb1;
            dataGridView2.Columns[0].HeaderText = "№";
            dataGridView2.Columns[1].HeaderText = "Мастер";
            dataGridView2.Columns[2].HeaderText = "Услуга";
            dataGridView2.Columns[3].HeaderText = "Цена";
            dataGridView2.Columns[4].HeaderText = "Количество";
            dataGridView2.Columns[5].HeaderText = "Сумма";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            label7.Text = " ";
            label8.Text = " ";
            textBox3.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
            string SQL_izm = "Delete from Remont Where id=" + id;
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            dr.Close();
            connection1.Close();
            this.Activate();
            MessageBox.Show("Данные удалены");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string SQL_izm = "Select max(n_z_n) AS max from Remont";
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            string max = " ";
            int max2 = 0;
            while (dr.Read())
            {
                max = (String.Format("{0}", dr["max"]));
            }
            dr.Close();
            connection1.Close();
            if (max == "") { max2 = 1; }
            else max2 = Convert.ToInt32(max) + 1;
            max = Convert.ToString(max2);
            label9.Text = max;
            String SQL = "Select r.id, m.fio, u.naimen, u.stoim, r.kol, u.stoim*r.kol"
                + " from remont r, uslugi u, master m where "
                + " r.n_usl=u.n_usl and m.n_mast=r.n_mast and r.n_z_n=" + label9.Text;
            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "№ мастера";
            dataGridView1.Columns[0].Width = 100;
            connection1.Close();
            SQL = "Select r.n_z_n, r.data, sum(sum) from Remont r Group by r.n_z_n, r.data";
            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();
            adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb1 = new DataTable();
            adapter.Fill(tb1);
            dataGridView3.Refresh();
            dataGridView3.DataSource = tb;
            dataGridView3.Columns[0].HeaderText = "№";
            dataGridView3.Columns[1].HeaderText = "Дата";
            dataGridView3.Columns[2].HeaderText = "Сумма";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            excel_app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            excel_app.Workbooks.Add(Type.Missing);

            Excel.Range _excelCells = (Excel.Range)excel_app.get_Range("A1", "F1").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A2", "F2").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A3", "F3").Cells;
            excel_app.Cells[1, 1].Value = "Заказ-наряд № " + label9.Text + " от " + dateTimePicker1.Value.ToString("MM/dd/yyyy");
            excel_app.Cells[1, 1].Font.Bold = true;
            excel_app.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            excel_app.Cells[2, 1].Value = "Исполнитель: Техцентр AVTO, ИНН 26311001412544, тел.: 7-77-77";
            excel_app.Cells[3, 1].Value = "Заказчик: " + dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
            excel_app.Cells[4, 1].Value = "Модель: " + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() +
                 " " + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            
            excel_app.Cells[9, 1].Value = "№";
            excel_app.Columns[1].columnwidth = 3;
            excel_app.Cells[9, 1].Font.Size = 14;
            excel_app.Cells[9, 1].Font.Italic = true;
            excel_app.Cells[9, 1].Font.Bold = true;
            excel_app.Cells[9, 1].Borders.LineStyle = 1;
            excel_app.Cells[9, 1].Borders.Weight = Excel.XlBorderWeight.xlThick;

            excel_app.Cells[9, 2].Value = "Наименование работы";
            excel_app.Columns[2].columnwidth = 30;
            excel_app.Cells[9, 2].Font.Size = 14;
            excel_app.Cells[9, 2].Font.Italic = true;
            excel_app.Cells[9, 2].Font.Bold = true;
            excel_app.Cells[9, 2].Borders.LineStyle = 1;
            excel_app.Cells[9, 2].Borders.Weight = Excel.XlBorderWeight.xlThick;

            excel_app.Cells[9, 3].Value = "ФИО работника";
            excel_app.Columns[3].columnwidth = 30;
            excel_app.Cells[9, 3].Font.Size = 14;
            excel_app.Cells[9, 3].Font.Italic = true;
            excel_app.Cells[9, 3].Font.Bold = true;
            excel_app.Cells[9, 3].Borders.LineStyle = 1;
            excel_app.Cells[9, 3].Borders.Weight = Excel.XlBorderWeight.xlThick;

            excel_app.Cells[9, 4].Value = "Стоимость";
            excel_app.Columns[4].columnwidth = 30;
            excel_app.Cells[9, 4].Font.Size = 14;
            excel_app.Cells[9, 4].Font.Italic = true;
            excel_app.Cells[9, 4].Font.Bold = true;
            excel_app.Cells[9, 4].Borders.LineStyle = 1;
            excel_app.Cells[9, 4].Borders.Weight = Excel.XlBorderWeight.xlThick;

            excel_app.Cells[9, 5].Value = "Количество";
            excel_app.Columns[5].columnwidth = 30;
            excel_app.Cells[9, 5].Font.Size = 14;
            excel_app.Cells[9, 5].Font.Italic = true;
            excel_app.Cells[9, 5].Font.Bold = true;
            excel_app.Cells[9, 5].Borders.LineStyle = 1;
            excel_app.Cells[9, 5].Borders.Weight = Excel.XlBorderWeight.xlThick;

            excel_app.Cells[9, 6].Value = "Сумма";
            excel_app.Columns[6].columnwidth = 30;
            excel_app.Cells[9, 6].Font.Size = 14;
            excel_app.Cells[9, 6].Font.Italic = true;
            excel_app.Cells[9, 6].Font.Bold = true;
            excel_app.Cells[9, 6].Borders.LineStyle = 1;
            excel_app.Cells[9, 6].Borders.Weight = Excel.XlBorderWeight.xlThick;

            string SQL_text = "SELECT R.id, M.fio, U.naimen, U.stoim, R.kol, U.stoim * R.kol as summa " +
                "FROM REMONT R, USLUGI U, MASTER M WHERE " +
                "R.n_usl = U.n_usl AND M.n_mast = R.n_mast AND R.n_z_n = " + label9.Text;
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand comm = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = comm.ExecuteReader();
            int i = 10;
            decimal itog_summa = 0;
            while (dr.Read())
            {
                excel_app.Cells[i, 1].Value = i - 9;
                excel_app.Cells[i, 2].Value = String.Format("{0}", dr["naimen"]);
                excel_app.Cells[i, 3].Value = String.Format("{0}", dr["fio"]);
                excel_app.Cells[i, 4].Value = String.Format("{0}", dr["stoim"]);
                excel_app.Cells[i, 5].Value = String.Format("{0}", dr["kol"]);
                excel_app.Cells[i, 6].Value = String.Format("{0}", dr["summa"]);

                Excel.Range curr_cells = (Excel.Range)excel_app.get_Range("A" + i, "F" + i).Cells;
                curr_cells.Font.Size = 12;
                curr_cells.Borders.LineStyle = 1;

                itog_summa = itog_summa + Convert.ToDecimal(dr["summa"]);
                i = i + 1;
            }
            dr.Close();
            con1.Close();
            excel_app.Cells[i, 5].Value = "ИТОГО";
            excel_app.Cells[i, 5].Font.Size = 12;
            excel_app.Cells[i, 5].Borders.LineStyle = 1;
            excel_app.Cells[i, 6].Value = itog_summa;
            excel_app.Cells[i, 6].Font.Size = 12;
            excel_app.Cells[i, 6].Borders.LineStyle = 1;


        }
    }
}

