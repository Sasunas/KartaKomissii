using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commission_map.Pages
{
    public partial class Constructor : Form
    {
        public Constructor()
        {
            InitializeComponent();
            _Load();
        }

        public void _Load()
        {
            //Тут мы наполняем 1 список всеми Китериями из БД
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //тут мы узнаеём макс id текущих комиссий(критериев)
            //тут мы узнаеём count эл. listbox
            //тут мы через for наполняем БД(критерии) через соотношение имени и id критерия использемого в списке(и БД)
        }
    }
}
