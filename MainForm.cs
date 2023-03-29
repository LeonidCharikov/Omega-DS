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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            Database db = new Database();
            try
            {
                db.openConnection();
                label3.Text = "Connected";
                label3.ForeColor = Color.Green;
                db.closeConnection();
            }
            catch
            {
                label3.Text = "Not Connected";
                label3.ForeColor = Color.Red;
            }
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

        private void RollUp_Click(object sender, EventArgs e)
        {

        }

        private void RollUp_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void RollUp_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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

        private void InsertButton_MouseCaptureChanged(object sender, EventArgs e)
        {

        }


        private void OrderButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }

        private void CompanyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanyForm companyForm = new CompanyForm();
            companyForm.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void SupplierButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierForm supplierForm = new SupplierForm();
            supplierForm.Show();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewField viewForm = new ViewField();
            viewForm.Show();
        }


    }
}
