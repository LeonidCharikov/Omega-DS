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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
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
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM vyrobce WHERE `Nazev` = @name", db.getConnecion());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            db.openConnection();

            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("Supplier already exists!");
                db.closeConnection();
                return;
            }

            command = new MySqlCommand("INSERT INTO vyrobce(`Nazev`) VALUES (@name)", db.getConnecion());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                disp_data();
                MessageBox.Show("Supplier created!");
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
            MySqlCommand command = new MySqlCommand("Select * FROM Vyrobce", db.getConnecion());
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            db.closeConnection();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.openConnection();

            // Kontrola, zda existují odkazy na tento záznam v jiných tabulkách
            MySqlCommand checkCommand = new MySqlCommand("SELECT * FROM produkt WHERE `vyrobce_id` = @id", db.getConnecion());
            checkCommand.Parameters.AddWithValue("@id", IDField.Text);
            MySqlDataReader reader = checkCommand.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Nejde smazat protoze udaj navazuje na jinou tabulku");
                db.closeConnection();
                return;
            }
            reader.Close();

            MySqlCommand command = new MySqlCommand("DELETE FROM Vyrobce WHERE `Nazev` = @name OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Supplier deleted!");
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
            string sql = "UPDATE Vyrobce SET ";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(NameField.Text))
            {
                sql += "`Nazev`=@name, ";
                parameters.Add(new MySqlParameter("@name", NameField.Text));
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
            MySqlCommand command = new MySqlCommand("Select * FROM Vyrobce WHERE `Nazev` = @name OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0) // Check if the DataTable is empty
            {
                MessageBox.Show("Supplier not found!");
            }
            else
            {
                dataGridView1.DataSource = table;
            }
            db.closeConnection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            disp_data();
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
