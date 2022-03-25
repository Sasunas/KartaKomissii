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
    public partial class RegistraciaKarty : Form
    {
        public static string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RegistraciaKarty()
        {
            InitializeComponent();
            Load_Role();
        }

        public void Load_Role()
        {
            SqlConnection connection = new SqlConnection(Sql);
            connection.Open();
            string command = "SELECT * FROM [Сотрудник]";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim());
            }
            reader.Close();
        }

        private void Regist_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            pages.Admin admin = new Admin();
            this.Close();
            admin.ShowDialog();
        }
    }
}
