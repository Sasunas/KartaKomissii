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
    public partial class RegistraciaRoli : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RegistraciaRoli()
        {
            InitializeComponent();
            Load_Role();
        }

        public void Load_Role()
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Роли]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1].ToString().Trim());
            }
            reader.Close();
            command = "SELECT * FROM [Сотрудник]";
            query = new SqlCommand(command, connection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim());
            }
            reader.Close();
            command = "SELECT * FROM [Карта комиссии]";
            query = new SqlCommand(command, connection);
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader[0].ToString().Trim());
            }
            reader.Close();
            connection.Close();
        }

        private void Regist_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(Sql);
                connection.Open();
                //Проверка существования Сотрудника у Роли в текущей карте
                string command = "SELECT * FROM [Роль в текущей карте] WHERE ID_Карты_комиссии = '" + comboBox3.Text + "'" +
                                                                           " AND ID_Сотрудника = '" + comboBox2.Text + "'";
                SqlCommand query = new SqlCommand(command, connection);
                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    MessageBox.Show("Сотрудник уже существует в данной Карте комиссии");
                }
                else
                {
                    //Наполнение Роли в текущей карте
                    command = "INSERT INTO [Роль в текущей карте] (ID_Карты_комиссии,ID_Сотрудника, ID_Роли) VALUES('" + comboBox3.Text + "'" +
                                                                            ", '" + comboBox2.Text + "', '" + comboBox1.Text + "')";
                    query = new SqlCommand(command, connection);
                    query.ExecuteNonQuery();
                    connection.Close();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Admin();
            this.Close();
            admin.ShowDialog();
        }
    }
}
