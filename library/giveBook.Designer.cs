
namespace library
{
    partial class giveBook
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.readersComboBox = new System.Windows.Forms.ComboBox();
            this.booksComboBox = new System.Windows.Forms.ComboBox();
            this.daysTextBox = new System.Windows.Forms.TextBox();
            this.giveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выдача книг сотрудником";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 10F);
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите читателя из списка:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 10F);
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите книгу из списка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 10F);
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(512, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество дней до возврата книги(по умолчанию 14 дней):";
            // 
            // readersComboBox
            // 
            this.readersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readersComboBox.FormattingEnabled = true;
            this.readersComboBox.Items.AddRange(new object[] {
            "Выберите читателя"});
            this.readersComboBox.Location = new System.Drawing.Point(279, 50);
            this.readersComboBox.Name = "readersComboBox";
            this.readersComboBox.Size = new System.Drawing.Size(121, 24);
            this.readersComboBox.TabIndex = 8;
            // 
            // booksComboBox
            // 
            this.booksComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.booksComboBox.FormattingEnabled = true;
            this.booksComboBox.Items.AddRange(new object[] {
            "Выберите книгу"});
            this.booksComboBox.Location = new System.Drawing.Point(252, 84);
            this.booksComboBox.Name = "booksComboBox";
            this.booksComboBox.Size = new System.Drawing.Size(121, 24);
            this.booksComboBox.TabIndex = 9;
            // 
            // daysTextBox
            // 
            this.daysTextBox.Location = new System.Drawing.Point(589, 122);
            this.daysTextBox.Name = "daysTextBox";
            this.daysTextBox.Size = new System.Drawing.Size(100, 22);
            this.daysTextBox.TabIndex = 10;
            // 
            // giveButton
            // 
            this.giveButton.Location = new System.Drawing.Point(16, 155);
            this.giveButton.Name = "giveButton";
            this.giveButton.Size = new System.Drawing.Size(95, 41);
            this.giveButton.TabIndex = 11;
            this.giveButton.Text = "Выдать";
            this.giveButton.UseVisualStyleBackColor = true;
            this.giveButton.Click += new System.EventHandler(this.giveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 10F);
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(12, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 10F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 13;
            // 
            // giveBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 274);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.giveButton);
            this.Controls.Add(this.daysTextBox);
            this.Controls.Add(this.booksComboBox);
            this.Controls.Add(this.readersComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "giveBook";
            this.Text = "Выдача книг";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox readersComboBox;
        private System.Windows.Forms.ComboBox booksComboBox;
        private System.Windows.Forms.TextBox daysTextBox;
        private System.Windows.Forms.Button giveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}