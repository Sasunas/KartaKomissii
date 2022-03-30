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

namespace Commission_map.Pages
{
    public partial class RedactirovanieKarty : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RedactirovanieKarty()
        {
            InitializeComponent();
            Karty_Load();
        }

        public void Karty_Load()
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Карта комиссии]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Karta.Items.Add(reader[0].ToString().Trim());
            }
            reader.Close();
            connection.Close();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "UPDATE FROM [Карта комиссии] SET ID_Сотрудник = '" + textBox2.Text + "', Дата начала = '" + dateTimePicker1.Value + "'" +
                             ", Дата конца = '" + dateTimePicker2.Value + "' WHERE ID = " + (Karta.SelectedIndex + 1) + " ";
            SqlCommand query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Карта комиссии] WHERE ID = " + (Karta.SelectedIndex + 1) + "";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            textBox2.Text = reader[1].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(reader[2].ToString());
            dateTimePicker2.Value = Convert.ToDateTime(reader[3].ToString());
            reader.Close();
            connection.Close();
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
