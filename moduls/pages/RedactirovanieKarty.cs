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
    public partial class RedactirovanieKarty : Form
    {
        public static string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RedactirovanieKarty()
        {
            InitializeComponent();
            Load_Sotr();
        }

        public void Load_Sotr()
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Karta.Items.Add(reader[0].ToString().Trim());
            }
            reader.Close();
            connection.Close();
        }

        private void Sotrud_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник] a left join [Пароли] b on a.ID = b.ID_Сотрудника WHERE ID = " + (Karta.SelectedIndex + 1) + "";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[0].ToString();
            textBox2.Text = reader[1].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(reader[2].ToString());
            dateTimePicker2.Value = Convert.ToDateTime(reader[3].ToString());
            reader.Close();
            connection.Close();
        }

        private void Redact_Click(object sender, EventArgs e)
        {

        }
    }
}
