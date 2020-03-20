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
    public partial class Form24 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        // string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            Posada();
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
        private void Posada()
        {
            string SqlText = "SELECT * FROM [Posada]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Posada]");
            dataGridView1.DataSource = ds.Tables["[Posada]"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Posada] ([Posada_ID], [NazvaPosady]) VALUES (1,'Назва') ";
            Form25 f = new Form25(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Posada] ([Posada_ID], [NazvaPosady]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\')";


                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Posada();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string Posada_ID;
            string NazvaPosady;
            string SqlText = "DELETE FROM [Posada] WHERE [Posada].Posada_ID = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form26 f = new Form26();
            index = dataGridView1.CurrentRow.Index;
            Posada_ID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + Posada_ID;

            // заповнити інформаційну довідку у вікні Form5
            Posada_ID = Convert.ToString(dataGridView1[1, index].Value);
            NazvaPosady = Convert.ToString(dataGridView1[2, index].Value);
            

            f.label2.Text = Posada_ID + " - " + Posada_ID + " - " + NazvaPosady;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Posada();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Posada] SET ";
            string Posada_ID, NazvaPosady;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form27 f = new Form27();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            Posada_ID = dataGridView1[0, index].Value.ToString();
            NazvaPosady = dataGridView1[0, index].Value.ToString();


            f.textBox1.Text = NazvaPosady;
 

            if (f.ShowDialog() == DialogResult.OK)
            {
                NazvaPosady = f.textBox1.Text;


                SqlText += "Surname = \'" + NazvaPosady +  "";
                SqlText += "WHERE [Posada].Posada_ID = " + Posada_ID;
                MyExecuteNonQuery(SqlText);
                Posada();
            }
        }
    }
}
