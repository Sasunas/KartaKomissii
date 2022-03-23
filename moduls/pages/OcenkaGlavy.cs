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
    public partial class OcenkaGlavy : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public OcenkaGlavy()
        {
            InitializeComponent();
            Ocenka_Glavy_Load();
        }
        public void Ocenka_Glavy_Load()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Sql);
                connection.Open();
                string command = "SELECT * FROM Блоки";
                SqlCommand query = new SqlCommand(command, connection);
                SqlDataReader reader = query.ExecuteReader();
                Block.Items.Clear();
                while (reader.Read())
                {
                    Block.Items.Add(reader[1]);
                }
                reader.Close();
                command = "SELECT * FROM Архетипы";
                query = new SqlCommand(command, connection);
                reader = query.ExecuteReader();
                Archetype.Items.Clear();
                while (reader.Read())
                {
                    Archetype.Items.Add(reader[1]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void estimate_Click(object sender, EventArgs e)
        {
            try
            {
                int _block = Convert.ToInt32(Block.SelectedIndex) + 1;
                int _arch = Convert.ToInt32(Archetype.SelectedIndex) + 1;
                SqlConnection _connection = new SqlConnection(Sql);
                _connection.Open();
                string _command = "SELECT * FROM [Требование] WHERE ID_Архетипа = " + _arch + " AND ID_Блока = " + _block + "";
                SqlCommand _query = new SqlCommand(_command, _connection);
                SqlDataReader _reader = _query.ExecuteReader();
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    if (textBox1.Text != "")
                    {
                        int mark = Convert.ToInt32(textBox1.Text);
                        SqlConnection connection = new SqlConnection(Sql);
                        connection.Open();
                        //Вычисление длинны
                        string command = "SELECT COUNT(*) as count FROM [Оценка по требованию]";
                        SqlCommand query = new SqlCommand(command, connection);
                        SqlDataReader reader = query.ExecuteReader();
                        reader.Read();
                        int count = Convert.ToInt32(reader[0]);
                        reader.Close();
                        //Поиск ID требования
                        command = "SELECT [Требование].ID FROM [Требование] WHERE ID_Блока = " + _block + " AND ID_Архетипа = " + _arch + "";
                        query = new SqlCommand(command, connection);
                        reader = query.ExecuteReader();
                        reader.Read();
                        int treb = Convert.ToInt32(reader[0]);
                        reader.Close();
                        //Выставление оценки
                        command = "INSERT INTO [Оценка по требованию] (ID, ID_Требования, ID_Оценка_сотрудника, ID_Сотрудника, Оценка, Дата) VALUES (" + (count + 1) +
                            ", " + treb + ", 1, " + classes.PassLogin.ID + ", '" + textBox1.Text + "', '2022-03-04')";
                        query = new SqlCommand(command, connection);
                        query.ExecuteNonQuery();
                        MessageBox.Show("Оценка была успешно выставлена");
                        classes.OcenkaTreb.ID_OcenkaTreb = count;
                    }
                    else
                    {
                        MessageBox.Show("Не выставлена Оценка");
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран Архетип или Блок");
                }
                _reader.Close();
                _connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void Comment_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(Sql);
                _connection.Open();
                //Добовление комментария
                string _command = "update [Оценка по требованию] set Комментарий = '" + richTextBox1.Text + "' where ID = " + (classes.OcenkaTreb.ID_OcenkaTreb + 1) + " ";
                SqlCommand _query = new SqlCommand(_command, _connection);
                _query.ExecuteNonQuery(); ;
                MessageBox.Show("Комментарий был успешно выставлен");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                SqlConnection connection = new SqlConnection(Sql);
                connection.Open();
                string query = "SELECT * FROM [Карта комиссии] WHERE [Дата начала] = '" + dateTimePicker1.Value + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    classes.OcenkaTreb.ID_Karta_Komissii = Convert.ToInt32(reader[0].ToString());
                    listView1.Items.Add("ID Оценки сотрудника = " + classes.OcenkaTreb.ID_Karta_Komissii);
                    reader.Close();
                    connection.Close();
                    connection.Open();
                    query = "select * from [Оценка по требованию] a left join Требование b on a.ID_Требования = b.ID"
                                           + " left join Блоки c on b.ID_Блока = c.ID"
                                           + " left join Архетипы d on b.ID_Архетипа = d.ID"
                                           + " where ID_Оценка_сотрудника = " + classes.OcenkaTreb.ID_Karta_Komissii + "";
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    //listView1.Items.Add("ФИО = " + reader[13].ToString());
                    //listView1.Items.Add("Роль = " + reader[15].ToString());
                    while (reader.Read())
                    {

                        listView1.Items.Add("Блок требований = " + reader[16].ToString());
                        listView1.Items.Add("Архетип = " + reader[18].ToString());
                        listView1.Items.Add("Оценка/Максимум = " + reader[4].ToString().Trim() + "/" + reader[11].ToString());
                        listView1.Items.Add("Коммментирий: " + reader[6].ToString().Trim());
                        listView1.Items.Add("");
                    }
                    connection.Close();
                }
                else
                {
                    listView1.Items.Add("В этот период не проводилось тестирование сотрудника");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
        private void Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _block = Convert.ToInt32(Block.SelectedIndex) + 1;
                int _arch = Convert.ToInt32(Archetype.SelectedIndex) + 1;
                SqlConnection _connection = new SqlConnection(Sql);
                _connection.Open();
                string _command = "SELECT * FROM [Требование] WHERE ID_Архетипа = " + _arch + " AND ID_Блока = " + _block + "";
                SqlCommand _query = new SqlCommand(_command, _connection);
                SqlDataReader _reader = _query.ExecuteReader();
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    textBox2.Text = _reader[5].ToString().Trim();
                    textBox3.Text = _reader[6].ToString().Trim();
                    textBox4.Text = _reader[7].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Архетип не был выбран");
                }
                _reader.Close();
                _connection.Close();
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

        private void Back_Click(object sender, EventArgs e)
        {
            Autorizacia frm = new Autorizacia();
            this.Hide();
            frm.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void Link_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection _connection = new SqlConnection(Sql);
                _connection.Open();
                string _command = "SELECT Ссылка FROM [Карта комиссии]";
                SqlCommand _query = new SqlCommand(_command, _connection);
                SqlDataReader _reader = _query.ExecuteReader();
                _reader.Read();
                Clipboard.Clear();
                Clipboard.SetText(_reader[0].ToString());
                _reader.Close();
                _connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
