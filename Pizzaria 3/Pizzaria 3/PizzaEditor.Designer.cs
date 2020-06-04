namespace Pizzaria_3
{
    partial class PizzaEditor
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
            this.DoughBox = new System.Windows.Forms.ComboBox();
            this.SizeBox = new System.Windows.Forms.ComboBox();
            this.CheeseBox = new System.Windows.Forms.ComboBox();
            this.SauceBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ToppingPanel = new System.Windows.Forms.Panel();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.AddPizzaButton = new System.Windows.Forms.Button();
            this.PizzaAmount = new System.Windows.Forms.NumericUpDown();
            this.SpicePanel = new System.Windows.Forms.Panel();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.ToppingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PizzaAmount)).BeginInit();
            this.SpicePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoughBox
            // 
            this.DoughBox.FormattingEnabled = true;
            this.DoughBox.Location = new System.Drawing.Point(12, 12);
            this.DoughBox.Name = "DoughBox";
            this.DoughBox.Size = new System.Drawing.Size(122, 24);
            this.DoughBox.TabIndex = 0;
            this.DoughBox.SelectedIndexChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // SizeBox
            // 
            this.SizeBox.FormattingEnabled = true;
            this.SizeBox.Location = new System.Drawing.Point(140, 12);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(121, 24);
            this.SizeBox.TabIndex = 1;
            this.SizeBox.SelectedIndexChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // CheeseBox
            // 
            this.CheeseBox.FormattingEnabled = true;
            this.CheeseBox.Location = new System.Drawing.Point(267, 12);
            this.CheeseBox.Name = "CheeseBox";
            this.CheeseBox.Size = new System.Drawing.Size(121, 24);
            this.CheeseBox.TabIndex = 2;
            this.CheeseBox.SelectedIndexChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // SauceBox
            // 
            this.SauceBox.FormattingEnabled = true;
            this.SauceBox.Location = new System.Drawing.Point(394, 12);
            this.SauceBox.Name = "SauceBox";
            this.SauceBox.Size = new System.Drawing.Size(121, 24);
            this.SauceBox.TabIndex = 3;
            this.SauceBox.SelectedIndexChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(570, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // ToppingPanel
            // 
            this.ToppingPanel.Controls.Add(this.checkBox9);
            this.ToppingPanel.Controls.Add(this.checkBox10);
            this.ToppingPanel.Controls.Add(this.checkBox7);
            this.ToppingPanel.Controls.Add(this.checkBox8);
            this.ToppingPanel.Controls.Add(this.checkBox5);
            this.ToppingPanel.Controls.Add(this.checkBox6);
            this.ToppingPanel.Controls.Add(this.checkBox3);
            this.ToppingPanel.Controls.Add(this.checkBox4);
            this.ToppingPanel.Controls.Add(this.checkBox2);
            this.ToppingPanel.Controls.Add(this.checkBox1);
            this.ToppingPanel.Location = new System.Drawing.Point(12, 96);
            this.ToppingPanel.Name = "ToppingPanel";
            this.ToppingPanel.Size = new System.Drawing.Size(249, 121);
            this.ToppingPanel.TabIndex = 6;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(128, 95);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(18, 17);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.Visible = false;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(3, 95);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(18, 17);
            this.checkBox10.TabIndex = 8;
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.Visible = false;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(128, 72);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(18, 17);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.Visible = false;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(3, 72);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(18, 17);
            this.checkBox8.TabIndex = 6;
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.Visible = false;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(128, 49);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(3, 49);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(18, 17);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.Visible = false;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(128, 26);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(3, 26);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(128, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // AddPizzaButton
            // 
            this.AddPizzaButton.Location = new System.Drawing.Point(394, 246);
            this.AddPizzaButton.Name = "AddPizzaButton";
            this.AddPizzaButton.Size = new System.Drawing.Size(93, 23);
            this.AddPizzaButton.TabIndex = 5;
            this.AddPizzaButton.Text = "Add pizza";
            this.AddPizzaButton.UseVisualStyleBackColor = true;
            this.AddPizzaButton.Click += new System.EventHandler(this.AddPizzaButton_Click);
            // 
            // PizzaAmount
            // 
            this.PizzaAmount.Location = new System.Drawing.Point(521, 14);
            this.PizzaAmount.Name = "PizzaAmount";
            this.PizzaAmount.Size = new System.Drawing.Size(100, 22);
            this.PizzaAmount.TabIndex = 21;
            this.PizzaAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PizzaAmount.ValueChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // SpicePanel
            // 
            this.SpicePanel.Controls.Add(this.checkBox11);
            this.SpicePanel.Controls.Add(this.checkBox12);
            this.SpicePanel.Controls.Add(this.checkBox13);
            this.SpicePanel.Controls.Add(this.checkBox14);
            this.SpicePanel.Controls.Add(this.checkBox15);
            this.SpicePanel.Controls.Add(this.checkBox16);
            this.SpicePanel.Controls.Add(this.checkBox17);
            this.SpicePanel.Controls.Add(this.checkBox18);
            this.SpicePanel.Controls.Add(this.checkBox19);
            this.SpicePanel.Controls.Add(this.checkBox20);
            this.SpicePanel.Location = new System.Drawing.Point(12, 246);
            this.SpicePanel.Name = "SpicePanel";
            this.SpicePanel.Size = new System.Drawing.Size(249, 121);
            this.SpicePanel.TabIndex = 10;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(128, 95);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(18, 17);
            this.checkBox11.TabIndex = 9;
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.Visible = false;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(3, 95);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(18, 17);
            this.checkBox12.TabIndex = 8;
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.Visible = false;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(128, 72);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(18, 17);
            this.checkBox13.TabIndex = 7;
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.Visible = false;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(3, 72);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(18, 17);
            this.checkBox14.TabIndex = 6;
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.Visible = false;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(128, 49);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(18, 17);
            this.checkBox15.TabIndex = 5;
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.Visible = false;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(3, 49);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(18, 17);
            this.checkBox16.TabIndex = 4;
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.Visible = false;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(128, 26);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(18, 17);
            this.checkBox17.TabIndex = 3;
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.Visible = false;
            this.checkBox17.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(3, 26);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(18, 17);
            this.checkBox18.TabIndex = 2;
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.Visible = false;
            this.checkBox18.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(128, 3);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(18, 17);
            this.checkBox19.TabIndex = 1;
            this.checkBox19.UseVisualStyleBackColor = true;
            this.checkBox19.Visible = false;
            this.checkBox19.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(3, 3);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(18, 17);
            this.checkBox20.TabIndex = 0;
            this.checkBox20.UseVisualStyleBackColor = true;
            this.checkBox20.Visible = false;
            this.checkBox20.CheckedChanged += new System.EventHandler(this.PizzaProperty_Changed);
            // 
            // PizzaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SpicePanel);
            this.Controls.Add(this.PizzaAmount);
            this.Controls.Add(this.ToppingPanel);
            this.Controls.Add(this.AddPizzaButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SauceBox);
            this.Controls.Add(this.CheeseBox);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.DoughBox);
            this.Name = "PizzaEditor";
            this.Text = "PizzaEditor";
            this.Load += new System.EventHandler(this.PizzaEditor_Load);
            this.ToppingPanel.ResumeLayout(false);
            this.ToppingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PizzaAmount)).EndInit();
            this.SpicePanel.ResumeLayout(false);
            this.SpicePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DoughBox;
        private System.Windows.Forms.ComboBox SizeBox;
        private System.Windows.Forms.ComboBox CheeseBox;
        private System.Windows.Forms.ComboBox SauceBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel ToppingPanel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button AddPizzaButton;
        private System.Windows.Forms.NumericUpDown PizzaAmount;
        private System.Windows.Forms.Panel SpicePanel;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
    }
}