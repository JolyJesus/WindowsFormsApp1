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

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        // string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form8()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // на основі виділеного рядка в таблиці Source вивести таблицю Emission
            // визначити кількість рядків в dataGridView1
            int n = dataGridView1.RowCount;
            int row = dataGridView1.CurrentRow.Index;

            if (n != (row + 1)) // Перевірка, чи на клацнули на останньому рядку
                Marshrut();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Marshrut();
        }
        private void Marshrut()
        {
            string SqlText = "SELECT * FROM [Marshrut]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Marshrut]");
            dataGridView1.DataSource = ds.Tables["[Marshrut]"].DefaultView;
        }
        public void MyExecuteNonQuery(string SqlText)
        {
            SqlConnection cn; // екземпляр класу типу SqlConnection
            SqlCommand cmd;
            // виділення пам'яті з ініціалізацією рядком з'єднання з базою даних
            cn = new SqlConnection(ConnStr);

            cn.Open(); // відкрити джерело даних
            cmd = cn.CreateCommand(); // задати SQL-команду
            cmd.CommandText = SqlText; // задати командний рядок
            cmd.ExecuteNonQuery(); // виконати SQL-команду
            cn.Close(); // закрити джерело даних
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Marshrut] ( [Kudy],[Opys]) VALUES (1, 'Напрямок-01','Опис-01') ";
            Form11 f = new Form11(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Marshrut] ( [Kudy],[Opys]) VALUES (";
                //SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                 SqlText = SqlText + "\'" + f.textBox3.Text + "\')";

                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Marshrut();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string MarshrutID;
            string  Kudy, Opys;
            string SqlText = "DELETE FROM [Marshrut] WHERE [Marshrut].MarshrutID = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form12 f = new Form12();
            index = dataGridView1.CurrentRow.Index;
            MarshrutID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + MarshrutID;

            // заповнити інформаційну довідку у вікні Form5
            MarshrutID = Convert.ToString(dataGridView1[1, index].Value);
            Kudy = Convert.ToString(dataGridView1[2, index].Value);
            Opys = Convert.ToString(dataGridView1[2, index].Value);

            f.label2.Text = MarshrutID + " - " + MarshrutID + " - " + Kudy + " - " + Opys;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Marshrut();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Marshrut] SET ";
            string MarshrutID, Kudy, Opys;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form16 f = new Form16();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            MarshrutID = dataGridView1[0, index].Value.ToString();
            Kudy = dataGridView1[1, index].Value.ToString();
            Opys = dataGridView1[2, index].Value.ToString();
            
            f.textBox2.Text = Kudy;
            f.textBox3.Text = Opys;
           

            if (f.ShowDialog() == DialogResult.OK)
            {
                Kudy = f.textBox2.Text;
                Opys = f.textBox3.Text;
               
                SqlText += "Kudy = \'" + Kudy + "\', Opys = '" + Opys + "";
                SqlText += "WHERE [Marshrut].MarshrutID = " + MarshrutID;
                MyExecuteNonQuery(SqlText);
                Marshrut();
            }
        }
    }
}
