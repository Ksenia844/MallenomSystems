using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetalHub
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Авторизация";
            panel1A.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MetalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM Пользователи WHERE ФИО = N'{textBox1.Text}' AND Пароль = '{textBox2.Text}'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                
                MessageBox.Show("Успешный вход!!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
