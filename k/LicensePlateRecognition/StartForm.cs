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
        struct NewUser //структура для хранения новых пользователей
        {
            public string name;
            public string login;
            public string password;
            public string email;
            public string question;
            public NewUser(string name, string login, string password, string email, string question)//инициализатор
            {
                this.name = name;
                this.login = login;
                this.password = password;
                this.email = email;
                this.question = question;
            }
        }
        List<NewUser> newUsers = new List<NewUser>() {};//массив для структуры новых пользователей
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=licenseDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public StartForm()
        {
            InitializeComponent();
            configureForm();
            //для входа
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Visible = true;
            textBox2.Visible = true;
            enterButton.Visible = true;

        }

        public void configureForm()
        {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            //forgetButton.Visible = true;
            enterButton.Visible = false;
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
            //Подтверждение аккаунта
            acceptButton.Visible = false;
            declineButton.Visible = false;
            newAccComboBox.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            //admin панель
            label16.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            entryAdminButton.Visible = false;
            label17.Visible = false;
            label16.Visible = false;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            int kek = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from dbo.Table_persons where username='"+textBox1.Text+
                "' and password='"+textBox2.Text+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            kek = Convert.ToInt32(dt.Rows.Count.ToString());
            if (kek == 0)//логин пароль не совпадают 
            {
                MessageBox.Show("Пара логин/пароль не верна");
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
            configureForm();
            //для входа
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Visible = true;
            textBox2.Visible = true;
            //forgetButton.Visible = true;
            enterButton.Visible = true;
            
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            configureForm();
            label4.Visible = true;
            //Для регистрации
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
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
            
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            configureForm();
            label3.Visible = true;
            //Справка
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
        }

        private void newaccbutton_Click(object sender, EventArgs e)
        {
            configureForm();
            //admin панель
            label16.Visible = true;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox8.Visible = true;
            textBox9.Visible = true;
            entryAdminButton.Visible = true;

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != ""){
                NewUser newUser = new NewUser(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
                newUsers.Add(newUser);
                newAccComboBox.Items.Add(newUser.login);
                newUsers.Add(newUser);
                MessageBox.Show("Учетная запись зарегестрирована и в скором времени будет активирована");
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Не введено одно/несколько из полей (*)");
            }
           


        }

 
        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (newAccComboBox.SelectedItem != null)
            {
                string currentNewUser = newAccComboBox.Text;
                for (int i = 0; i < newUsers.Count; i++)
                {
                    if (newUsers[i].login == currentNewUser)
                    {

                        DialogResult activation = MessageBox.Show("Активировать учетную запись?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (activation == DialogResult.Yes) //Если нажал Да
                        {
                            string sql = "INSERT dbo.Table_persons (fullname, username, password, email, question) VALUES (@ИмяФамилия, @Логин, @Пароль, @Почта, @Вопрос)";
                            SqlCommand cmd_SQL = new SqlCommand(sql, con);

                            cmd_SQL.Parameters.AddWithValue("@ИмяФамилия", newUsers[i].name);
                            cmd_SQL.Parameters.AddWithValue("@Логин", newUsers[i].login);
                            cmd_SQL.Parameters.AddWithValue("@Пароль", newUsers[i].password);
                            cmd_SQL.Parameters.AddWithValue("@Почта", newUsers[i].email);
                            cmd_SQL.Parameters.AddWithValue("@Вопрос", newUsers[i].question);
                            int n = cmd_SQL.ExecuteNonQuery();

                            newUsers.RemoveAt(i);
                            newAccComboBox.Items.Remove(newAccComboBox.SelectedItem);
                            newAccComboBox.Text = "";
                            label13.Text = "";
                            label14.Text = "";
                            label15.Text = "";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            if (newAccComboBox.SelectedItem != null)
            {
                string currentNewUser = newAccComboBox.Text;
                for (int i = 0; i < newUsers.Count; i++)
                {
                    if (newUsers[i].login == currentNewUser)
                    {

                        DialogResult activation = MessageBox.Show("Отклонить учетную запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (activation == DialogResult.Yes) //Если нажал Да
                        {
                            newUsers.RemoveAt(i);
                            newAccComboBox.Items.Remove(newAccComboBox.SelectedItem);
                            newAccComboBox.Text = "";
                            label13.Text = "";
                            label14.Text = "";
                            label15.Text = "";
                            

                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void newAccComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newAccComboBox.SelectedItem != null)
            {
                string currentNewUser = newAccComboBox.Text;
                for (int i = 0; i < newUsers.Count; i++)
                {
                    if (newUsers[i].login == currentNewUser)
                    {
                        label13.Text = "Login: " + newUsers[i].login;
                        label14.Text = "Name: " + newUsers[i].name;
                        label15.Text = "Email: " + newUsers[i].email;
                    }
                }
            }
        }

        private void entryAdminButton_Click(object sender, EventArgs e)
        {
            if ((textBox8.Text == "admin")&(textBox9.Text == "admin"))
            {
                acceptButton.Visible = true;
                declineButton.Visible = true;
                newAccComboBox.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = false;
                entryAdminButton.Visible = false;
                label16.Visible = false;
                label17.Visible = true;
            }
            else
            {
                MessageBox.Show("Не правильные логин/пароль");
                textBox8.Text = "";
                textBox9.Text = "";
            }
        }
    }
}
