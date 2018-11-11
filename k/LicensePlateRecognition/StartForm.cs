using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LicensePlateRecognition
{
    public partial class StartForm : Form
    {
        int count = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=licenseDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public StartForm()
        {
            InitializeComponent();
            //для входа
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            //forgetButton.Visible = true;
            enterButton.Visible = true;
            label4.Visible = false;
            label3.Visible = false;
            //Для регистрации
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            createButton.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            //Справка
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dbo.Table_persons where username='"+textBox1.Text+
                "' and password='"+textBox2.Text+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)//логин пароль не совпадают 
            {
                MessageBox.Show("Username password doesnot match");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Hide(); //и закрываем форму2
            }

            //if (textBox1.Text == "login" && textBox2.Text == "password") //проверяем пароль
            //в зависимости от результатов проверки устанавливаем DialogResult.OK 
            //else
            //this.DialogResult = DialogResult.Abort; //или DialogResult.Abort
            
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Точно хотите выйти?", "Выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //Если нажал Да
            {
                this.Close();
            }
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //для входа
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            //forgetButton.Visible = true;
            enterButton.Visible = true;
            label4.Visible = false;
            label3.Visible = false;
            //Для регистрации
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            createButton.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            //Справка
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            //Для входа
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            //forgetButton.Visible = false;
            enterButton.Visible = false;
            label4.Visible = true;
            label3.Visible = false;
            //Для регистрации
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            createButton.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            //Справка
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;

        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            //для входа
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            //forgetButton.Visible = false;
            enterButton.Visible = false;
            label4.Visible = false;
            label3.Visible = true;
            //Для регистрации
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            createButton.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            //Справка
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != ""){
                string sql = "INSERT dbo.Table_persons (fullname, username, password, email, question) VALUES (@ИмяФамилия, @Логин, @Пароль, @Почта, @Вопрос)";
                SqlCommand cmd_SQL = new SqlCommand(sql, con);

                cmd_SQL.Parameters.AddWithValue("@ИмяФамилия", textBox3.Text);
                cmd_SQL.Parameters.AddWithValue("@Логин", textBox4.Text);
                cmd_SQL.Parameters.AddWithValue("@Пароль", textBox5.Text);
                cmd_SQL.Parameters.AddWithValue("@Почта", textBox6.Text);
                cmd_SQL.Parameters.AddWithValue("@Вопрос", textBox7.Text);
                int n = cmd_SQL.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Не введено одно/несколько из полей (*)");
            }
           


        }
    }
}
