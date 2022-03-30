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
    public partial class RedactirovanieSotr : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RedactirovanieSotr()
        {
            InitializeComponent();
        }

        public void Sotrud_Load()
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Sotrud.Items.Add(reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim());
            }
            reader.Close();
            connection.Close();
        }

        private void Redact_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "UPDATE FROM [Сотрудник] SET Фамилия = '"+ familia.Text + "', Имя = '" + name.Text + "'," +
                             " Отчество = '" + otchestvo.Text + "' WHERE ID = " + (Sotrud.SelectedIndex + 1) + " ";
            SqlCommand query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            command = "UPDATE FROM [Пароли] SET Логин = '" + password.Text + "', Пароль = '" + login.Text + "'" +
                      " WHERE ID_Сотрудника = " + (Sotrud.SelectedIndex + 1) + "";
            query = new SqlCommand(command, connection);
            query.ExecuteNonQuery();
            connection.Close();
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник] a left join [Пароли] b on a.ID = b.ID_Сотрудника WHERE ID = " + (Sotrud.SelectedIndex + 1) + "";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            familia.Text = reader[1].ToString();
            name.Text = reader[2].ToString();
            otchestvo.Text = reader[3].ToString();
            password.Text = reader[5].ToString();
            login.Text = reader[6].ToString();
            reader.Close();
            connection.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Pages.Admin();
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
