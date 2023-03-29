using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            NameField.Text = "Enter Name";
            NameField.ForeColor = Color.Gray;
            SurnameField.Text = "Enter Surname";
            SurnameField.ForeColor = Color.Gray;
            loginField.Text = "Enter Login";
            loginField.ForeColor = Color.Gray;
            passField.Text = "Enter Password";
            passField.ForeColor = Color.Gray;
            AddressField.Text = "Enter Address";
            AddressField.ForeColor = Color.Gray;
            NumberField.Text = "Enter Number";
            NumberField.ForeColor = Color.Gray;
            PostField.Text = "Enter Post Code";
            PostField.ForeColor = Color.Gray;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }

        private void RollUp_Click(object sender, EventArgs e)
        {

        }

        private void RollUp_MouseEnter(object sender, EventArgs e)
        {
            RollUp.ForeColor = Color.White;
        }

        private void RollUp_MouseLeave(object sender, EventArgs e)
        {
            RollUp.ForeColor = Color.Black;
        }

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Enter Name")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Enter Name";
                NameField.ForeColor = Color.Gray;
            }
        }

        private void SurnameField_Enter(object sender, EventArgs e)
        {
            if (SurnameField.Text == "Enter Surname")
            {
                SurnameField.Text = "";
                SurnameField.ForeColor = Color.Black;
            }
        }

        private void SurnameField_Leave(object sender, EventArgs e)
        {
            if (SurnameField.Text == "")
            {
                SurnameField.Text = "Enter Surname";
                SurnameField.ForeColor = Color.Gray;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Enter Login")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Enter Login";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Enter Password")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Enter Password";
                passField.ForeColor = Color.Gray;
            }
        }

        private void AddressField_Enter(object sender, EventArgs e)
        {
            if (AddressField.Text == "Enter Address")
            {
                AddressField.Text = "";
                AddressField.ForeColor = Color.Black;
            }
        }

        private void AddressField_Leave(object sender, EventArgs e)
        {
            if (AddressField.Text == "")
            {
                AddressField.Text = "Enter Address";
                AddressField.ForeColor = Color.Gray;
            }
        }

        private void NumberField_Enter(object sender, EventArgs e)
        {
            if (NumberField.Text == "Enter Number")
            {
                NumberField.Text = "";
                NumberField.ForeColor = Color.Black;
            }
        }

        private void NumberField_Leave(object sender, EventArgs e)
        {
            if (NumberField.Text == "")
            {
                NumberField.Text = "Enter Number";
                NumberField.ForeColor = Color.Gray;
            }
        }

        private void PostField_Enter(object sender, EventArgs e)
        {
            if (PostField.Text == "Enter Post Code")
            {
                PostField.Text = "";
                PostField.ForeColor = Color.Black;
            }
        }

        private void PostField_Leave(object sender, EventArgs e)
        {
            if (PostField.Text == "")
            {
                PostField.Text = "Enter Post Code";
                PostField.ForeColor = Color.Gray;
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {

            if (NameField.Text == "Enter Name")
            {
                MessageBox.Show("Enter Name");
                return;
            }

            if (SurnameField.Text == "Enter Surname")
            {
                MessageBox.Show("Enter Surname");
                return;
            }

            if (loginField.Text == "Enter Login")
            {
                MessageBox.Show("Enter Login");
                return;
            }

            if (passField.Text == "Enter Password")
            {
                MessageBox.Show("Enter Password");
                return;
            }

            if (AddressField.Text == "Enter Address")
            {
                MessageBox.Show("Enter Address");
                return;
            }

            if (NumberField.Text == "Enter Number")
            {
                MessageBox.Show("Enter Number");
                return;
            }

            if (PostField.Text == "Enter Post Code")
            {
                MessageBox.Show("Enter Post Code");
                return;
            }


            if (isUserExist())
                return;

            Database db = new Database();
            if (db.getConnecion().State != ConnectionState.Open)
            {
                MessageBox.Show("Program not connected to database!");
                return;
            }
            MySqlCommand command = new MySqlCommand("INSERT INTO zamestnanec(`Jmeno`,`Prijmeni`,`Adresa`,`Cislo`,`PSC`,`Login`,`Passwd`) VALUES (@Name, @Surname, @Address, @Num, @PSC, @Login, @Passwd)", db.getConnecion());

            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@Surname", MySqlDbType.VarChar).Value = SurnameField.Text;
            command.Parameters.Add("@Address", MySqlDbType.VarChar).Value = AddressField.Text;
            command.Parameters.Add("@Num", MySqlDbType.VarChar).Value = NumberField.Text;
            command.Parameters.Add("@PSC", MySqlDbType.Int32).Value = PostField.Text;
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@Passwd", MySqlDbType.VarChar).Value = passField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Account created!");
            else
                MessageBox.Show("Error, something wrong!");

            db.closeConnection();
        }

        public Boolean isUserExist()
        {
            Database db = new Database();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("Select `Login` from zamestnanec WHERE `Login` = @uL", db.getConnecion());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Login already exist, plase enter new info");
                return true;
            }
            else
                return false;
        }



        private void LoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void LoginLabel_MouseEnter(object sender, EventArgs e)
        {
            LoginLabel.ForeColor = Color.White;
        }

        private void LoginLabel_MouseLeave(object sender, EventArgs e)
        {
            LoginLabel.ForeColor = Color.Black;
        }
    }
}
