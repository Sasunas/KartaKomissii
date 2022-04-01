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

    public partial class RedactirovanieKarty : Form
    {
        Modules modules = new Modules();
        public RedactirovanieKarty()
        {
            InitializeComponent();
            Karty_Load();
        }

        public void Karty_Load()
        {
            // 
            string _command = "SELECT * FROM [Карта комиссии]";
            modules.Reader(_command, out SqlDataReader _reader);
            while (_reader.Read())
            {
                Karta.Items.Add(_reader[0].ToString().Trim());
            }
            _reader.Close();
            _command = "SELECT * FROM [Статус]";
            modules.Reader(_command, out _reader);
            while (_reader.Read())
            {
                status.Items.Add(_reader[0].ToString().Trim());
            }
            _reader.Close();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            string _command = "UPDATE FROM [Карта комиссии] SET ID_Сотрудник = '" + textBox2.Text + "', Дата начала = '" + dateTimePicker1.Value + "'" +
                             ", Дата конца = '" + dateTimePicker2.Value + "', Статус = '" + status.SelectedIndex.ToString() + "'" +
                             " WHERE ID = " + (Karta.SelectedIndex + 1) + " ";
            modules.Command(_command);
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {

            string _command = "SELECT * FROM [Карта комиссии] WHERE ID = " + (Karta.SelectedIndex + 1) + "";
            modules.Reader(_command, out SqlDataReader _reader);
            _reader.Read();
            textBox2.Text = _reader[1].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(_reader[2].ToString());
            dateTimePicker2.Value = Convert.ToDateTime(_reader[3].ToString());
            status.SelectedIndex = Convert.ToInt32(_reader[5].ToString()) + 1;
            _reader.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Pages.Admin();
            this.Hide();
            admin.ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RedactirovanieSotr redactirovanieSotr = new Pages.RedactirovanieSotr();
            this.Hide();
            redactirovanieSotr.ShowDialog();
        }
    }
}
