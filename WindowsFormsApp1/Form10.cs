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
    public partial class Form10 : Form
    {
        string ConnStr = @" Data Source=DESKTOP-1TP28HN\Roman-PC;Initial Catalog=MyAiroport1;Integrated Security=True";
        //string ConnStr = @" Data Source=DESKTOP-1TP28HN;Initial Catalog=MyAiroport;Integrated Security=True";
        public Form10()
        {
            
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            Pasagir();
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
        private void Pasagir()
        {
            string SqlText = "SELECT * FROM [Pasagir]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Pasagir]");
            dataGridView1.DataSource = ds.Tables["[Pasagir]"].DefaultView;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Pasagir] ([ID_Pasagir], [Surname],[Name],[NomerTelefony],[Pasport],[TicketsID],[ReysID]) VALUES (1,1, '01:01:2018','20:40',1,'21:50') ";
            Form17 f = new Form17(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Pasagir] ([ID_Pasagir], [Surname],[Name],[NomerTelefony],[Pasport],[TicketsID],[ReysID]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox5.Text + "\')";
                SqlText = SqlText + "\'" + f.textBox6.Text + "\')";


                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Pasagir();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string ID_Pasagir;
            string Surname, Name, NomerTelefony, Pasport, TicketsID, ReysID;
            string SqlText = "DELETE FROM [Pasagir] WHERE [Pasagir].ID_Pasagir = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form18 f = new Form18();
            index = dataGridView1.CurrentRow.Index;
            ID_Pasagir = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + ID_Pasagir;

            // заповнити інформаційну довідку у вікні Form5
            ID_Pasagir = Convert.ToString(dataGridView1[1, index].Value);
            Surname = Convert.ToString(dataGridView1[2, index].Value);
            Name = Convert.ToString(dataGridView1[2, index].Value);
            NomerTelefony = Convert.ToString(dataGridView1[2, index].Value);
            Pasport = Convert.ToString(dataGridView1[2, index].Value);
            TicketsID = Convert.ToString(dataGridView1[2, index].Value);
            ReysID = Convert.ToString(dataGridView1[2, index].Value);

            f.label2.Text = ID_Pasagir + " - " + ID_Pasagir + " - " + Surname + " - " + Name + "-" + NomerTelefony + "-" + Pasport + "-" + TicketsID + "-" + ReysID;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Pasagir();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Pasagir] SET ";
            string ID_Pasagir, Surname, Name, NomerTelefony, Pasport, TicketsID, ReysID;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form19 f = new Form19();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            ID_Pasagir = dataGridView1[0, index].Value.ToString();
            Surname = dataGridView1[0, index].Value.ToString();
            Name = dataGridView1[1, index].Value.ToString();
            NomerTelefony = dataGridView1[2, index].Value.ToString();
            Pasport = dataGridView1[2, index].Value.ToString();
            TicketsID = dataGridView1[2, index].Value.ToString();
            ReysID = dataGridView1[2, index].Value.ToString();

            f.textBox1.Text = Surname;
            f.textBox2.Text = Name;
            f.textBox3.Text = NomerTelefony;
            f.textBox4.Text = Pasport;
            f.textBox5.Text = TicketsID;
            f.textBox6.Text = ReysID;

            if (f.ShowDialog() == DialogResult.OK)
            {
                Surname = f.textBox1.Text;
                Name = f.textBox2.Text;
                NomerTelefony = f.textBox3.Text;
                Pasport = f.textBox4.Text;
                TicketsID = f.textBox5.Text;
                ReysID = f.textBox5.Text;

                SqlText += "Surname = \'" + Surname + "\', Name = '" + Name + "\', NomerTelefony = '" + NomerTelefony + "\', Pasport = '" + Pasport + "\', TicketsID = '" + TicketsID + "', ReysID = '" + ReysID + "";
                SqlText += "WHERE [Reys].Reys_ID = " + ID_Pasagir;
                MyExecuteNonQuery(SqlText);
                Pasagir();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
