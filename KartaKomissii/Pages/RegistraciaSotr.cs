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
    public partial class RegistraciaSotr : Form
    {
        private static IntPtr handle;
        Modules modules = new Modules(handle);
        public RegistraciaSotr()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            int value;
            //Рассчёт длины Сотрудников
            string _command = "SELECT COUNT(*) FROM [Сотрудник]";
            modules.Reader(_command, out SqlDataReader _reader);
            _reader.Read();
            int count = 0;
            if (int.TryParse(_reader[0].ToString(), out value))
            {
                count = value;
            }
            _reader.Close();
            //Наполнение Сотрудников
            _command = "INSERT INTO [Сотрудник] (ID,Фамилия,Имя,Отчество) VALUES(" + (count + 1) + ", '" + lastname.Text + "', '" + name.Text
                                                                                          + "', '" + otchestvo.Text + "')";
            modules.Command(_command);
            //Рассчёт длины Паролей
            _command = "SELECT COUNT(*) FROM [Пароли]";
            modules.Reader(_command, out _reader);
            _reader.Read();
            if (int.TryParse(_reader[0].ToString(), out value))
            {
                count = value;
            }
            _reader.Close();
            // Наполнение Паролей
            _command = "INSERT INTO [Пароли] (ID_Сотрудника, Логин, Пароль) VALUES(" + (count + 1) + ",'" + login.Text + "','" + password.Text + "')";
            modules.Command(_command);
            MessageBox.Show("Сотрудник был успешно зарегистрирован");
        }
        
        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaRoli registraciaRoli = new RegistraciaRoli();
            this.Hide();
            registraciaRoli.ShowDialog();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaKarty registraciaKarty = new RegistraciaKarty();
            this.Hide();
            registraciaKarty.ShowDialog();
        }
    }
}
