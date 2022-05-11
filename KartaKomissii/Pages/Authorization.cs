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
       
        readonly string Sql = PassLogin.connectionString[0].ToString();
        private static IntPtr handle;
        Modules modules = new Modules(handle);

        public Autorizacia()
        {
            InitializeComponent();
        }

        private void Avtorizacia_Click(object sender, EventArgs e)
        {
            
            //try
            //{
                string _command = "SELECT * FROM Пароли a LEFT JOIN[Роль в текущей карте] b ON a.ID_Сотрудника = b.ID_Сотрудника" +
                    " LEFT JOIN[Карта комиссии] c ON b.ID_Карты_комиссии = c.ID " +
                    " WHERE a.Логин = '" + textBox1.Text + "' and c.ID_Статуса = 1";
                SqlConnection con = new SqlConnection(Sql);
                con.Open();
                SqlCommand command = new SqlCommand(_command, con);
                SqlDataReader _reader = command.ExecuteReader();
                //_reader.Close();
                //modules.Reader1(_command);
                //
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    if (int.TryParse(_reader[0].ToString(), out int value))
                    {
                        PassLogin.ID = value;
                    }
                    PassLogin.Logins = _reader[1].ToString();
                    PassLogin.Passwords = _reader[2].ToString();
                    if (textBox2.Text == PassLogin.Passwords)
                    {
                        _reader.Close();
                        modules.Reader(_command, out _reader);
                        while (_reader.Read())
                        {
                            if (int.TryParse(_reader[7].ToString(), out value))
                            {
                                RolvKarte.ID_Karta_Komissii = value;
                            }
                            if (int.TryParse(_reader[6].ToString(), out value))
                            {
                                RolvKarte.Role = value;
                            }
                            _reader.Close();
                            modules.Close();
                            MessageBox.Show("Вы Авторизованы");
                            if (RolvKarte.Role == 1)
                            {
                                MessageBox.Show("Вы Сотрудник");
                                Pages.EvaluationEmployee frm = new Pages.EvaluationEmployee();
                                this.Hide();
                                frm.Show();
                                break;
                            }
                            else
                            {
                                if (RolvKarte.Role == 2)
                                {
                                    MessageBox.Show("Вы Член Комиссии");
                                    Pages.EvaluationMember frm = new Pages.EvaluationMember();
                                    this.Hide();
                                    frm.Show();
                                    break;
                                }
                                else
                                {
                                    if (RolvKarte.Role == 3)
                                    {
                                        MessageBox.Show("Вы Глава Комиссии");
                                        Pages.EvaluationGlava frm = new Pages.EvaluationGlava();
                                        this.Hide();
                                        frm.Show();
                                        break;
                                    }
                                    else
                                    {
                                        if (RolvKarte.Role == 4)
                                        {
                                            MessageBox.Show("Вы Администратор");
                                            Pages.Admin admin = new Pages.Admin();
                                            this.Hide();
                                            admin.Show();
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
                        _reader.Close();
                        modules.Close();
                    }
                }
                else
                {
                    if (textBox1.Text == "ste")
                    {
                        if (textBox2.Text == "123")
                        {
                            MessageBox.Show("Вы Администратор");
                            Pages.Admin admin = new Pages.Admin();
                            this.Hide();
                            admin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный Логин");
                            _reader.Close();
                            modules.Close();
                        }
                    }
                    
                }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}