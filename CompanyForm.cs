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
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void ExitLabel_MouseEnter(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.White;
        }

        private void ExitLabel_MouseLeave(object sender, EventArgs e)
        {
            ExitLabel.ForeColor = Color.Black;
        }

        private void helpImage_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            // Kontrola, zda již existuje hodnota se stejným názvem v databázi
            MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM zakaznik WHERE `Nazev` = @name OR `ICO` = @ico", db.getConnecion());
            checkCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            checkCommand.Parameters.Add("@ico", MySqlDbType.VarChar).Value = ICOField.Text;
            db.openConnection();
            int count = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("Company already exists!");
                db.closeConnection();
                return;
            }

            // Kontrola počtu čísel v @ico a @post parametrech
            int ico, post;
            if (!int.TryParse(ICOField.Text, out ico) || ICOField.Text.Length != 10)
            {
                MessageBox.Show("Wrong number of digits in ICO, you need write 10 numbers!");
                db.closeConnection();
                return;
            }
            if (!int.TryParse(PostField.Text, out post) || PostField.Text.Length != 5)
            {
                MessageBox.Show("Wrong number of digits in PSC, you need write 5 numbers!");
                db.closeConnection();
                return;
            }

            // Vložení nového záznamu do databáze
            MySqlCommand insertCommand = new MySqlCommand("INSERT INTO zakaznik(`Nazev`,`ICO`,`Adresa`,`PSC`) VALUES (@name, @ico, @adresa, @post)", db.getConnecion());
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            insertCommand.Parameters.Add("@ico", MySqlDbType.Int32).Value = ico;
            insertCommand.Parameters.Add("@adresa", MySqlDbType.VarChar).Value = AddressField.Text;
            insertCommand.Parameters.Add("@post", MySqlDbType.Int32).Value = post;

            if (insertCommand.ExecuteNonQuery() == 1)
            {
                disp_data();
                MessageBox.Show("Company created!");
            }
            else
                MessageBox.Show("Error, something wrong!");

            db.closeConnection();
        }


        public void disp_data()
        {
            Database db = new Database();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select * FROM zakaznik", db.getConnecion());
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            db.closeConnection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            disp_data();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.openConnection();

            // Kontrola, zda existují odkazy na tento záznam v jiných tabulkách
            MySqlCommand checkCommand = new MySqlCommand("SELECT * FROM objednavka WHERE `zak_id` = @id", db.getConnecion());
            checkCommand.Parameters.AddWithValue("@id", IDField.Text);
            MySqlDataReader reader = checkCommand.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Nejde smazat protoze udaj navazuje na jinou tabulku");
                db.closeConnection();
                return;
            }
            reader.Close();

            MySqlCommand command = new MySqlCommand("DELETE FROM zakaznik WHERE `Nazev` = @name AND `ICO` = @ico OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@ICO", ICOField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Company deleted!");
                disp_data();
            }
            else
            {
                MessageBox.Show("No matching records found!");
            }
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.openConnection();

            // Vytvořime SQL příkaz UPDATE s parametry pro aktualizaci jednotlivých sloupců
            string sql = "UPDATE zakaznik SET ";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(NameField.Text))
            {
                sql += "`Nazev`=@name, ";
                parameters.Add(new MySqlParameter("@name", NameField.Text));
            }

            if (!string.IsNullOrEmpty(AddressField.Text))
            {
                sql += "`Adresa`=@address, ";
                parameters.Add(new MySqlParameter("@address", AddressField.Text));
            }

            if (!string.IsNullOrEmpty(ICOField.Text))
            {
                sql += "`ICO`=@ICO, ";
                parameters.Add(new MySqlParameter("@ICO", ICOField.Text));
            }

            if (!string.IsNullOrEmpty(PostField.Text))
            {
                sql += "`PSC`=@Post, ";
                parameters.Add(new MySqlParameter("@Post", PostField.Text));
            }

            sql = sql.Remove(sql.Length - 2); // Odebere poslední čárku a mezeru

            // Přida podmínku WHERE pro aktualizaci záznamu s konkrétním ID
            sql += " WHERE `ID`=@id";
            parameters.Add(new MySqlParameter("@id", IDField.Text));

            MySqlCommand command = new MySqlCommand(sql, db.getConnecion());
            command.Parameters.AddRange(parameters.ToArray());
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Záznam aktualizován!");
                disp_data();
            }
            else
            {
                MessageBox.Show("Záznam nebyl aktualizován. Žádné shodující se záznamy nebyly nalezeny.");
            }
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select * FROM zakaznik WHERE `Nazev` = @name AND `ICO` = @ico OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@ICO", ICOField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0) // Check if the DataTable is empty
            {
                MessageBox.Show("Company not found!");
            }
            else
            {
                dataGridView1.DataSource = table;
            }
            db.closeConnection();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
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


    }
}
