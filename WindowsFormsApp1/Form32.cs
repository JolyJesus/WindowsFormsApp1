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
    public partial class Form32 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        // string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form32()
        {
            InitializeComponent();
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            Obsl();
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
        private void Obsl()
        {
            string SqlText = "SELECT * FROM [Obsl]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Obsl]");
            dataGridView1.DataSource = ds.Tables["[Obsl]"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Obsl] ([Obsl_ID], [Litak_ID],[date],[Stan],[Personal_ID]) VALUES (1,1, '01:01:2018','good',1) ";
            Form33 f = new Form33(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Obsl] ([Obsl_ID], [Litak_ID],[date],[Stan],[Personal_ID]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox5.Text + "\')";



                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Obsl();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string Obsl_ID;
            string Litak_ID, date, Stan, Personal_ID;
            string SqlText = "DELETE FROM [Pasagir] WHERE [Pasagir].ID_Pasagir = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form34 f = new Form34();
            index = dataGridView1.CurrentRow.Index;
            Obsl_ID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + Obsl_ID;

            // заповнити інформаційну довідку у вікні Form5
            Obsl_ID = Convert.ToString(dataGridView1[1, index].Value);
            Litak_ID = Convert.ToString(dataGridView1[2, index].Value);
            date = Convert.ToString(dataGridView1[2, index].Value);
            Stan = Convert.ToString(dataGridView1[2, index].Value);
            Personal_ID = Convert.ToString(dataGridView1[2, index].Value);
            

            f.label2.Text = Obsl_ID + " - " + Obsl_ID + " - " + Litak_ID + " - " + date + "-" + Stan + "-" + Personal_ID;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Obsl();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Obsl] SET ";
            string Obsl_ID, Litak_ID, date, Stan, Personal_ID;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form35 f = new Form35();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            Obsl_ID = dataGridView1[0, index].Value.ToString();
            Litak_ID = dataGridView1[0, index].Value.ToString();
            date = dataGridView1[1, index].Value.ToString();
            Stan = dataGridView1[2, index].Value.ToString();
            Personal_ID = dataGridView1[2, index].Value.ToString();
           

            f.textBox1.Text = Litak_ID;
            f.textBox2.Text = date;
            f.textBox3.Text = Stan;
            f.textBox4.Text = Personal_ID;
           

            if (f.ShowDialog() == DialogResult.OK)
            {
                Litak_ID = f.textBox1.Text;
                Name = f.textBox2.Text;
                Stan = f.textBox3.Text;
                Personal_ID = f.textBox4.Text;
               

                SqlText += "Litak_ID = \'" + Litak_ID + "\', date = '" + date + "\', Stan = '" + Stan + "\', Personal_ID = '" + Personal_ID + "";
                SqlText += "WHERE [Obsl].Obsl_ID = " + Obsl_ID;
                MyExecuteNonQuery(SqlText);
                Obsl();
            }
        }

        private void Form32_Load(object sender, EventArgs e)
        {

        }
    }
}
