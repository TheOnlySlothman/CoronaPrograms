namespace Pizzaria_3
{
    partial class Form1
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
            this.AddPizzaButton = new System.Windows.Forms.Button();
            this.EditorButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ingredients1 = new System.Windows.Forms.Label();
            this.price1 = new System.Windows.Forms.Label();
            this.name1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Ingredients2 = new System.Windows.Forms.Label();
            this.price2 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.Label();
            this.Pizza1RadioButton = new System.Windows.Forms.RadioButton();
            this.Pizza2RadioButton = new System.Windows.Forms.RadioButton();
            this.SizeBox = new System.Windows.Forms.ComboBox();
            this.DoughBox = new System.Windows.Forms.ComboBox();
            this.PizzaAmount = new System.Windows.Forms.NumericUpDown();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.Antal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PizzaAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPizzaButton
            // 
            this.AddPizzaButton.Location = new System.Drawing.Point(292, 336);
            this.AddPizzaButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddPizzaButton.Name = "AddPizzaButton";
            this.AddPizzaButton.Size = new System.Drawing.Size(100, 28);
            this.AddPizzaButton.TabIndex = 2;
            this.AddPizzaButton.Text = "Add Pizza";
            this.AddPizzaButton.UseVisualStyleBackColor = true;
            this.AddPizzaButton.Click += new System.EventHandler(this.AddPizzaButton_Click);
            // 
            // EditorButton
            // 
            this.EditorButton.Location = new System.Drawing.Point(792, 457);
            this.EditorButton.Name = "EditorButton";
            this.EditorButton.Size = new System.Drawing.Size(75, 23);
            this.EditorButton.TabIndex = 12;
            this.EditorButton.Text = "Editor";
            this.EditorButton.UseVisualStyleBackColor = true;
            this.EditorButton.Click += new System.EventHandler(this.EditorButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Antal,
            this.nameColumn,
            this.ingredientsColumn,
            this.priceColumn});
            this.dataGridView1.Location = new System.Drawing.Point(682, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(356, 248);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Ingredients1);
            this.panel1.Controls.Add(this.price1);
            this.panel1.Controls.Add(this.name1);
            this.panel1.Location = new System.Drawing.Point(49, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 14;
            // 
            // Ingredients1
            // 
            this.Ingredients1.AutoSize = true;
            this.Ingredients1.Location = new System.Drawing.Point(3, 59);
            this.Ingredients1.Name = "Ingredients1";
            this.Ingredients1.Size = new System.Drawing.Size(154, 34);
            this.Ingredients1.TabIndex = 2;
            this.Ingredients1.Text = "Tomatsauce, pizza ost,\r\n skinke og oregano";
            // 
            // price1
            // 
            this.price1.AutoSize = true;
            this.price1.Location = new System.Drawing.Point(119, 4);
            this.price1.Name = "price1";
            this.price1.Size = new System.Drawing.Size(46, 17);
            this.price1.TabIndex = 1;
            this.price1.Text = "label2";
            // 
            // name1
            // 
            this.name1.AutoSize = true;
            this.name1.Location = new System.Drawing.Point(13, 4);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(46, 17);
            this.name1.TabIndex = 0;
            this.name1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Ingredients2);
            this.panel2.Controls.Add(this.price2);
            this.panel2.Controls.Add(this.name2);
            this.panel2.Location = new System.Drawing.Point(49, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 15;
            // 
            // Ingredients2
            // 
            this.Ingredients2.AutoSize = true;
            this.Ingredients2.Location = new System.Drawing.Point(3, 47);
            this.Ingredients2.Name = "Ingredients2";
            this.Ingredients2.Size = new System.Drawing.Size(154, 34);
            this.Ingredients2.TabIndex = 2;
            this.Ingredients2.Text = "Tomatsauce, pizza ost,\r\n peperoni og oregano\r\n";
            // 
            // price2
            // 
            this.price2.AutoSize = true;
            this.price2.Location = new System.Drawing.Point(119, 4);
            this.price2.Name = "price2";
            this.price2.Size = new System.Drawing.Size(24, 17);
            this.price2.TabIndex = 1;
            this.price2.Text = "55";
            // 
            // name2
            // 
            this.name2.AutoSize = true;
            this.name2.Location = new System.Drawing.Point(13, 4);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(49, 17);
            this.name2.TabIndex = 0;
            this.name2.Text = "pizza2";
            // 
            // Pizza1RadioButton
            // 
            this.Pizza1RadioButton.AutoSize = true;
            this.Pizza1RadioButton.Checked = true;
            this.Pizza1RadioButton.Location = new System.Drawing.Point(13, 54);
            this.Pizza1RadioButton.Name = "Pizza1RadioButton";
            this.Pizza1RadioButton.Size = new System.Drawing.Size(17, 16);
            this.Pizza1RadioButton.TabIndex = 16;
            this.Pizza1RadioButton.TabStop = true;
            this.Pizza1RadioButton.Tag = "1";
            this.Pizza1RadioButton.UseVisualStyleBackColor = true;
            // 
            // Pizza2RadioButton
            // 
            this.Pizza2RadioButton.AutoSize = true;
            this.Pizza2RadioButton.Location = new System.Drawing.Point(13, 151);
            this.Pizza2RadioButton.Name = "Pizza2RadioButton";
            this.Pizza2RadioButton.Size = new System.Drawing.Size(17, 16);
            this.Pizza2RadioButton.TabIndex = 17;
            this.Pizza2RadioButton.Tag = "2";
            this.Pizza2RadioButton.UseVisualStyleBackColor = true;
            // 
            // SizeBox
            // 
            this.SizeBox.FormattingEnabled = true;
            this.SizeBox.Location = new System.Drawing.Point(383, 12);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(121, 24);
            this.SizeBox.TabIndex = 18;
            // 
            // DoughBox
            // 
            this.DoughBox.FormattingEnabled = true;
            this.DoughBox.Location = new System.Drawing.Point(255, 12);
            this.DoughBox.Name = "DoughBox";
            this.DoughBox.Size = new System.Drawing.Size(122, 24);
            this.DoughBox.TabIndex = 19;
            // 
            // PizzaAmount
            // 
            this.PizzaAmount.Location = new System.Drawing.Point(292, 296);
            this.PizzaAmount.Name = "PizzaAmount";
            this.PizzaAmount.Size = new System.Drawing.Size(100, 22);
            this.PizzaAmount.TabIndex = 20;
            this.PizzaAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PizzaAmount.ValueChanged += new System.EventHandler(this.PizzaAmount_ValueChanged);
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Location = new System.Drawing.Point(830, 336);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(75, 23);
            this.CheckoutButton.TabIndex = 21;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // Antal
            // 
            this.Antal.HeaderText = "Antal";
            this.Antal.MinimumWidth = 6;
            this.Antal.Name = "Antal";
            this.Antal.ReadOnly = true;
            this.Antal.Width = 75;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Navn";
            this.nameColumn.MinimumWidth = 6;
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 75;
            // 
            // ingredientsColumn
            // 
            this.ingredientsColumn.HeaderText = "Ingredienser";
            this.ingredientsColumn.MinimumWidth = 6;
            this.ingredientsColumn.Name = "ingredientsColumn";
            this.ingredientsColumn.ReadOnly = true;
            this.ingredientsColumn.Width = 250;
            // 
            // priceColumn
            // 
            this.priceColumn.HeaderText = "Pris";
            this.priceColumn.MinimumWidth = 6;
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.ReadOnly = true;
            this.priceColumn.Width = 75;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 553);
            this.Controls.Add(this.CheckoutButton);
            this.Controls.Add(this.PizzaAmount);
            this.Controls.Add(this.DoughBox);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.Pizza2RadioButton);
            this.Controls.Add(this.Pizza1RadioButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EditorButton);
            this.Controls.Add(this.AddPizzaButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PizzaAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddPizzaButton;
        private System.Windows.Forms.Button EditorButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Ingredients1;
        private System.Windows.Forms.Label price1;
        private System.Windows.Forms.Label name1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Ingredients2;
        private System.Windows.Forms.Label price2;
        private System.Windows.Forms.Label name2;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.RadioButton Pizza1RadioButton;
        public System.Windows.Forms.RadioButton Pizza2RadioButton;
        private System.Windows.Forms.ComboBox SizeBox;
        private System.Windows.Forms.ComboBox DoughBox;
        private System.Windows.Forms.NumericUpDown PizzaAmount;
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Antal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
    }
}

