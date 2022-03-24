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

namespace moduls.pages
{
    public partial class Admin : Form
    {
        public static string sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Admin()
        {
            InitializeComponent();
            Admin_Load();
        }
        public void Admin_Load()
        {
            sotr.Checked = true;
            string command = "SELECT * FROM [Сотрудник]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            pages.Registracia registracia = new Registracia();
            this.Hide();
            registracia.ShowDialog();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            pages.Redactirovanie redactirovanie = new Redactirovanie();
            this.Close();
            redactirovanie.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string viewTableNow = "";
            string message = "Вы уверены, что хотите удалить строчку?";
            string caption = "Удалить строчку";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if(sotr.Checked == true)
            {
                viewTableNow = "Сотрудник";
            } 
            else
            {
                if (roli.Checked == true)
                {
                    viewTableNow = "Роль в текущей карте";
                }
                else
                {
                    if (karty.Checked == true)
                    {
                        viewTableNow = "Карта комиссии";
                    }
                }
            }
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string command = "DELETE FROM " + viewTableNow + " = '" + Convert.ToInt32(dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)) + "'";
                addFunction(command);
                //command = viewTableUpdate + Convert.ToInt32(deletedLineNumber.Text);
                //addFunction(command);
                if (sotr.Checked == true) sotr_CheckedChanged(sender, e);
                if (sotr.Checked == true) roli_CheckedChanged(sender, e);
                if (karty.Checked == true) karty_CheckedChanged(sender, e);
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Autorizacia frm = new Autorizacia();
            this.Hide();
            frm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sotr_CheckedChanged(object sender, EventArgs e)
        {
            string command = "SELECT * FROM [Сотрудник]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        private void roli_CheckedChanged(object sender, EventArgs e)
        {
            string command = "SELECT * FROM [Роль в текущей карте]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Роль в текущей карте'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Роль в текущей карте'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        private void karty_CheckedChanged(object sender, EventArgs e)
        {
            string command = "SELECT * FROM [Карта комиссии]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        public void ViewFunction(string command, string lastIdCheck, string getTableName)
        {
            int i;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            SqlCommand sqlLastIdCheck = new SqlCommand(lastIdCheck, sqlConnection);
            SqlDataReader readerId = sqlLastIdCheck.ExecuteReader();
            readerId.Read();
            int lastId = Convert.ToInt32(readerId[0]);
            readerId.Close();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[lastId]);
                for (i = 0; i < lastId; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString().Trim();
                }
            }
            reader.Close();
            SqlCommand getName = new SqlCommand(getTableName, sqlConnection);
            reader = getName.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                this.dataGridView1.Columns.Add(column);
                dataGridView1.Columns[i].HeaderText = reader[0].ToString().Trim();
                i++;
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
            sqlConnection.Close();
        }

        public void addFunction(string command)
        {
            SqlConnection sqlConnection = new SqlConnection(sql);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
        dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridView1.SelectedRows[0].Index.ToString());
                    sb.Append(", Row2: ");
                    sb.Append(dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected));
                    sb.Append(Environment.NewLine);
                }
                sb.Append("Row: ");
                sb.Append(dataGridView1.SelectedRows[0].Index.ToString());
                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
            }
        }
    }
}
