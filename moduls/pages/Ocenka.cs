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
    public partial class Ocenka : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Ocenka()
        {
            InitializeComponent();
            Ocenka_Load();
        }

        public void Ocenka_Load()
        {
            try
            {
                SqlConnection _connection = new SqlConnection(Sql);
                _connection.Open();
                string _command = "SELECT * FROM Блоки";
                SqlCommand _query = new SqlCommand(_command, _connection);
                SqlDataReader _reader = _query.ExecuteReader();
                Block.Items.Clear();
                while (_reader.Read())
                {
                    Block.Items.Add(_reader[1]);
                }
                _reader.Close();
                _command = "SELECT * FROM Архетипы";
                _query = new SqlCommand(_command, _connection);
                _reader = _query.ExecuteReader();
                Archetype.Items.Clear();
                while (_reader.Read())
                {
                    Archetype.Items.Add(_reader[1]);
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
                _query.ExecuteNonQuery();
                _connection.Close();
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
                        _connection = new SqlConnection(Sql);
                        _connection.Open();
                        //Вычисление длинны
                        _command = "SELECT COUNT(*) as count FROM [Оценка по требованию]";
                        _query = new SqlCommand(_command, _connection);
                        _reader = _query.ExecuteReader();
                        _reader.Read();
                        int count = Convert.ToInt32(_reader[0]);
                        _reader.Close();
                        //Поиск ID требования
                        _command = "SELECT [Требование].ID FROM [Требование] WHERE ID_Блока = " + _block + " AND ID_Архетипа = " + _arch + "";
                        _query = new SqlCommand(_command, _connection);
                        _reader = _query.ExecuteReader();
                        _reader.Read();
                        int _trebovania = Convert.ToInt32(_reader[0]);
                        _reader.Close();
                        //Выставление оценки - есть проблема - нужно добавить комментарий и ID_Сотрудника который выставляет оценку
                        _command = "INSERT INTO [Оценка по требованию] (ID, ID_Требования, ID_Оценка_сотрудника, ID_Сотрудника, Оценка, Дата) VALUES ("
                            + (count + 1) + ", " + _trebovania + ", " + classes.OcenkaTreb.ID_Karta_Komissii
                            + ", " + classes.PassLogin.ID + ", '" + textBox1.Text + "', '" + DateTime.Today + "')";
                        _query = new SqlCommand(_command, _connection);
                        _query.ExecuteNonQuery();
                        MessageBox.Show("Оценка была успешно выставлена");
                        classes.OcenkaTreb.ID_OcenkaTreb = count;
                        _reader.Close();
                        _connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не выставлена Оценка");
                        _reader.Close();
                        _connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран Архетип или Блок");
                    _reader.Close();
                    _connection.Close();
                }
                _reader.Close();
                _connection.Close();
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
                                           + " left join [Роль в текущей карте] e on a.ID_Сотрудника = e.ID_Сотрудника"
                                           + " where ID_Оценка_сотрудника = " + classes.OcenkaTreb.ID_Karta_Komissii + " and ID_Роли = 1";
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
                connection.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Autorizacia frm = new Autorizacia();
            this.Hide();
            frm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
