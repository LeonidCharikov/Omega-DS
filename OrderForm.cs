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
    public partial class OrderForm : Form
    {
        public OrderForm()
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



        private void InsertButton_Click(object sender, EventArgs e)
        {
            Database db = new Database();

            //kontrola, zda společnost s ID existuje v databázi
            MySqlCommand checkCompanyCommand = new MySqlCommand("SELECT COUNT(*) FROM zakaznik WHERE ID = @id", db.getConnecion());
            checkCompanyCommand.Parameters.AddWithValue("@id", CompanyField.Text);

            //kontrola, zda produkt s ID existuje v databázi
            MySqlCommand checkProductCommand = new MySqlCommand("SELECT COUNT(*) FROM produkt WHERE ID = @id", db.getConnecion());
            checkProductCommand.Parameters.AddWithValue("@id", ProductField.Text);

            db.openConnection();

            int companyCount = Convert.ToInt32(checkCompanyCommand.ExecuteScalar());
            int productCount = Convert.ToInt32(checkProductCommand.ExecuteScalar());

            if (companyCount == 0)
            {
                MessageBox.Show("Company with this ID not exist!");
                db.closeConnection();
                return;
            }

            if (productCount == 0)
            {
                MessageBox.Show("Product with this ID not exist!");
                db.closeConnection();
                return;
            }

            //kontrola, zda je dostatek produktů skladem
            MySqlCommand checkStockCommand = new MySqlCommand("SELECT Pocet_kusu FROM produkt WHERE ID = @id", db.getConnecion());
            checkStockCommand.Parameters.AddWithValue("@id", ProductField.Text);

            int productStock = Convert.ToInt32(checkStockCommand.ExecuteScalar());
            int orderQuantity = Convert.ToInt32(NumberField.Text);

            if (orderQuantity > productStock)
            {
                MessageBox.Show("No products in stock!");
                db.closeConnection();
                return;
            }

            //výpočet celkové ceny objednávky
            MySqlCommand command = new MySqlCommand("SELECT Cena FROM produkt WHERE ID = @id", db.getConnecion());
            command.Parameters.AddWithValue("@id", ProductField.Text);
            double price = Convert.ToDouble(command.ExecuteScalar());
            double totalPrice = price * orderQuantity;

            //aktualizace počtu kusů v tabulce produkt
            MySqlCommand updateStockCommand = new MySqlCommand("UPDATE produkt SET Pocet_kusu = Pocet_kusu - @number WHERE ID = @id", db.getConnecion());
            updateStockCommand.Parameters.AddWithValue("@number", orderQuantity);
            updateStockCommand.Parameters.AddWithValue("@id", ProductField.Text);
            updateStockCommand.ExecuteNonQuery();

            //vložení objednávky do databáze
            MySqlCommand insertCommand = new MySqlCommand("INSERT INTO objednavka(`zak_id`,`produkt_id`,`Pocet_kusu`,`Datum`,`Platba`, `Celkova_cena`) VALUES (@zak_id, @product_id,@Number, @date, @pay, @totalPrice)", db.getConnecion());

            insertCommand.Parameters.Add("@zak_id", MySqlDbType.VarChar).Value = CompanyField.Text;
            insertCommand.Parameters.Add("@product_id", MySqlDbType.VarChar).Value = ProductField.Text;
            insertCommand.Parameters.Add("@pay", MySqlDbType.VarChar).Value = PayField.Text;
            insertCommand.Parameters.Add("@number", MySqlDbType.VarChar).Value = orderQuantity;
            insertCommand.Parameters.AddWithValue("@date", DateTime.Now);
            insertCommand.Parameters.AddWithValue("@totalPrice", totalPrice);

            if (insertCommand.ExecuteNonQuery() == 1)
            {
                disp_data();
                MessageBox.Show("Order created!");
            }
            else
            {
                MessageBox.Show("Error, something wrong!");

            }

            db.closeConnection();
        }





        public void disp_data()
        {
            Database db = new Database();
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Select * FROM objednavka", db.getConnecion());
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
            MySqlCommand command = new MySqlCommand("DELETE FROM objednavka WHERE `zak_id` = @zak AND `produkt_id` = @produkt OR `ID` = @order", db.getConnecion());
            command.Parameters.AddWithValue("@zak", CompanyField.Text);
            command.Parameters.AddWithValue("@produkt", ProductField.Text);
            command.Parameters.AddWithValue("@order", OrderField.Text);
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Order deleted!");
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
            MySqlCommand command = new MySqlCommand("UPDATE objednavka SET `Platba`=@pay WHERE `zak_id` = @zak AND `produkt_id` = @produkt OR `ID` = @order", db.getConnecion());
            command.Parameters.AddWithValue("@zak", CompanyField.Text);
            command.Parameters.AddWithValue("@produkt", ProductField.Text);
            command.Parameters.AddWithValue("@order", OrderField.Text);
            command.Parameters.AddWithValue("@pay", PayField.Text);
            int rowsAffected = command.ExecuteNonQuery();
            db.closeConnection();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Order updated!");
                disp_data();
            }
            else
            {
                MessageBox.Show("No matching records found!");
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM objednavka WHERE `zak_id` = @zak AND `produkt_id` = @produkt OR `ID` = @order", db.getConnecion());
            command.Parameters.AddWithValue("@zak", CompanyField.Text);
            command.Parameters.AddWithValue("@produkt", ProductField.Text);
            command.Parameters.AddWithValue("@order", OrderField.Text);
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0) // Check if the DataTable is empty
            {
                MessageBox.Show("Order not found!");
            }
            else
            {
                dataGridView1.DataSource = table;
            }
            db.closeConnection();
        }


        private void helpImage_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
    }
}

