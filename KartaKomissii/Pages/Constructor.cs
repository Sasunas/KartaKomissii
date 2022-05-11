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
        Modules modules;

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
                //загрузка перечня Блоков оценивания
                string _command = "SELECT * FROM Блоки";
                modules.Reader(_command, out SqlDataReader _reader);
                listBox1.Items.Clear();
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
            //тут мы узнаеём макс id текущих комиссий(критериев)
            //тут мы узнаеём count эл. listbox
            //тут мы через for наполняем БД(критерии) через соотношение имени и id критерия использемого в списке(и БД)
        }
    }
}
