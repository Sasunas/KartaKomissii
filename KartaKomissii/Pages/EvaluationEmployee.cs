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
    public partial class EvaluationEmployee : Form
    {
        int value;
        private static IntPtr handle;
        Modules modules = new Modules(handle);
        string Lowlevel;
        string Mediumlevel;
        string Hightlevel;
        public EvaluationEmployee()
        {
            InitializeComponent();
            Ocenka_Load();
            toolTip1.SetToolTip(this.Estimate, "Тут можно оценить всякое");
            toolTip1.SetToolTip(this.commentBox, "Тут можно комментировать");
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
                modules.Close();

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

        private void Block_SelectedIndexChanged(object sender, EventArgs e)
        {
            //загрузка описания блока оценивания
            try
            {
                int _block = Block.SelectedIndex + 1;
                int _arch = Archetype.SelectedIndex + 1;
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
                modules.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Archetype_SelectedIndexChanged(object sender, EventArgs e) {}

        private void Estimate_Click(object sender, EventArgs e)
        {
            try
            {
                double MARK = Convert.ToDouble(ocenkaBox.Text);
                if (MARK > 5 || MARK < 0)
                {
                    MessageBox.Show("Некорректное значение оценки");
                }
                else
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
                            int count = 0;
                            if (int.TryParse(_reader[0].ToString(), out value))
                            {
                                count = value;
                            }
                            _reader.Close();
                            //Поиск ID требования
                            _command = "SELECT [Требование].ID FROM [Требование] WHERE ID_Блока = " + _block + " AND ID_Архетипа = " + _arch + "";
                            modules.Reader(_command, out _reader);
                            _reader.Read();
                            int _trebovania = 0;
                            if (int.TryParse(_reader[0].ToString(), out value))
                            {
                                _trebovania = value;
                            }
                            _reader.Close();
                            //Выставление оценки
                            _command = "INSERT INTO [Оценка по требованию] (ID, ID_Требования, ID_Карта_комиссии, ID_Сотрудника, Оценка, Дата, Комментарий) VALUES ("
                                + (count + 1) + ", " + _trebovania + ", " + RolvKarte.ID_Karta_Komissii
                                + ", " + PassLogin.ID + ", '" + ocenkaBox.Text + "', '" + DateTime.Today + "', '" + commentBox.Text + "')";
                            modules.Command(_command);
                            MessageBox.Show("Оценка была успешно выставлена");
                            RolvKarte.ID_OcenkaTreb = count;
                            _reader.Close();
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

        private void Comment_Click(object sender, EventArgs e)
        {
            try
            {
                //Добавление комментария
                string _command = "update [Оценка по требованию] set Комментарий = '" + commentBox.Text + "' where ID = " + (RolvKarte.ID_OcenkaTreb + 1) + " ";
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
                //Копирование в БД ссылки на гит работы Сотрудника
                string _command = "update [Карта комиссии] set Ссылка = '" + linkBox.Text + "' where ID = " + (RolvKarte.ID_Karta_Komissii) + " ";
                modules.Command(_command);
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
