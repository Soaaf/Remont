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

    public partial class Sotr : Form
    {
       private Excel.Application excel_app;
        string nmas;

        public Sotr()
        {
            InitializeComponent();

        }

        private void Sotr_Activated(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string); connection1.Open();

            string SQL = "Select n_mast, fio, dolg from MASTER";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "№ мастера";
            dataGridView1.Columns[0].Width = 100;
            connection1.Close();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            nmas = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            button3.Enabled = false;
            button1.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE MASTER set fio=N'" + textBox1.Text +
                            "', dolg=N'" + textBox2.Text + "' WHERE n_mast=" + nmas;

            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();
            MessageBox.Show("Данные изменены");
            this.Activate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string SQL_dob = "SELECT max(n_mast) as max FROM MASTER";

            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            SqlCommand command1 = new SqlCommand(SQL_dob, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            string max = "";
            int max2 = 0;
            while (dr.Read())
            {
                max = string.Format("{0}", dr["max"]);
            }
            dr.Close();
            connection1.Close();
            if (max == "") { max2 = 1; }
            else { max2 = Convert.ToInt32(max) + 1; }
            max = Convert.ToString(max2);

            SQL_dob = "INSERT INTO MASTER(n_mast,fio,dolg) values (" + max + ", N'" + textBox1.Text +
                "', N'" + textBox2.Text + "')";

            connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            command1 = new SqlCommand(SQL_dob, connection1);
            dr = command1.ExecuteReader();
            dr.Close();
            connection1.Close();
            MessageBox.Show("Данные сохранены");
            this.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            excel_app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            excel_app.Workbooks.Add(Type.Missing);

            Excel.Range _excelCells = (Excel.Range)excel_app.get_Range("A1", "C1").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A2", "C2").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A3", "C3").Cells;
            excel_app.Cells[1, 1].Value = "Список сотрудников" + " " + DateTime.Now.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
            excel_app.Cells[1, 1].Font.Bold = true;
            excel_app.Cells[1, 1].Font.Italic = true;
            excel_app.Cells[1, 1].Font.Size = 14;
            excel_app.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excel_app.Cells[3, 1].Value = "№";
            excel_app.Columns[1].columnwidth = 3;
            excel_app.Cells[3, 1].Font.Size = 14;
            excel_app.Cells[3, 1].Font.Italic = true;
            excel_app.Cells[3, 1].Font.Bold = true;
            excel_app.Cells[3, 1].Borders.LineStyle = 1;
            excel_app.Cells[3, 1].Borders.Weight = Excel.XlBorderWeight.xlThick;
            excel_app.Cells[3, 2].Value = "ФИО работника";
            excel_app.Columns[2].columnwidth = 30;
            excel_app.Cells[3, 2].Font.Size = 14;
            excel_app.Cells[3, 2].Font.Italic = true;
            excel_app.Cells[3, 2].Font.Bold = true;
            excel_app.Cells[3, 2].Borders.LineStyle = 1;
            excel_app.Cells[3, 2].Borders.Weight = Excel.XlBorderWeight.xlThick;
            excel_app.Cells[3, 3].Value = "Должность";
            excel_app.Columns[3].columnwidth = 30;
            excel_app.Cells[3, 3].Font.Size = 14;
            excel_app.Cells[3, 3].Font.Italic = true;
            excel_app.Cells[3, 3].Font.Bold = true;
            excel_app.Cells[3, 3].Borders.LineStyle = 1;
            excel_app.Cells[3, 3].Borders.Weight = Excel.XlBorderWeight.xlThick;
            string SQL_text = "SELECT * From Master";
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand comm = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = comm.ExecuteReader();
            int i = 4;
           
            while (dr.Read())
            {
                excel_app.Cells[i, 1].Value = i - 3;
                excel_app.Cells[i, 1].Font.Size = 14;
                excel_app.Cells[i, 1].Borders.LineStyle = 1;
                excel_app.Cells[i, 2].Value = String.Format("{0}", dr["fio"]);
                excel_app.Cells[i, 2].Font.Size = 14;
                excel_app.Cells[i, 2].Borders.LineStyle = 1;
                excel_app.Cells[i, 3].Value = String.Format("{0}", dr["dolg"]);
                excel_app.Cells[i, 3].Font.Size = 14;
                excel_app.Cells[i, 3].Borders.LineStyle = 1;
                Excel.Range curr_cells = (Excel.Range)excel_app.get_Range("A" + i, "C" + i).Cells;
                i = i + 1;

            }
            dr.Close();
            con1.Close();

        }
    }

}
