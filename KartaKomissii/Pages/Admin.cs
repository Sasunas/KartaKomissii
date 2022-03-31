﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Commission_map.Pages
{
    public partial class Admin : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
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
            Pages.RegistraciaSotr registracia = new RegistraciaSotr();
            this.Hide();
            registracia.ShowDialog();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            Pages.RedactirovanieSotr redactirovanie = new Pages.RedactirovanieSotr();
            this.Hide();
            redactirovanie.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string viewTableNow = "";
            string message = "Вы уверены, что хотите удалить строку?";
            string caption = "Удалить строку";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (sotr.Checked == true)
                {
                    //Удаление сотрудника со связанными данными в иных таблицах
                    viewTableNow = "Сотрудник";
                    string command = "DELETE FROM Пароли WHERE ID_Сотрудника = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                    AddFunction(command);
                    command = "DELETE FROM [Роль в текущей карте] WHERE ID_Сотрудника = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                    AddFunction(command);
                    command = "SELECT * FROM [Карта комиссии] WHERE ID_Сотрудника = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                    SqlConnection connection = new SqlConnection(Sql);
                    connection.Open();
                    SqlCommand query = new SqlCommand(command, connection);
                    SqlDataReader reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        command = "DELETE FROM [Оценка по требованию] WHERE ID_Карта_комиссии = '" + reader[0].ToString() + "'";
                        AddFunction(command);
                    }
                    connection.Close();
                    reader.Close();
                    command = "DELETE FROM [Карта комиссии] WHERE ID_Сотрудника = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                    AddFunction(command);
                    command = "DELETE FROM [" + viewTableNow + "] WHERE ID = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                    AddFunction(command);
                }
                else
                {
                    // Удаление роли в карте комиссии
                    if (roli.Checked == true)
                    {
                        viewTableNow = "Роль в текущей карте";
                        string command = "DELETE FROM [" + viewTableNow + "] WHERE ID = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                        AddFunction(command);
                    }
                    else
                    {
                        // Удаление карты комиссии со связанными данными в таблице Оценка по требованию
                        if (karty.Checked == true)
                        {
                            MessageBox.Show("Карту комисси удалять не стоит.");
                            viewTableNow = "Карта комиссии";
                            string command = "DELETE FROM Оценка по требованию WHERE ID_Карта_комиссии = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                            AddFunction(command);
                            command = "DELETE FROM [" + viewTableNow + "] WHERE ID = '" + (Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString()) + 1) + "'";
                            AddFunction(command);
                        }
                    }
                }
                // обновление отображаемых данных
                if (sotr.Checked == true) Sotr_CheckedChanged(sender, e);
                if (sotr.Checked == true) Roli_CheckedChanged(sender, e);
                if (karty.Checked == true) Karty_CheckedChanged(sender, e);
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Autorizacia frm = new Autorizacia();
            this.Close();
            frm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sotr_CheckedChanged(object sender, EventArgs e)
        {
            Form admin = new Form();
            string command = "SELECT * FROM [Сотрудник]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Сотрудник'";
            ViewFunction(command, lastIdCheck, getTableName);
            dataGridView1.Size = new Size(460, 135);
            Size = new Size(615, 240);
        }

        private void Roli_CheckedChanged(object sender, EventArgs e)
        {
            Form admin = new Form();
            string command = "SELECT * FROM [Роль в текущей карте]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Роль в текущей карте'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Роль в текущей карте'";
            ViewFunction(command, lastIdCheck, getTableName);
            dataGridView1.Size = new Size(345, 135);
            Size = new Size(500, 240);
        }

        private void Karty_CheckedChanged(object sender, EventArgs e)
        {
            Form admin = new Form();
            string command = "SELECT * FROM [Карта комиссии]";
            string lastIdCheck = "SELECT COUNT(*)FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            string getTableName = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Карта комиссии'";
            ViewFunction(command, lastIdCheck, getTableName);
            dataGridView1.Size = new Size(650,135);
            Size = new Size(805, 240);
        }

        public void ViewFunction(string command, string lastIdCheck, string getTableName)
        {
            int i;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            SqlConnection sqlConnection = new SqlConnection(Sql);
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

        public void AddFunction(string command)
        {
            SqlConnection sqlConnection = new SqlConnection(Sql);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.SelectedRows[0].Index.ToString());
            MessageBox.Show(""+row);
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