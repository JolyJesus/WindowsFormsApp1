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
    public partial class Form1 : Form
    {
        string ConnStr = @"Data Source=DESKTOP-1TP28HN;Initial Catalog=Airoport1;Integrated Security=True";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   Litak();
            Aviakompania();
            


        }

        private void Litak()
        {
            string SqlText = "SELECT * FROM [Litak]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Litak]");
            dataGridView1.DataSource = ds.Tables["[Litak]"].DefaultView;
        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // на основі виділеного рядка в таблиці Source вивести таблицю Emission
            // визначити кількість рядків в dataGridView1
            int n = dataGridView1.RowCount;
            int row = dataGridView1.CurrentRow.Index;

            if (n != (row + 1)) // Перевірка, чи на клацнули на останньому рядку
                Aviakompania();
        }
        // Показати таблицю Emissions
        private void Aviakompania()
        {
            // сформувати рядок SQL-запиту
            string SqlText = "SELECT * FROM [Aviakompania]";
            int index;
            string Litak_ID;
            index = dataGridView1.CurrentRow.Index;
            Litak_ID = dataGridView1[0, index].Value.ToString();

            
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Aviakompania]");
            dataGridView2.DataSource = ds.Tables["[Aviakompania]"].DefaultView; 
        }
        // Метод, для зручної обробки команд INSERT, UPDATE, DELETE
        // метод отримує SQL-запит
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

        private void button1_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Litak] ([Litak_ID],[Nazva],[Aviakompania_ID],[Model],[KilkistMisc]) VALUES (1, 'Litak-01','1','Model-01','100') ";
            Form2 f = new Form2(); // створити екземпляр вікна

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформувати SQL-рядок
                SqlText = "INSERT INTO [Litak] ([Nazva], [Aviakompania_ID],[Model],[KilkistMisc]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox3.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox4.Text + "\')";

                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразати таблицю Source
                Litak();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Litak] SET ";
            string Litak_ID, Nazva, Aviakompania_ID, Model, KilkistMisc;

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form3 f = new Form3();

            // заповнити форму даними перед відкриттям
            index = dataGridView1.CurrentRow.Index;
            Litak_ID = dataGridView1[0, index].Value.ToString();
            Nazva = dataGridView1[1, index].Value.ToString();
            Aviakompania_ID = dataGridView1[2, index].Value.ToString();
            Model = dataGridView1[3, index].Value.ToString();
            KilkistMisc = dataGridView1[4, index].Value.ToString();

            f.textBox1.Text = Nazva;
            f.textBox2.Text = Aviakompania_ID;
            f.textBox3.Text = Model;
            f.textBox4.Text = KilkistMisc;

            if (f.ShowDialog() == DialogResult.OK)
            {
                Nazva = f.textBox1.Text;
                Aviakompania_ID = f.textBox2.Text;
                Model = f.textBox3.Text;
                KilkistMisc = f.textBox4.Text;
                SqlText += "Nazva = \'" + Nazva + "\', Aviakompania = '" + Aviakompania_ID + "\', Model = '" + Model + "\', KilkistMisc = '"+ KilkistMisc +".";
                SqlText += "WHERE [Litak].Litak_ID = "+ Litak_ID;
                MyExecuteNonQuery(SqlText);
                Litak();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index, n;
            string Litak_ID;
            string Nazva, Aviakompania_ID, Model, KilkistMisc;
            string SqlText = "DELETE FROM [Litak] WHERE [Litak].Litak_ID = ";

            // перевірка, чи є взагалі записи в таблиці Source
            n = dataGridView1.Rows.Count;
            if (n == 1) return;

            Form5 f = new Form5();
            index = dataGridView1.CurrentRow.Index;
            Litak_ID = Convert.ToString(dataGridView1[0, index].Value);

            // сформувати SQL-команду
            SqlText = SqlText + Litak_ID;

            // заповнити інформаційну довідку у вікні Form5
            Nazva = Convert.ToString(dataGridView1[1, index].Value);
            Aviakompania_ID = Convert.ToString(dataGridView1[2, index].Value);
            Model = Convert.ToString(dataGridView1[2, index].Value);
            KilkistMisc = Convert.ToString(dataGridView1[2, index].Value);

            f.label2.Text = Litak_ID + " - " + Nazva + " - " + Aviakompania_ID + " - " + Model + " - " + KilkistMisc;

            if (f.ShowDialog() == DialogResult.OK) // вивести форму
            {
                // виконати SQL-команду
                MyExecuteNonQuery(SqlText);
                // відобразити таблицю Source
                Litak();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO[Aviakompania] ([Aviakompania_ID],[Nazva],[NomerTelefony],[EMail],[Litak_ID]) VALUES(1, 'Litak-01', '1', 'fdd', 1)  ";
    int index; // номер виділеного рядка в таблиці Source
    string Litak_ID;
    string name;
    Form4 f = new Form4();

    // 1.1. Знайти активний рядок в Source і взяти з нього ID_Source
    index = dataGridView1.CurrentRow.Index;
    Litak_ID = Convert.ToString(dataGridView1[0, index].Value);
    name = Convert.ToString(dataGridView1[1, index].Value);

    if (f.ShowDialog() == DialogResult.OK)
    {
        // Додати дані в таблицю
        // Сформувати SQL-рядок
        SqlText = "INSERT INTO [Aviakompania] ([Litak_ID], [Nazva], [NomerTelefony], [EMail]) VALUES (";
        // Сформувати значення змінної SqlText
        SqlText = SqlText + Litak_ID + ", "; // ID_Source
        SqlText = SqlText + f.textBox1.Text + ", "; // count
        SqlText = SqlText + "\'" + f.textBox2.Text + "\', "; // Text
        SqlText = SqlText + "\'" + f.textBox3.Text + "\')"; // date

        // виконати SQL-команду
        MyExecuteNonQuery(SqlText);
        // вивести таблицю Emission
        Aviakompania();
    }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index, index_src, n;
            string SqlText = "UPDATE [Aviakompania] SET ";
            string Aviakompania_ID, Litak_ID, Nazva, NomerTelefony, EMail;
            string Name_Source;

            // перевірка, чи є взагалі записи в таблиці Emission
            n = dataGridView2.Rows.Count;
            if (n == 1) return;

            Form7 f = new Form7();

            // заповнити форму даними перед відкриттям
            index = dataGridView2.CurrentRow.Index;
            Aviakompania_ID = dataGridView2[0, index].Value.ToString();
            Litak_ID = dataGridView2[1, index].Value.ToString();
            Nazva = dataGridView2[2, index].Value.ToString();
            NomerTelefony = dataGridView2[3, index].Value.ToString();
            EMail = dataGridView2[4, index].Value.ToString();

            index_src = dataGridView1.CurrentRow.Index;
            Name_Source = dataGridView1[1, index_src].Value.ToString();

            //
            f.label1.Text = Name_Source;
            f.textBox1.Text = Nazva;
            f.textBox2.Text = NomerTelefony;
            f.textBox3.Text = EMail;

            if (f.ShowDialog() == DialogResult.OK)
            {
                Nazva = f.textBox1.Text;
                NomerTelefony = f.textBox2.Text;
                EMail = f.textBox3.Text;

                SqlText += "Nazva = " + Nazva + ", NomerTelefony = \'" + NomerTelefony + "\', EMail = \'" + EMail + "\' ";
                SqlText += "WHERE [Aviakompania].Aviakompania_ID = " + Aviakompania_ID;

                MyExecuteNonQuery(SqlText);
                Aviakompania();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index, n;
            string Aviakompania_ID;
            string Nazva, NomerTelefony;
            string SqlText = "DELETE FROM [Aviakompania] WHERE [Aviakompania].Aviakompania_ID = ";

            // перевірка, чи є взагалі записи в таблиці Emission
            n = dataGridView2.Rows.Count;
            if (n == 1) return;

            Form6 f = new Form6();

            index = dataGridView2.CurrentRow.Index;
            Aviakompania_ID = Convert.ToString(dataGridView2[0, index].Value);

            // сформувати SQL-команду
            SqlText += Aviakompania_ID;

            // заповнити інформаційну довідку у вікні Form6
            Nazva = Convert.ToString(dataGridView2[2, index].Value);
            NomerTelefony = Convert.ToString(dataGridView2[3, index].Value);

            f.label2.Text = Aviakompania_ID + " - " + Nazva + " - " + NomerTelefony;

            if (f.ShowDialog() == DialogResult.OK)
            {
                MyExecuteNonQuery(SqlText); // виконати SQL-команду
                Aviakompania(); // відобразити таблицю Emission
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Form8 f = new Form8();

            
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            Form9 f = new Form9();
            
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            Form10 f = new Form10();
                        f.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            f.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form24 f = new Form24();
            f.ShowDialog();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form28 f = new Form28();
            f.ShowDialog();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form32 f = new Form32();
            f.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form36 f = new Form36();
            f.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
