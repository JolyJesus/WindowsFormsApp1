using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form36 : Form
    {
        public Form36()
        {
            InitializeComponent();
        }

        private void Form36_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myAiroportDataSet.View_PosadaPersonal". При необходимости она может быть перемещена или удалена.
            this.view_PosadaPersonalTableAdapter.Fill(this.myAiroportDataSet.View_PosadaPersonal);

        }
    }
}
