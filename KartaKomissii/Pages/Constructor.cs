using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commission_map.Classes;

namespace Commission_map.Pages
{
    public partial class Constructor : Form
    {
        private static IntPtr handle;
        Modules modules = new Modules(handle);

        public Constructor()
        {
            InitializeComponent();
            _Load();
        }

        public void _Load()
        {
            //Тут мы наполняем 1 список всеми Китериями из БД
            try
            {
                //загрузка перечня Критериев оценивания
                listBox1.Items.Clear();
                string _command = "SELECT * FROM Блоки";
                modules.Reader(_command, out SqlDataReader _reader);
                while (_reader.Read())
                {
                    listBox1.Items.Add(_reader[1]);
                }
                _reader.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            int id = 0;
            int id_block = 0;
            int count = 0;
            //Узнаеём макс id текущих комиссий(Архетипов) и создаём новый
            string _command = "select count(*) from [Архетипы]";
            modules.Reader(_command, out SqlDataReader _reader);
            _reader.Read();
            if (int.TryParse(_reader[0].ToString(), out  int value))
            {
                count = value + 1;
            }
            _command = "insert into [Архетипы] (ID, Название) values(" + count + ",'" + name.Text + "')";
            modules.Command(_command);
            //Узнаеём кол-во эл. listbox
            int countList = listBox2.Items.Count;
            //Через for наполняем БД(критерии) через соотношение имени и id критерия использемого в списке(и БД)
            for (int i = 0; i < countList; i++)
            {
                string name = listBox2.Items[i].ToString();
                _command = "select * from [Блоки] where Название = '" + name + "'";
                modules.Reader(_command, out _reader);
                _reader.Read();
                if (int.TryParse(_reader[0].ToString(), out value))
                {
                    id_block= value;
                }
                _command = "select MAX([Требование].ID) from [Требование]";
                modules.Reader(_command, out _reader);
                _reader.Read();
                if (int.TryParse(_reader[0].ToString(), out value))
                {
                    id = value + 1;
                }
                _command = "insert into Требование(ID,ID_Архетипа,ID_Блока,Уровень,Максимальный,[От 0 до 1],[От 1 до 3],[От 3 до 5])" +
                    " values(" + id + "," + count + "," + id_block + ",1,5,'b','b','b')";
                modules.Command(_command);
            }
            _reader.Close();
            modules.Close();
            MessageBox.Show("Требования Карты Комиссии были успешно созданы.");
        }

        private void Inside_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void Outside_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Pages.CommissionLeader admin = new Pages.CommissionLeader();
            this.Hide();
            admin.ShowDialog();
        }
    }
}
