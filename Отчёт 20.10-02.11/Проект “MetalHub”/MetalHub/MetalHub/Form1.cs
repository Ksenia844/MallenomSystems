using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalHub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenLoginForm();
            
        }
        private void OpenLoginForm()
        {
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                panel2.Visible = false;
            }
            else
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Материалы", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Таблицы";

            Control panel2 = this.Controls["panel2"];
            if (panel2 is Panel p)
            {
                foreach (Control control in p.Controls)
                {
                    if (control is Button button)
                    {
                        button.Visible = true;
                    }
                }
                panel2.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Партии", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Производители", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Результаты_Проверки", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Типы_ИСпытаний", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Роли", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Controls.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Пользователи", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Пользователи";
            this.dataGridView1.Controls.Clear();
            Control panel2 = this.Controls["panel2"];
            if (panel2 is Panel p)
            {
                foreach (Control control in p.Controls)
                {
                    if (control is Button button)
                    {

                        // Оставляем видимыми только нужные кнопки («Роли», «Пользователи»)
                        bool showButton = button.Text == "Роли" ||
                                          button.Text == "Пользователи";

                        button.Visible = showButton;
                    }
                }
            }
        }
    }
}
