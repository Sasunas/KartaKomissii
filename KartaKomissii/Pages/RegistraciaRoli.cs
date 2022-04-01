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
using Commission_map.Classes;

namespace Commission_map.Pages
{
    public partial class RegistraciaRoli : Form
    {
        Modules modules = new Modules();
        public RegistraciaRoli()
        {
            InitializeComponent();
            Load_Role();
        }

        public void Load_Role()
        {
            string _command = "SELECT * FROM [Роли]";
            modules.Reader(_command, out SqlDataReader _reader);
            while (_reader.Read())
            {
                comboBox1.Items.Add(_reader[1].ToString().Trim());
            }
            _reader.Close();
            _command = "SELECT * FROM [Сотрудник]";
            modules.Reader(_command, out _reader);
            while (_reader.Read())
            {
                comboBox2.Items.Add(_reader[1].ToString().Trim() + " " + _reader[2].ToString().Trim() + " " + _reader[3].ToString().Trim());
            }
            _reader.Close();
            _command = "SELECT * FROM [Карта комиссии]";
            modules.Reader(_command, out _reader);
            while (_reader.Read())
            {
                comboBox3.Items.Add(_reader[0].ToString().Trim());
            }
            _reader.Close();
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            try
            {
                //Проверка существования Сотрудника у Роли в текущей карте
                string _command = "SELECT * FROM [Роль в текущей карте] WHERE ID_Карты_комиссии = '" + (Convert.ToInt32(comboBox3.SelectedIndex.ToString()) + 1) + "'" +
                                                                           " AND ID_Сотрудника = '" + (Convert.ToInt32(comboBox2.SelectedIndex.ToString()) + 1) + "'";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    MessageBox.Show("Сотрудник уже существует в данной Карте комиссии");
                }
                else
                {
                    //Наполнение Роли в текущей карте
                    _command = "INSERT INTO [Роль в текущей карте] (ID_Карты_комиссии,ID_Сотрудника, ID_Роли) VALUES('" + (Convert.ToInt32(comboBox3.SelectedIndex.ToString()) + 1) + "'" +
                                                                            ", '" + (Convert.ToInt32(comboBox2.SelectedIndex.ToString()) + 1) + "'" +
                                                                            ", '" + (Convert.ToInt32(comboBox1.SelectedIndex.ToString()) + 1) + "')";
                    modules.Command(_command);
                }
                _reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
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

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaKarty registraciaKarty = new RegistraciaKarty();
            this.Hide();
            registraciaKarty.ShowDialog();
        }
    }
}
