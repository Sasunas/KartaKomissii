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
using Commission_map.Classes;

namespace Commission_map.Pages
{
    public partial class EvaluationMember : Form
    {
        private static IntPtr handle;
        Modules modules = new Modules(handle);
        string Lowlevel;
        string Mediumlevel;
        string Hightlevel;
        readonly string Sql = Classes.PassLogin.connectionString[0].ToString();
        public EvaluationMember()
        {
            InitializeComponent();
            Ocenka_Load();
        }

        public void Ocenka_Load()
        {
            try
            {
                //загрузка перечня Блоков оценивания
                string _command = "SELECT * FROM Блоки";
                modules.Reader(_command, out SqlDataReader _reader);
                Block.Items.Clear();
                while (_reader.Read())
                {
                    Block.Items.Add(_reader[1]);
                }
                _reader.Close();
                //загрузка перечня Архетипов оценивания
                _command = "SELECT * FROM Архетипы";
                modules.Reader(_command, out _reader);
                Archetype.Items.Clear();
                while (_reader.Read())
                {
                    Archetype.Items.Add(_reader[1]);
                }
                _reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            //загрузка описания блока оценивания
            try
            {
                int _block = Convert.ToInt32(Block.SelectedIndex) + 1;
                int _arch = Convert.ToInt32(Archetype.SelectedIndex) + 1;
                string _command = "SELECT * FROM [Требование] WHERE ID_Архетипа = " + _arch + " AND ID_Блока = " + _block + "";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    Lowlevel = _reader[5].ToString().Trim();
                    Mediumlevel = _reader[6].ToString().Trim();
                    Hightlevel = _reader[7].ToString().Trim();
                    if (radioButton1.Checked)
                    {
                        Deskription.Text = Lowlevel;
                    }
                    else
                    {
                        if (radioButton2.Checked)
                        {
                            Deskription.Text = Mediumlevel;
                        }
                        else
                        {
                            if (radioButton3.Checked)
                            {
                                Deskription.Text = Hightlevel;
                            }
                            else
                            {
                                radioButton1.Checked = true;
                                Deskription.Text = Lowlevel;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Архетип не был выбран");
                }
                _reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            //загрузка списка оценивания Сотрудника
            try
            {
                listView1.Items.Clear();
                string _command = "SELECT * FROM [Карта комиссии] WHERE [Дата начала] = '" + dateTimePicker1.Value + "'";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    Classes.OcenkaTreb.ID_Karta_Komissii = Convert.ToInt32(_reader[0].ToString());
                    listView1.Items.Add("ID Оценки сотрудника = " + Classes.OcenkaTreb.ID_Karta_Komissii);
                    _reader.Close();
                    _command = "select * from [Оценка по требованию] a left join Требование b on a.ID_Требования = b.ID"
                                           + " left join Блоки c on b.ID_Блока = c.ID"
                                           + " left join Архетипы d on b.ID_Архетипа = d.ID"
                                           + " left join [Роль в текущей карте] e on a.ID_Сотрудника = e.ID_Сотрудника"
                                           + " left join Роли f on f.ID = e.ID_Роли"
                                           + " left join Сотрудник g on g.ID = e.ID_Сотрудника"
                                           + " where ID_Карта_комиссии = " + Classes.OcenkaTreb.ID_Karta_Komissii + " and ID_Роли = 1";
                    modules.Reader(_command, out _reader);
                    while (_reader.Read())
                    {
                        listView1.Items.Add("ФИО = " + _reader[25].ToString().Trim() + " " + _reader[26].ToString().Trim() + " " + _reader[27].ToString().Trim());
                        listView1.Items.Add("Роль = " + _reader[23].ToString().Trim());
                        listView1.Items.Add("Блок требований = " + _reader[16].ToString());
                        listView1.Items.Add("Архетип = " + _reader[18].ToString());
                        listView1.Items.Add("Оценка/Максимум = " + _reader[4].ToString().Trim() + "/" + _reader[11].ToString());
                        listView1.Items.Add("Коммментирий: " + _reader[6].ToString().Trim());
                        listView1.Items.Add("");
                    }
                }
                else
                {
                    listView1.Items.Add("В этот период не проводилось тестирование сотрудника");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //выбор описания блока оценивания
            Deskription.Text = Lowlevel;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //выбор описания блока оценивания
            Deskription.Text = Mediumlevel;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //выбор описания блока оценивания
            Deskription.Text = Hightlevel;
        }

        private void Estimate_Click(object sender, EventArgs e)
        {
            try
            {
                int _block = Convert.ToInt32(Block.SelectedIndex) + 1;
                int _arch = Convert.ToInt32(Archetype.SelectedIndex) + 1;
                string _command = "SELECT * FROM [Требование] WHERE ID_Архетипа = " + _arch + " AND ID_Блока = " + _block + "";
                modules.Reader(_command, out SqlDataReader _reader);
                _reader.Read();
                if (_reader.HasRows == true)
                {
                    if (Deskription.Text != "")
                    {
                        //Вычисление длинны
                        _command = "SELECT COUNT(*) as count FROM [Оценка по требованию]";
                        modules.Reader(_command, out _reader);
                        _reader.Read();
                        int count = Convert.ToInt32(_reader[0]);
                        _reader.Close();
                        //Поиск ID требования
                        _command = "SELECT [Требование].ID FROM [Требование] WHERE ID_Блока = " + _block + " AND ID_Архетипа = " + _arch + "";
                        modules.Reader(_command, out _reader);
                        _reader.Read();
                        int _trebovania = Convert.ToInt32(_reader[0]);
                        _reader.Close();
                        //Выставление оценки
                        _command = "INSERT INTO [Оценка по требованию] (ID, ID_Требования, ID_Оценка_сотрудника, ID_Сотрудника, Оценка, Дата) VALUES ("
                            + (count + 1) + ", " + _trebovania + ", " + Classes.OcenkaTreb.ID_Karta_Komissii
                            + ", " + Classes.PassLogin.ID + ", '" + ocenkaBox.Text + "', '" + DateTime.Today + "')";
                        modules.Command(_command);
                        MessageBox.Show("Оценка была успешно выставлена");
                        Classes.OcenkaTreb.ID_OcenkaTreb = count;
                        _reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не выставлена Оценка");
                        _reader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран Архетип или Блок");
                    _reader.Close();
                }
                _reader.Close();
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
                //Добовление комментария
                string _command = "update [Оценка по требованию] set Комментарий = '" + commentBox.Text + "' where ID = " + (Classes.OcenkaTreb.ID_OcenkaTreb + 1) + " ";
                modules.Command(_command);
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
                //Копирование в буфер обмена ссылки на гит работы Сотрудника
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

        private void OcenkaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Должен существовать толко 1 знак ",", должны использоваться только цифры, а так-же Backspace
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(',')) || (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
    }
}
