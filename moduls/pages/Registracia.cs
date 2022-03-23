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

namespace moduls.pages
{
    public partial class Registracia : Form
    {
        public static string sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Registracia()
        {
            InitializeComponent();
            Load_Role();
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            //Рассчёт длины Сотрудников
            string command = "SELECT COUNT(*) FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            int count = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            //Наполнение Сотрудников
            command = "INSERT INTO [Сотрудник] (ID,Фамилия,Имя,Отчество,Паспорт) VALUES(" + (count + 1) + ",'" + textBox1.Text + "','" + textBox2.Text
                                                                                          + "','" + textBox3.Text + "'," + textBox4.Text + ")";
            query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            //Рассчёт длины Паролей
            command = "SELECT COUNT(*) FROM [Пароли]"; 
            query = new SqlCommand(command, connection);
            reader = query.ExecuteReader();
            reader.Read();
            count = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            // Наполнение Паролей
            command = "INSERT INTO [Пароли] (ID_Сотрудника, Логин, Пароль) VALUES(" + (count + 1) + ",'" + textBox5.Text + "','" + textBox6.Text + "')";
            query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            // Рассчёт длины роли Сотрудника
            command = "SELECT COUNT(*) FROM [Роли_Сотрудников]";
            query = new SqlCommand(command, connection);
            reader = query.ExecuteReader();
            reader.Read();
            count = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            // Наполнение Паролей
            command = "INSERT INTO [Роли_Сотрудников] (ID_Сотрудники, ID_Роли) VALUES(" + (count + 1) + "," + Convert.ToInt32(comboBox1.SelectedItem) + ")";
            query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            MessageBox.Show("Сотрудник был успешно зарегистрирован");
        }
        public void Load_Role()
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            string command = "SELECT * FROM [Роли]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1].ToString().Trim());
            }
            reader.Close();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            pages.Admin admin = new Admin();
            this.Close();
            admin.ShowDialog();
        }
    }
}
