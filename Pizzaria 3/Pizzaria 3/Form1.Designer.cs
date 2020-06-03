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
            this.AddItemButton = new System.Windows.Forms.Button();
            this.EditorButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Antal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.PizzaSizeBox = new System.Windows.Forms.ComboBox();
            this.DoughBox = new System.Windows.Forms.ComboBox();
            this.ItemAmount = new System.Windows.Forms.NumericUpDown();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.GlutenBreadPrice = new System.Windows.Forms.Label();
            this.SizePrice = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Ingredients3 = new System.Windows.Forms.Label();
            this.price3 = new System.Windows.Forms.Label();
            this.name3 = new System.Windows.Forms.Label();
            this.Pizza3RadioButton = new System.Windows.Forms.RadioButton();
            this.Drink1RadioButton = new System.Windows.Forms.RadioButton();
            this.Drink2RadioButton = new System.Windows.Forms.RadioButton();
            this.Drink3RadioButton = new System.Windows.Forms.RadioButton();
            this.DrinkPrice = new System.Windows.Forms.Label();
            this.DrinkSizeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAmount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(767, 190);
            this.AddItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(100, 28);
            this.AddItemButton.TabIndex = 2;
            this.AddItemButton.Text = "Add Item";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // EditorButton
            // 
            this.EditorButton.Location = new System.Drawing.Point(801, 500);
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
            this.dataGridView1.Location = new System.Drawing.Point(682, 246);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(356, 248);
            this.dataGridView1.TabIndex = 13;
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
            this.panel1.Tag = "1";
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
            this.panel2.Tag = "2";
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
            this.price2.Size = new System.Drawing.Size(39, 17);
            this.price2.TabIndex = 1;
            this.price2.Text = "price";
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
            this.PizzaSizeBox.FormattingEnabled = true;
            this.PizzaSizeBox.Location = new System.Drawing.Point(255, 166);
            this.PizzaSizeBox.Name = "SizeBox";
            this.PizzaSizeBox.Size = new System.Drawing.Size(121, 24);
            this.PizzaSizeBox.TabIndex = 18;
            this.PizzaSizeBox.SelectedIndexChanged += new System.EventHandler(this.PizzaPrice_Update);
            // 
            // DoughBox
            // 
            this.DoughBox.FormattingEnabled = true;
            this.DoughBox.Location = new System.Drawing.Point(255, 12);
            this.DoughBox.Name = "DoughBox";
            this.DoughBox.Size = new System.Drawing.Size(122, 24);
            this.DoughBox.TabIndex = 19;
            this.DoughBox.SelectedIndexChanged += new System.EventHandler(this.PizzaPrice_Update);
            // 
            // PizzaAmount
            // 
            this.ItemAmount.Location = new System.Drawing.Point(467, 421);
            this.ItemAmount.Name = "PizzaAmount";
            this.ItemAmount.Size = new System.Drawing.Size(100, 22);
            this.ItemAmount.TabIndex = 20;
            this.ItemAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemAmount.ValueChanged += new System.EventHandler(this.PizzaPrice_Update);
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Location = new System.Drawing.Point(682, 500);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(113, 23);
            this.CheckoutButton.TabIndex = 21;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // GlutenBreadPrice
            // 
            this.GlutenBreadPrice.AutoSize = true;
            this.GlutenBreadPrice.Location = new System.Drawing.Point(46, 393);
            this.GlutenBreadPrice.Name = "GlutenBreadPrice";
            this.GlutenBreadPrice.Size = new System.Drawing.Size(126, 17);
            this.GlutenBreadPrice.TabIndex = 22;
            this.GlutenBreadPrice.Text = "Gluten bread price";
            // 
            // SizePrice
            // 
            this.SizePrice.AutoSize = true;
            this.SizePrice.Location = new System.Drawing.Point(46, 347);
            this.SizePrice.Name = "SizePrice";
            this.SizePrice.Size = new System.Drawing.Size(70, 17);
            this.SizePrice.TabIndex = 23;
            this.SizePrice.Text = "Size price";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Ingredients3);
            this.panel3.Controls.Add(this.price3);
            this.panel3.Controls.Add(this.name3);
            this.panel3.Location = new System.Drawing.Point(49, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 16;
            this.panel3.Tag = "3";
            // 
            // Ingredients3
            // 
            this.Ingredients3.AutoSize = true;
            this.Ingredients3.Location = new System.Drawing.Point(3, 47);
            this.Ingredients3.Name = "Ingredients3";
            this.Ingredients3.Size = new System.Drawing.Size(154, 51);
            this.Ingredients3.TabIndex = 2;
            this.Ingredients3.Text = "Tomatsauce, pizza ost,\r\n ham, peperoni, kebab,\r\n meatballs og oregano\r\n";
            // 
            // price3
            // 
            this.price3.AutoSize = true;
            this.price3.Location = new System.Drawing.Point(119, 4);
            this.price3.Name = "price3";
            this.price3.Size = new System.Drawing.Size(39, 17);
            this.price3.TabIndex = 1;
            this.price3.Text = "price";
            // 
            // name3
            // 
            this.name3.AutoSize = true;
            this.name3.Location = new System.Drawing.Point(13, 4);
            this.name3.Name = "name3";
            this.name3.Size = new System.Drawing.Size(49, 17);
            this.name3.TabIndex = 0;
            this.name3.Text = "pizza3";
            // 
            // Pizza3RadioButton
            // 
            this.Pizza3RadioButton.AutoSize = true;
            this.Pizza3RadioButton.Location = new System.Drawing.Point(13, 259);
            this.Pizza3RadioButton.Name = "Pizza3RadioButton";
            this.Pizza3RadioButton.Size = new System.Drawing.Size(17, 16);
            this.Pizza3RadioButton.TabIndex = 24;
            this.Pizza3RadioButton.Tag = "3";
            this.Pizza3RadioButton.UseVisualStyleBackColor = true;
            // 
            // Drink1RadioButton
            // 
            this.Drink1RadioButton.AutoSize = true;
            this.Drink1RadioButton.Location = new System.Drawing.Point(419, 118);
            this.Drink1RadioButton.Name = "Drink1RadioButton";
            this.Drink1RadioButton.Size = new System.Drawing.Size(148, 21);
            this.Drink1RadioButton.TabIndex = 25;
            this.Drink1RadioButton.TabStop = true;
            this.Drink1RadioButton.Tag = "50";
            this.Drink1RadioButton.Text = "Drink1RadioButton";
            this.Drink1RadioButton.UseVisualStyleBackColor = true;
            // 
            // Drink2RadioButton
            // 
            this.Drink2RadioButton.AutoSize = true;
            this.Drink2RadioButton.Location = new System.Drawing.Point(419, 159);
            this.Drink2RadioButton.Name = "Drink2RadioButton";
            this.Drink2RadioButton.Size = new System.Drawing.Size(17, 16);
            this.Drink2RadioButton.TabIndex = 26;
            this.Drink2RadioButton.TabStop = true;
            this.Drink2RadioButton.Tag = "51";
            this.Drink2RadioButton.UseVisualStyleBackColor = true;
            // 
            // Drink3RadioButton
            // 
            this.Drink3RadioButton.AutoSize = true;
            this.Drink3RadioButton.Location = new System.Drawing.Point(419, 202);
            this.Drink3RadioButton.Name = "Drink3RadioButton";
            this.Drink3RadioButton.Size = new System.Drawing.Size(17, 16);
            this.Drink3RadioButton.TabIndex = 27;
            this.Drink3RadioButton.TabStop = true;
            this.Drink3RadioButton.Tag = "52";
            this.Drink3RadioButton.UseVisualStyleBackColor = true;
            // 
            // DrinkPrice
            // 
            this.DrinkPrice.AutoSize = true;
            this.DrinkPrice.Location = new System.Drawing.Point(419, 12);
            this.DrinkPrice.Name = "DrinkPrice";
            this.DrinkPrice.Size = new System.Drawing.Size(73, 17);
            this.DrinkPrice.TabIndex = 28;
            this.DrinkPrice.Text = "DrinkPrice";
            // 
            // DrinkSizeBox
            // 
            this.DrinkSizeBox.FormattingEnabled = true;
            this.DrinkSizeBox.Location = new System.Drawing.Point(419, 224);
            this.DrinkSizeBox.Name = "DrinkSizeBox";
            this.DrinkSizeBox.Size = new System.Drawing.Size(121, 24);
            this.DrinkSizeBox.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 553);
            this.Controls.Add(this.DrinkSizeBox);
            this.Controls.Add(this.DrinkPrice);
            this.Controls.Add(this.Drink3RadioButton);
            this.Controls.Add(this.Drink2RadioButton);
            this.Controls.Add(this.Drink1RadioButton);
            this.Controls.Add(this.Pizza3RadioButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.SizePrice);
            this.Controls.Add(this.GlutenBreadPrice);
            this.Controls.Add(this.CheckoutButton);
            this.Controls.Add(this.ItemAmount);
            this.Controls.Add(this.DoughBox);
            this.Controls.Add(this.PizzaSizeBox);
            this.Controls.Add(this.Pizza2RadioButton);
            this.Controls.Add(this.Pizza1RadioButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EditorButton);
            this.Controls.Add(this.AddItemButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAmount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddItemButton;
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
        private System.Windows.Forms.ComboBox PizzaSizeBox;
        private System.Windows.Forms.ComboBox DoughBox;
        private System.Windows.Forms.NumericUpDown ItemAmount;
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Antal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.Label GlutenBreadPrice;
        private System.Windows.Forms.Label SizePrice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Ingredients3;
        private System.Windows.Forms.Label price3;
        private System.Windows.Forms.Label name3;
        public System.Windows.Forms.RadioButton Pizza3RadioButton;
        private System.Windows.Forms.RadioButton Drink1RadioButton;
        private System.Windows.Forms.RadioButton Drink2RadioButton;
        private System.Windows.Forms.RadioButton Drink3RadioButton;
        private System.Windows.Forms.Label DrinkPrice;
        private System.Windows.Forms.ComboBox DrinkSizeBox;
    }
}

