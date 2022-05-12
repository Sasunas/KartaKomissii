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
    public partial class RedactirovanieSotr : Form
    {
        private static IntPtr handle;
        Modules modules = new Modules(handle);
        public RedactirovanieSotr()
        {
            InitializeComponent();
            Sotrud_Load();
        }


        public void Sotrud_Load()
        {
            string _command = "SELECT * FROM [Сотрудник]";
            modules.Reader(_command, out SqlDataReader _reader);
            while (_reader.Read())
            {
                Sotrud.Items.Add(_reader[1].ToString().Trim() + " " + _reader[2].ToString().Trim() + " " + _reader[3].ToString().Trim());
            }
            _reader.Close();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            string _command = "UPDATE [Сотрудник] SET [Фамилия] = '"+ familia.Text + "', [Имя] = '" + name.Text + "'," +
                             " [Отчество] = '" + otchestvo.Text + "' WHERE ID = " + (Sotrud.SelectedIndex + 1) + " ";
            modules.Command(_command);
            _command = "UPDATE [Пароли] SET [Логин] = '" + login.Text + "', [Пароль] = '" + password.Text + "'" +
                      " WHERE ID_Сотрудника = " + (Sotrud.SelectedIndex + 1) + "";
            modules.Command(_command);
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _command = "SELECT * FROM [Сотрудник] a left join [Пароли] b on a.ID = b.ID_Сотрудника WHERE ID = " + (Sotrud.SelectedIndex + 1) + "";
            modules.Reader(_command, out SqlDataReader _reader);
            _reader.Read();
            familia.Text = _reader[1].ToString();
            name.Text = _reader[2].ToString();
            otchestvo.Text = _reader[3].ToString();
            login.Text = _reader[5].ToString();
            password.Text = _reader[6].ToString();
            _reader.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.CommissionLeader admin = new Pages.CommissionLeader();
            this.Hide();
            admin.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RedactirovanieKarty redactirovanieKarty = new Pages.RedactirovanieKarty();
            this.Hide();
            redactirovanieKarty.ShowDialog();
        }
    }
}
