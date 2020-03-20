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
    public partial class Form9 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        // string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Reys();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // на основі виділеного рядка в таблиці Source вивести таблицю Emission
            // визначити кількість рядків в dataGridView1
            int n = dataGridView1.RowCount;
            int row = dataGridView1.CurrentRow.Index;

            if (n != (row + 1)) // Перевірка, чи на клацнули на останньому рядку
                Reys();
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
        private void Reys()
        {
            string SqlText = "SELECT * FROM [Reys]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Reys]");
            dataGridView1.DataSource = ds.Tables["[Reys]"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Reys] ([ReysID], [Litak_ID],[Data],[ChasVidpravlennya],[MarshrutID],[ChasPrybuttya]) VALUES (1,1, '01:01:2018','20:40',1,'21:50') ";
            Form13 f = new Form13(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Reys] ([ReysID], [Litak_ID],[Data],[ChasVidpravlennya],[MarshrutID],[ChasPrybuttya]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox5.Text + "\')";


                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Reys();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string Reys_ID;
            string Litak_ID, Data, ChasVidpravlennya, MarshrutID, ChasPrybuttya;
            string SqlText = "DELETE FROM [Reys] WHERE [Reys].Reys_ID = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form14 f = new Form14();
            index = dataGridView1.CurrentRow.Index;
            Reys_ID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + Reys_ID;

            // заповнити інформаційну довідку у вікні Form5
            Reys_ID = Convert.ToString(dataGridView1[1, index].Value);
            Litak_ID = Convert.ToString(dataGridView1[2, index].Value);
            Data = Convert.ToString(dataGridView1[2, index].Value);
            ChasVidpravlennya = Convert.ToString(dataGridView1[2, index].Value);
            MarshrutID = Convert.ToString(dataGridView1[2, index].Value);
            ChasPrybuttya = Convert.ToString(dataGridView1[2, index].Value);

            f.label2.Text = Reys_ID + " - " + Reys_ID + " - " + Litak_ID + " - " + Data+"-" + ChasVidpravlennya + "-" + MarshrutID + "-" + ChasPrybuttya;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Reys();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Reys] SET ";
            string Reys_ID, Litak_ID, Data, ChasVidpravlennya, MarshrutID, ChasPrybuttya;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form15 f = new Form15();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            Reys_ID = dataGridView1[0, index].Value.ToString();
            Litak_ID = dataGridView1[0, index].Value.ToString();
            Data = dataGridView1[1, index].Value.ToString();
            ChasVidpravlennya = dataGridView1[2, index].Value.ToString();
            MarshrutID = dataGridView1[2, index].Value.ToString();
            ChasPrybuttya = dataGridView1[2, index].Value.ToString();

            f.textBox1.Text = Litak_ID;
            f.textBox2.Text = Data;
            f.textBox3.Text = ChasVidpravlennya;
            f.textBox4.Text = MarshrutID;
            f.textBox5.Text = ChasPrybuttya;


            if (f.ShowDialog() == DialogResult.OK)
            {
                Litak_ID = f.textBox1.Text;
                Data = f.textBox2.Text;
                ChasVidpravlennya = f.textBox3.Text;
                MarshrutID = f.textBox4.Text;
                ChasPrybuttya = f.textBox5.Text;

                SqlText += "Litak_ID = \'" + Litak_ID + "\', Data = '" + Data + "\', ChasVidpravlennya = '" + ChasVidpravlennya + "\', MarshrutID = '" + MarshrutID + "\', ChasPrybuttya = '" + ChasPrybuttya + "";
                SqlText += "WHERE [Reys].Reys_ID = " + Reys_ID;
                MyExecuteNonQuery(SqlText);
                Reys();
            }
        }
    }
}
