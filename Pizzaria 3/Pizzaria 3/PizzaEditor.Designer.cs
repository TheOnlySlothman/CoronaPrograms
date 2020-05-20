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
            this.SuspendLayout();
            // 
            // DoughBox
            // 
            this.DoughBox.FormattingEnabled = true;
            this.DoughBox.Location = new System.Drawing.Point(12, 12);
            this.DoughBox.Name = "DoughBox";
            this.DoughBox.Size = new System.Drawing.Size(450, 24);
            this.DoughBox.TabIndex = 0;
            // 
            // PizzaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DoughBox);
            this.Name = "PizzaEditor";
            this.Text = "PizzaEditor";
            this.Load += new System.EventHandler(this.PizzaEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DoughBox;
    }
}