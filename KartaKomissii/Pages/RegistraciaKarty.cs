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
    public partial class RegistraciaKarty : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public RegistraciaKarty()
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
                comboBox1.Items.Add(reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim());
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
                //Рассчёт длины Карта комиссии
                string command = "SELECT COUNT(*) FROM [Карта комиссии]";
                SqlCommand query = new SqlCommand(command, connection);
                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                int count = Convert.ToInt32(reader[0].ToString());
                reader.Close();
                //Наполнение Карта комиссии
                command = "INSERT INTO [Карта комиссии] (ID,ID_Сотрудника, Дата начала, Дата конца) VALUES(" + (count + 1) + ",'" + comboBox1.Text + "','" + dateTimePicker1.Value
                                                                                              + "','" + dateTimePicker2.Value + "')";
                query = new SqlCommand(command, connection);
                query.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(""+exp);
            }  
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.Admin admin = new Admin();
            this.Hide();
            admin.ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaSotr registraciaSotr = new RegistraciaSotr();
            this.Hide();
            registraciaSotr.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pages.RegistraciaRoli registraciaRoli = new RegistraciaRoli();
            this.Hide();
            registraciaRoli.ShowDialog();
        }
    }
}
