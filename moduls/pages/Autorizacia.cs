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

namespace moduls
{
    public partial class Autorizacia : Form
    {
        public string sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Autorizacia()
        {
            InitializeComponent();
        }

        private void Avtorizacia_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(sql);
                connection.Open();
                string command = "SELECT * FROM Пароли a LEFT JOIN[Роль в текущей карте] b ON a.ID_Сотрудника = b.ID_Сотрудника" +
                    " LEFT JOIN[Карта комиссии] c ON b.ID_Карты_комиссии = c.ID " +
                    " WHERE a.Логин = '" + textBox1.Text + "' and c.ID_Статуса = 1";
                SqlCommand query = new SqlCommand(command, connection);
                SqlDataReader reader = query.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    classes.PassLogin.ID = Convert.ToInt32(reader[0].ToString());
                    classes.PassLogin.Logins = reader[1].ToString();
                    classes.PassLogin.Passwords = reader[2].ToString();
                    if (textBox2.Text == classes.PassLogin.Passwords)
                    {
                        reader.Close();
                        reader = query.ExecuteReader();
                        while (reader.Read())
                        {
                            int ID_Karta_Komissii = Convert.ToInt32(reader[6].ToString());
                            classes.OcenkaTreb.ID_Karta_Komissii = Convert.ToInt32(reader[6].ToString());
                            classes.RolvKarte.Role = Convert.ToInt32(reader[5].ToString());
                            MessageBox.Show("Вы Авторизованы");
                            if (classes.RolvKarte.Role == 1)
                            {
                                MessageBox.Show("Вы Сотрудник");
                                pages.Sotrydnik2 frm = new pages.Sotrydnik2();
                                this.Hide();
                                frm.Show();
                                break;
                            }
                            else
                            {
                                if (classes.RolvKarte.Role == 2)
                                {
                                    MessageBox.Show("Вы Член Комиссии");
                                    pages.Ocenka2 frm = new pages.Ocenka2();
                                    this.Hide();
                                    frm.Show();
                                    break;
                                }
                                else
                                {
                                    if (classes.RolvKarte.Role == 3)
                                    {
                                        MessageBox.Show("Вы Глава Комиссии");
                                        pages.OcenkaGlavy2 frm = new pages.OcenkaGlavy2();
                                        this.Hide();
                                        frm.Show();
                                        break;
                                    }
                                    else
                                    {
                                        if (classes.RolvKarte.Role == 4)
                                        {
                                            MessageBox.Show("Вы Администратор");
                                            pages.Admin admin = new pages.Admin();
                                            this.Hide();
                                            admin.Show(); ;
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Вы не были добавлены в текущую Карту Комиссии");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный Пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный Логин");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }      
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Можно суда даже не смотреть это потом будет удален(использовалось только для юнит теста)
        public int Avtorizacia_Click1111111(string A, string B)
        {
            SqlConnection connection = new SqlConnection(sql);
            connection.Open();
            string command = "SELECT * FROM Пароли a LEFT JOIN [Роль в текущей карте] b ON a.ID_Сотрудника = b.ID_Сотрудника WHERE a.Логин = '" + A + "'";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            int ret = 0;
            reader.Read();
            if (reader.HasRows == true)
            {
                classes.PassLogin.ID = Convert.ToInt32(reader[0].ToString());
                classes.PassLogin.Logins = reader[1].ToString();
                classes.PassLogin.Passwords = reader[2].ToString();
                classes.RolvKarte.IDOcenkaSotrydnika = Convert.ToInt32(reader[3].ToString());
                classes.RolvKarte.Role = Convert.ToInt32(reader[5].ToString());
                if ("123" == B)
                {
                    MessageBox.Show("Вы Авторизованы");
                    if (classes.RolvKarte.Role == 1)
                    {
                        ret = 1;
                    }
                    if (classes.RolvKarte.Role == 2)
                    {

                        ret = 2;
                    }
                    if (classes.RolvKarte.Role == 3)
                    {

                        ret = 3;
                    }
                    if (classes.RolvKarte.Role == 4)
                    {

                        ret = 4;
                    }
                }
                else
                {
                    ret = 0;
                }
            }
            else
            {
                ret = 0;
            }
            reader.Close();
            connection.Close();
            return (ret);
        }
    }
}
