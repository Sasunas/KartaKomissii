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
    public partial class RedactirovanieSotr : Form
    {
        public static string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
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
            string command = "UPDATE FROM [Сотрудник] SET Фамилия = '"+ textBox1.Text + "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "' WHERE ID = " + (Sotrud.SelectedIndex + 1) + " ";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            command = "UPDATE FROM [Пароли] SET Логин = '" + textBox5.Text + "', Пароль = '" + textBox6.Text + "' WHERE ID_Сотрудника = " + (Sotrud.SelectedIndex + 1) + "";
            query = new SqlCommand(command, connection);
            reader = query.ExecuteReader();
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
            textBox1.Text = reader[1].ToString();
            textBox2.Text = reader[2].ToString();
            textBox3.Text = reader[3].ToString();
            textBox5.Text = reader[5].ToString();
            textBox6.Text = reader[6].ToString();
            reader.Close();
            connection.Close();
        }
    }
}
