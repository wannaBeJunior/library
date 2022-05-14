
namespace library
{
    partial class statisticForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(statisticForm));
            this.Label1 = new System.Windows.Forms.Label();
            this.Print = new System.Windows.Forms.Button();
            this.totalBooksLabel = new System.Windows.Forms.Label();
            this.unavailableBooksCountLabel = new System.Windows.Forms.Label();
            this.availableBooksCountLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalUsersCountLabel = new System.Windows.Forms.Label();
            this.readersCountLabel = new System.Windows.Forms.Label();
            this.employeesCountLabel = new System.Windows.Forms.Label();
            this.mostActiveReaderLabel = new System.Windows.Forms.Label();
            this.mostPopularBookLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(232, 23);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Статистика по книгам:";
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(16, 253);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(123, 31);
            this.Print.TabIndex = 8;
            this.Print.Text = "Печать";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // totalBooksLabel
            // 
            this.totalBooksLabel.AutoSize = true;
            this.totalBooksLabel.Font = new System.Drawing.Font("Century", 10F);
            this.totalBooksLabel.Location = new System.Drawing.Point(12, 32);
            this.totalBooksLabel.Name = "totalBooksLabel";
            this.totalBooksLabel.Size = new System.Drawing.Size(231, 21);
            this.totalBooksLabel.TabIndex = 9;
            this.totalBooksLabel.Text = "Всего книг в библиотеке - ";
            // 
            // unavailableBooksCountLabel
            // 
            this.unavailableBooksCountLabel.AutoSize = true;
            this.unavailableBooksCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.unavailableBooksCountLabel.Location = new System.Drawing.Point(13, 53);
            this.unavailableBooksCountLabel.Name = "unavailableBooksCountLabel";
            this.unavailableBooksCountLabel.Size = new System.Drawing.Size(204, 21);
            this.unavailableBooksCountLabel.TabIndex = 10;
            this.unavailableBooksCountLabel.Text = "Кол-во книг на руках - ";
            // 
            // availableBooksCountLabel
            // 
            this.availableBooksCountLabel.AutoSize = true;
            this.availableBooksCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.availableBooksCountLabel.Location = new System.Drawing.Point(12, 74);
            this.availableBooksCountLabel.Name = "availableBooksCountLabel";
            this.availableBooksCountLabel.Size = new System.Drawing.Size(229, 21);
            this.availableBooksCountLabel.TabIndex = 11;
            this.availableBooksCountLabel.Text = "Кол-во книг не на руках - ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Статистика по пользователям:";
            // 
            // totalUsersCountLabel
            // 
            this.totalUsersCountLabel.AutoSize = true;
            this.totalUsersCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.totalUsersCountLabel.Location = new System.Drawing.Point(11, 149);
            this.totalUsersCountLabel.Name = "totalUsersCountLabel";
            this.totalUsersCountLabel.Size = new System.Drawing.Size(197, 21);
            this.totalUsersCountLabel.TabIndex = 13;
            this.totalUsersCountLabel.Text = "Всего пользователей - ";
            // 
            // readersCountLabel
            // 
            this.readersCountLabel.AutoSize = true;
            this.readersCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.readersCountLabel.Location = new System.Drawing.Point(11, 170);
            this.readersCountLabel.Name = "readersCountLabel";
            this.readersCountLabel.Size = new System.Drawing.Size(114, 21);
            this.readersCountLabel.TabIndex = 14;
            this.readersCountLabel.Text = "Читателей - ";
            // 
            // employeesCountLabel
            // 
            this.employeesCountLabel.AutoSize = true;
            this.employeesCountLabel.Font = new System.Drawing.Font("Century", 10F);
            this.employeesCountLabel.Location = new System.Drawing.Point(11, 191);
            this.employeesCountLabel.Name = "employeesCountLabel";
            this.employeesCountLabel.Size = new System.Drawing.Size(134, 21);
            this.employeesCountLabel.TabIndex = 15;
            this.employeesCountLabel.Text = "Сотрудников - ";
            // 
            // mostActiveReaderLabel
            // 
            this.mostActiveReaderLabel.AutoSize = true;
            this.mostActiveReaderLabel.Font = new System.Drawing.Font("Century", 10F);
            this.mostActiveReaderLabel.Location = new System.Drawing.Point(11, 212);
            this.mostActiveReaderLabel.Name = "mostActiveReaderLabel";
            this.mostActiveReaderLabel.Size = new System.Drawing.Size(249, 21);
            this.mostActiveReaderLabel.TabIndex = 16;
            this.mostActiveReaderLabel.Text = "Самый активный читатель - ";
            // 
            // mostPopularBookLabel
            // 
            this.mostPopularBookLabel.AutoSize = true;
            this.mostPopularBookLabel.Font = new System.Drawing.Font("Century", 10F);
            this.mostPopularBookLabel.Location = new System.Drawing.Point(13, 95);
            this.mostPopularBookLabel.Name = "mostPopularBookLabel";
            this.mostPopularBookLabel.Size = new System.Drawing.Size(235, 21);
            this.mostPopularBookLabel.TabIndex = 17;
            this.mostPopularBookLabel.Text = "Самая популярная книга - ";
            // 
            // statisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 296);
            this.Controls.Add(this.mostPopularBookLabel);
            this.Controls.Add(this.mostActiveReaderLabel);
            this.Controls.Add(this.employeesCountLabel);
            this.Controls.Add(this.readersCountLabel);
            this.Controls.Add(this.totalUsersCountLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.availableBooksCountLabel);
            this.Controls.Add(this.unavailableBooksCountLabel);
            this.Controls.Add(this.totalBooksLabel);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "statisticForm";
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.statisticForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Label totalBooksLabel;
        private System.Windows.Forms.Label unavailableBooksCountLabel;
        private System.Windows.Forms.Label availableBooksCountLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalUsersCountLabel;
        private System.Windows.Forms.Label readersCountLabel;
        private System.Windows.Forms.Label employeesCountLabel;
        private System.Windows.Forms.Label mostActiveReaderLabel;
        private System.Windows.Forms.Label mostPopularBookLabel;
    }
}