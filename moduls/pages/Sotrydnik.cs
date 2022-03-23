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
    public partial class Sotrydnik : Form
    {
        public string Sql = "Data Source =PIT48\\SADYKOVAR;Initial Catalog=KK;User ID=Billy;Password=123456";
        public Sotrydnik()
        {
            InitializeComponent();
            Ocenka_Load();
            toolTip1.SetToolTip(this.Estimate, "Тут можно оценить всякое");
            toolTip1.SetToolTip(this.richTextBox2, "Тут можно комментировать");

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

        private void Estimate_Click(object sender, EventArgs e)
        {
            try 
            {
                double MARK = Convert.ToDouble(textBox1.Text);
                if (MARK > 5 || MARK < 0)
                {
                    MessageBox.Show("Некорректное значение оценки");
                }
                else
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
                                + (count + 1) + ", " + _trebovania + ", " + classes.RolvKarte.IDOcenkaSotrydnika
                                + ", " + classes.PassLogin.ID + ", '" + textBox1.Text + "', '" + DateTime.Today + "')";
                            _query = new SqlCommand(_command, _connection);
                            _query.ExecuteNonQuery();
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
                }
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
                classes.OcenkaTreb.Link_Sotryd = richTextBox1.Text;
                //Добовление комментария
                string _command = "update [Карта комиссии] set Ссылка = '" + classes.OcenkaTreb.Link_Sotryd + "' where ID = " + (classes.OcenkaTreb.ID_Karta_Komissii) + " ";
                SqlCommand _query = new SqlCommand(_command, _connection);
                _query.ExecuteNonQuery();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(',')) || (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ','))
            {
                e.Handled = true;
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
    }
}
