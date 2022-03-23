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
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][1] = reader[0].ToString().Trim();
                data[data.Count - 1][2] = reader[1].ToString().Trim();
                data[data.Count - 1][3] = reader[2].ToString().Trim();
                data[data.Count - 1][4] = reader[3].ToString().Trim();
            }
            reader.Close();
            connection.Close();
            foreach (string[] s in data)
            {
                dataGridView2.Rows.Add(s);
            }
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
            string message = "Вы уверены, что хотите удалить строчку?";
            string caption = "Удалить строчку";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string command = "DELETE FROM " + viewTableCommandNow + " = '" + Convert.ToInt32(deletedLineNumber.Text) + "'";
                addFunction(command);
                command = viewTableUpdate + Convert.ToInt32(deletedLineNumber.Text);
                addFunction(command);
                if (radioButton1.Checked == true) radioButton1_CheckedChanged(sender, e);
                if (radioButton2.Checked == true) radioButton2_CheckedChanged(sender, e);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string command = "SELECT * FROM [Сотрудник]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string command = "SELECT * FROM [Карта комиссии]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            ViewFunction(command, lastIdCheck, getTableName);
        }

        public void ViewFunction(string command, string lastIdCheck, string getTableName)
        {
            int i;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
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
                this.dataGridView2.Columns.Add(column);
                dataGridView2.Columns[i].HeaderText = reader[0].ToString().Trim();
                i++;
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridView2.Rows.Add(s);
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
    }
}
