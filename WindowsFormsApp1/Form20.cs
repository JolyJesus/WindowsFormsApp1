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
    public partial class Form20 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        //string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            Tickets();
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
        private void Tickets()
        {
            string SqlText = "SELECT * FROM [Tickets]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Tickets]");
            dataGridView1.DataSource = ds.Tables["[Tickets]"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Tickets] ([TicketsID], [ReysID],[Cina],[DataVidpravlennya],[ID_Pasagir]) VALUES (1, 1, '200','01.01.2018',1) ";
            Form21 f = new Form21(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Tickets] ([TicketsID], [ReysID],[Cina],[DataVidpravlennya],[ID_Pasagir]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox5.Text + "\')";
              


                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Tickets();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string TicketsID;
            string ReysID, Cina, DataVidpravlennya, ID_Pasagir;
            string SqlText = "DELETE FROM [Pasagir] WHERE [Pasagir].ID_Pasagir = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form22 f = new Form22();
            index = dataGridView1.CurrentRow.Index;
            TicketsID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + TicketsID;

            // заповнити інформаційну довідку у вікні Form5
            TicketsID = Convert.ToString(dataGridView1[1, index].Value);
            ReysID = Convert.ToString(dataGridView1[2, index].Value);
            Cina = Convert.ToString(dataGridView1[2, index].Value);
            DataVidpravlennya = Convert.ToString(dataGridView1[2, index].Value);
            ID_Pasagir = Convert.ToString(dataGridView1[2, index].Value);


            f.label2.Text = TicketsID + " - " + TicketsID + " - " + ReysID + " - " + Cina + "-" + DataVidpravlennya + "-" + ID_Pasagir;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Tickets();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Tickets] SET ";
            string TicketsID, ReysID, Cina, DataVidpravlennya, ID_Pasagir;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form23 f = new Form23();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            TicketsID = dataGridView1[0, index].Value.ToString();
            ReysID = dataGridView1[0, index].Value.ToString();
            Cina = dataGridView1[1, index].Value.ToString();
            DataVidpravlennya = dataGridView1[2, index].Value.ToString();
            ID_Pasagir = dataGridView1[2, index].Value.ToString();
           

            f.textBox1.Text = ReysID;
            f.textBox2.Text = Cina;
            f.textBox3.Text = DataVidpravlennya;
            f.textBox4.Text = ID_Pasagir;
            f.textBox5.Text = TicketsID;           

            if (f.ShowDialog() == DialogResult.OK)
            {
                ReysID = f.textBox1.Text;
                Cina = f.textBox2.Text;
                DataVidpravlennya = f.textBox3.Text;
                ID_Pasagir = f.textBox4.Text;
                TicketsID = f.textBox5.Text;
                ReysID = f.textBox5.Text;

                SqlText += "ReysID = \'" + ReysID + "\', Cina = '" + Cina + "\', DataVidpravlennya = '" + DataVidpravlennya + "\', ID_Pasagir = '" + ID_Pasagir +  "";
                SqlText += "WHERE [Tickets].TicketsID = " + TicketsID;
                MyExecuteNonQuery(SqlText);
                Tickets();
            }
        }
    }
}
