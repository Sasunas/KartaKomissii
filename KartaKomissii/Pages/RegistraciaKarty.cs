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
using Commission_map.Classes;

namespace Commission_map.Pages
{
    public partial class RegistraciaKarty : Form
    {
        Modules modules = new Modules();
        public RegistraciaKarty()
        {
            InitializeComponent();
            Load_Sotr();
        }

        public void Load_Sotr()
        { 
            string _command = "SELECT * FROM [Сотрудник]";
            modules.Reader(_command, out SqlDataReader _reader);
            while (_reader.Read())
            {
                comboBox1.Items.Add(_reader[1].ToString().Trim() + " " + _reader[2].ToString().Trim() + " " + _reader[3].ToString().Trim());
            }
            _reader.Close();
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            try
            {
                //Рассчёт длины Карта комиссии
                string _command = "SELECT COUNT(*) FROM [Карта комиссии]";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                int count = Convert.ToInt32(_reader[0].ToString());
                _reader.Close();
                //Наполнение Карта комиссии
                _command = "INSERT INTO [Карта комиссии] (ID,ID_Сотрудника, Дата начала, Дата конца) VALUES(" + (count + 1) + ",'" + comboBox1.Text + "','" + dateTimePicker1.Value
                                                                                              + "','" + dateTimePicker2.Value + "')";
                modules.Command(_command);
            }
            catch(Exception exp)
            {
                MessageBox.Show(""+exp);
            }  
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaSotr registraciaSotr = new RegistraciaSotr();
            this.Hide();
            registraciaSotr.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaRoli registraciaRoli = new RegistraciaRoli();
            this.Hide();
            registraciaRoli.ShowDialog();
        }
    }
}
