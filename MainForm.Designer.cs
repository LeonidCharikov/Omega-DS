
namespace DB
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ViewButton = new System.Windows.Forms.Button();
            this.SupplierButton = new System.Windows.Forms.Button();
            this.CompanyButton = new System.Windows.Forms.Button();
            this.ProductButton = new System.Windows.Forms.Button();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.OrderButton = new System.Windows.Forms.Button();
            this.helpImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RollUp = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(109)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ViewButton);
            this.panel1.Controls.Add(this.SupplierButton);
            this.panel1.Controls.Add(this.CompanyButton);
            this.panel1.Controls.Add(this.ProductButton);
            this.panel1.Controls.Add(this.ExitLabel);
            this.panel1.Controls.Add(this.OrderButton);
            this.panel1.Controls.Add(this.helpImage);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(379, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Connection status:";
            // 
            // ViewButton
            // 
            this.ViewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ViewButton.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewButton.Location = new System.Drawing.Point(457, 251);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(185, 87);
            this.ViewButton.TabIndex = 7;
            this.ViewButton.Text = "View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // SupplierButton
            // 
            this.SupplierButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SupplierButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SupplierButton.Location = new System.Drawing.Point(208, 251);
            this.SupplierButton.Name = "SupplierButton";
            this.SupplierButton.Size = new System.Drawing.Size(185, 87);
            this.SupplierButton.TabIndex = 6;
            this.SupplierButton.Text = "Supplier";
            this.SupplierButton.UseVisualStyleBackColor = true;
            this.SupplierButton.Click += new System.EventHandler(this.SupplierButton_Click);
            // 
            // CompanyButton
            // 
            this.CompanyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CompanyButton.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyButton.Location = new System.Drawing.Point(323, 110);
            this.CompanyButton.Name = "CompanyButton";
            this.CompanyButton.Size = new System.Drawing.Size(185, 87);
            this.CompanyButton.TabIndex = 5;
            this.CompanyButton.Text = "Company";
            this.CompanyButton.UseVisualStyleBackColor = true;
            this.CompanyButton.Click += new System.EventHandler(this.CompanyButton_Click);
            // 
            // ProductButton
            // 
            this.ProductButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ProductButton.Location = new System.Drawing.Point(557, 110);
            this.ProductButton.Name = "ProductButton";
            this.ProductButton.Size = new System.Drawing.Size(185, 87);
            this.ProductButton.TabIndex = 4;
            this.ProductButton.Text = "Product";
            this.ProductButton.UseVisualStyleBackColor = true;
            this.ProductButton.Click += new System.EventHandler(this.ProductButton_Click);
            this.ProductButton.MouseCaptureChanged += new System.EventHandler(this.InsertButton_MouseCaptureChanged);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitLabel.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitLabel.Location = new System.Drawing.Point(3, 424);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(78, 23);
            this.ExitLabel.TabIndex = 3;
            this.ExitLabel.Text = "Log out";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            this.ExitLabel.MouseEnter += new System.EventHandler(this.ExitLabel_MouseEnter);
            this.ExitLabel.MouseLeave += new System.EventHandler(this.ExitLabel_MouseLeave);
            // 
            // OrderButton
            // 
            this.OrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OrderButton.Font = new System.Drawing.Font("Berlin Sans FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderButton.Location = new System.Drawing.Point(95, 110);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(185, 87);
            this.OrderButton.TabIndex = 2;
            this.OrderButton.Text = "Orders";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click_1);
            // 
            // helpImage
            // 
            this.helpImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpImage.Image = global::DB.Properties.Resources.help;
            this.helpImage.Location = new System.Drawing.Point(750, 397);
            this.helpImage.Name = "helpImage";
            this.helpImage.Size = new System.Drawing.Size(47, 50);
            this.helpImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.helpImage.TabIndex = 1;
            this.helpImage.TabStop = false;
            this.helpImage.Click += new System.EventHandler(this.helpImage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(190)))), ((int)(((byte)(126)))));
            this.panel2.Controls.Add(this.RollUp);
            this.panel2.Controls.Add(this.CloseButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 71);
            this.panel2.TabIndex = 0;
            // 
            // RollUp
            // 
            this.RollUp.AutoSize = true;
            this.RollUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RollUp.Location = new System.Drawing.Point(750, -13);
            this.RollUp.Name = "RollUp";
            this.RollUp.Size = new System.Drawing.Size(29, 39);
            this.RollUp.TabIndex = 2;
            this.RollUp.Text = "-";
            this.RollUp.Click += new System.EventHandler(this.RollUp_Click);
            this.RollUp.MouseEnter += new System.EventHandler(this.RollUp_MouseEnter);
            this.RollUp.MouseLeave += new System.EventHandler(this.RollUp_MouseLeave);
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CloseButton.Location = new System.Drawing.Point(776, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(24, 24);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "X";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label RollUp;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox helpImage;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Button SupplierButton;
        private System.Windows.Forms.Button CompanyButton;
        private System.Windows.Forms.Button ProductButton;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}