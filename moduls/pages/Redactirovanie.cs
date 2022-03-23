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
    public partial class Redactirovanie : Form
    {
        public static string sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Redactirovanie()
        {
            InitializeComponent();
        }
        public void Sotrud_Load()
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Sotrud.Items.Add(reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim());
            }
            reader.Close();
        }
        private void Redact_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            string command = "UPDATE FROM [Сотрудник] SET Фамилия = '1', Имя = '1', Отчество = '1'";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
