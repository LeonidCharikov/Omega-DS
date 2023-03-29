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
    public partial class ProductForm : Form
    {
        public ProductForm()
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


        public void disp_data()
        {
            Database db = new Database();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select * FROM produkt", db.getConnecion());
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

        private void InsertButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            //kontrola, zda produkt se stejnym nazvem jiz v databazi neexistuje
            MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM produkt WHERE Nazev = @name", db.getConnecion());
            checkCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;

            db.openConnection();

            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Product already exists!");
                db.closeConnection();
                return;
            }

            //kontrola, zda dodavatel s danym ID existuje
            MySqlCommand checkSupplierCommand = new MySqlCommand("SELECT COUNT(*) FROM Vyrobce WHERE ID = @supplierId", db.getConnecion());
            checkSupplierCommand.Parameters.Add("@supplierId", MySqlDbType.Int32).Value = SupplierField.Text;

            int supplierCount = Convert.ToInt32(checkSupplierCommand.ExecuteScalar());

            if (supplierCount == 0)
            {
                MessageBox.Show("Supplier with this ID not exist!");
                db.closeConnection();
                return;
            }

            //vlozeni produktu do databaze
            MySqlCommand insertCommand = new MySqlCommand("INSERT INTO produkt(`Nazev`,`Pocet_kusu`,`Cena`,`Popis`, `vyrobce_id`) VALUES (@name, @piece, @price, @desc, @supplier)", db.getConnecion());

            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            insertCommand.Parameters.Add("@piece", MySqlDbType.Int32).Value = PieceField.Text;
            insertCommand.Parameters.Add("@price", MySqlDbType.Float).Value = PriceField.Text;
            insertCommand.Parameters.Add("@desc", MySqlDbType.Text).Value = DescField.Text;
            insertCommand.Parameters.Add("@supplier", MySqlDbType.Int32).Value = SupplierField.Text;

            if (insertCommand.ExecuteNonQuery() == 1)
            {
                disp_data();
                MessageBox.Show("Product created!");
            }
            else
            {
                MessageBox.Show("Error, something went wrong!");
            }

            db.closeConnection();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.openConnection();

            // Kontrola, zda existují odkazy na tento záznam v jiných tabulkách
            MySqlCommand checkCommand = new MySqlCommand("SELECT * FROM objednavka WHERE `produkt_id` = @id", db.getConnecion());
            checkCommand.Parameters.AddWithValue("@id", IDField.Text);
            MySqlDataReader reader = checkCommand.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Nejde smazat protoze udaj navazuje na jinou tabulku");
                db.closeConnection();
                return;
            }
            reader.Close();

            MySqlCommand command = new MySqlCommand("DELETE FROM produkt WHERE `Nazev` = @name OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Product deleted!");
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
            string sql = "UPDATE produkt SET ";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(NameField.Text))
            {
                sql += "`Nazev`=@name, ";
                parameters.Add(new MySqlParameter("@name", NameField.Text));
            }

            if (!string.IsNullOrEmpty(PieceField.Text))
            {
                sql += "`Pocet_kusu`=@piece, ";
                parameters.Add(new MySqlParameter("@piece", PieceField.Text));
            }

            if (!string.IsNullOrEmpty(PriceField.Text))
            {
                sql += "`Cena`=@price, ";
                parameters.Add(new MySqlParameter("@price", PriceField.Text));
            }

            if (!string.IsNullOrEmpty(DescField.Text))
            {
                sql += "`Popis`=@desc, ";
                parameters.Add(new MySqlParameter("@desc", DescField.Text));
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
                MessageBox.Show("Product updated!");
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
            MySqlCommand command = new MySqlCommand("Select * FROM produkt WHERE `Nazev` = @name OR `ID` = @id", db.getConnecion());
            command.Parameters.AddWithValue("@name", NameField.Text);
            command.Parameters.AddWithValue("@id", IDField.Text);
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0) // Check if the DataTable is empty
            {
                MessageBox.Show("Product not found!");
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
