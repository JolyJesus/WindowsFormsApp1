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
    public partial class Form28 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        // string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form28()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            Personal();
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
        private void Personal()
        {
            string SqlText = "SELECT * FROM [Personal]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Personal]");
            dataGridView1.DataSource = ds.Tables["[Personal]"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Personal] ([Personal_ID], [Surname],[Posada_ID],[KilkistPolotiv],[Vik]) VALUES (1,'surname', 1, '1','20') ";
            Form29 f = new Form29(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Personal] ([Personal_ID], [Surname],[Posada_ID],[KilkistPolotiv],[Vik]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox5.Text + "\')";
               


                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Personal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string Personal_ID;
            string Surname, Posada_ID, NomerTelefony, KilkistPolotiv, Vik;
            string SqlText = "DELETE FROM [Personal] WHERE [Personal].Personal_ID = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form30 f = new Form30();
            index = dataGridView1.CurrentRow.Index;
            Personal_ID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + Personal_ID;

            // заповнити інформаційну довідку у вікні Form5
            Personal_ID = Convert.ToString(dataGridView1[1, index].Value);
            Surname = Convert.ToString(dataGridView1[2, index].Value);
            Posada_ID = Convert.ToString(dataGridView1[2, index].Value);
            NomerTelefony = Convert.ToString(dataGridView1[2, index].Value);
            KilkistPolotiv = Convert.ToString(dataGridView1[2, index].Value);
            Vik = Convert.ToString(dataGridView1[2, index].Value);
            

            f.label2.Text = Personal_ID + " - " + Personal_ID + " - " + Surname + " - " + Posada_ID + "-" + NomerTelefony + "-" + KilkistPolotiv + "-" + Vik ;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Personal();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Personal] SET ";
            string Personal_ID, Surname, Posada_ID, NomerTelefony, KilkistPolotiv, Vik;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form31 f = new Form31();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            Personal_ID = dataGridView1[0, index].Value.ToString();
            Surname = dataGridView1[0, index].Value.ToString();
            Posada_ID = dataGridView1[1, index].Value.ToString();
            NomerTelefony = dataGridView1[2, index].Value.ToString();
            KilkistPolotiv = dataGridView1[2, index].Value.ToString();
            Vik = dataGridView1[2, index].Value.ToString();
      

            f.textBox1.Text = Surname;
            f.textBox2.Text = Posada_ID;
            f.textBox3.Text = NomerTelefony;
            f.textBox4.Text = KilkistPolotiv;
            f.textBox5.Text = Vik;
           

            if (f.ShowDialog() == DialogResult.OK)
            {
                Surname = f.textBox1.Text;
                Posada_ID = f.textBox2.Text;
                NomerTelefony = f.textBox3.Text;
                KilkistPolotiv = f.textBox4.Text;
                Vik = f.textBox5.Text;
                

                SqlText += "Surname = \'" + Surname + "\', Posada_ID = '" + Posada_ID + "\', NomerTelefony = '" + NomerTelefony + "\', KilkistPolotiv = '" + KilkistPolotiv + "\', Vik = '" + Vik + "";
                SqlText += "WHERE [Personal].Personal_ID = " + Personal_ID;
                MyExecuteNonQuery(SqlText);
                Personal();
            }
        }
    }
}
