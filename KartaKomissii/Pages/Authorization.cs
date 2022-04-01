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
using System.Configuration;
using Commission_map.Classes;

namespace Commission_map
{
    public partial class Autorizacia : Form
    {
        Modules modules = new Modules();
        public Autorizacia()
        {
            InitializeComponent();
        }

        private void Avtorizacia_Click(object sender, EventArgs e)
        {
            try
            {
                string _command = "SELECT * FROM Пароли a LEFT JOIN[Роль в текущей карте] b ON a.ID_Сотрудника = b.ID_Сотрудника" +
                    " LEFT JOIN[Карта комиссии] c ON b.ID_Карты_комиссии = c.ID " +
                    " WHERE a.Логин = '" + textBox1.Text + "' and c.ID_Статуса = 1";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    if (int.TryParse(_reader[0].ToString(), out int value))
                    {
                        Classes.PassLogin.ID = value;
                    }
                    Classes.PassLogin.Logins = _reader[1].ToString();
                    Classes.PassLogin.Passwords = _reader[2].ToString();
                    if (textBox2.Text == Classes.PassLogin.Passwords)
                    {
                        _reader.Close();
                        modules.Reader(_command, out _reader);
                        while (_reader.Read())
                        {
                            if (int.TryParse(_reader[6].ToString(), out value))
                            {
                                Classes.OcenkaTreb.ID_Karta_Komissii = value;
                            }
                            if (int.TryParse(_reader[5].ToString(), out value))
                            {
                                Classes.RolvKarte.Role = value;
                            }
                            MessageBox.Show("Вы Авторизованы");
                            if (Classes.RolvKarte.Role == 1)
                            {
                                MessageBox.Show("Вы Сотрудник");
                                Pages.EvaluationEmployee frm = new Pages.EvaluationEmployee();
                                this.Hide();
                                frm.Show();
                                break;
                            }
                            else
                            {
                                if (Classes.RolvKarte.Role == 2)
                                {
                                    MessageBox.Show("Вы Член Комиссии");
                                    Pages.EvaluationMember frm = new Pages.EvaluationMember();
                                    this.Hide();
                                    frm.Show();
                                    break;
                                }
                                else
                                {
                                    if (Classes.RolvKarte.Role == 3)
                                    {
                                        MessageBox.Show("Вы Глава Комиссии");
                                        Pages.EvaluationGlava frm = new Pages.EvaluationGlava();
                                        this.Hide();
                                        frm.Show();
                                        break;
                                    }
                                    else
                                    {
                                        if (Classes.RolvKarte.Role == 4)
                                        {
                                            MessageBox.Show("Вы Администратор");
                                            Pages.Admin admin = new Pages.Admin();
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
                _reader.Close();
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

        //Можно суда даже не смотреть это потом будет удалено(использовалось только для юнит теста)
        public int Avtorizacia_Click1111111(string A, string B)
        {
            SqlConnection connection = new SqlConnection(Classes.PassLogin.connectionString[0].ToString());
            connection.Open();
            string command = "SELECT * FROM Пароли a LEFT JOIN [Роль в текущей карте] b ON a.ID_Сотрудника = b.ID_Сотрудника WHERE a.Логин = '" + A + "'";
            SqlCommand query = new SqlCommand(command, connection);
            SqlDataReader reader = query.ExecuteReader();
            int ret = 0;
            reader.Read();
            if (reader.HasRows == true)
            {
                if (int.TryParse(reader[0].ToString(), out int value))
                {
                    Classes.PassLogin.ID = value;
                }
                Classes.PassLogin.Logins = reader[1].ToString();
                Classes.PassLogin.Passwords = reader[2].ToString();
                if (int.TryParse(reader[3].ToString(), out value))
                {
                    Classes.RolvKarte.IDOcenkaSotrydnika = value;
                }           
                if (int.TryParse(reader[5].ToString(), out value))
                {
                    Classes.RolvKarte.Role = value;
                }               
                if ("123" == B)
                {
                    MessageBox.Show("Вы Авторизованы");
                    if (Classes.RolvKarte.Role == 1)
                    {
                        ret = 1;
                    }
                    if (Classes.RolvKarte.Role == 2)
                    {
                        ret = 2;
                    }
                    if (Classes.RolvKarte.Role == 3)
                    {
                        ret = 3;
                    }
                    if (Classes.RolvKarte.Role == 4)
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
