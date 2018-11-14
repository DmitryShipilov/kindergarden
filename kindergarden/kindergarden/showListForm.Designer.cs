namespace kindergarden
{
    partial class showListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backToForm1 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.paid = new System.Windows.Forms.Button();
            this.showAll = new System.Windows.Forms.Button();
            this.visitCount = new System.Windows.Forms.Button();
            this.deleteRow = new System.Windows.Forms.Button();
            this.comboBoxFilterStreet = new System.Windows.Forms.ComboBox();
            this.Filter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backToForm1
            // 
            this.backToForm1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.backToForm1.Location = new System.Drawing.Point(12, 457);
            this.backToForm1.Name = "backToForm1";
            this.backToForm1.Size = new System.Drawing.Size(150, 84);
            this.backToForm1.TabIndex = 1;
            this.backToForm1.Text = "Назад";
            this.backToForm1.UseVisualStyleBackColor = true;
            this.backToForm1.Click += new System.EventHandler(this.backToForm1_Click);
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-42, 130);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1387, 321);
            this.dataGridView.TabIndex = 2;
            // 
            // paid
            // 
            this.paid.FlatAppearance.BorderSize = 2;
            this.paid.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.paid.Location = new System.Drawing.Point(664, 457);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(150, 84);
            this.paid.TabIndex = 4;
            this.paid.Text = "Оплачено";
            this.paid.UseVisualStyleBackColor = true;
            this.paid.Click += new System.EventHandler(this.paid_Click);
            // 
            // showAll
            // 
            this.showAll.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.showAll.Location = new System.Drawing.Point(987, 457);
            this.showAll.Name = "showAll";
            this.showAll.Size = new System.Drawing.Size(150, 84);
            this.showAll.TabIndex = 5;
            this.showAll.Text = "Показать всех";
            this.showAll.UseVisualStyleBackColor = true;
            this.showAll.Click += new System.EventHandler(this.showAll_Click);
            // 
            // visitCount
            // 
            this.visitCount.FlatAppearance.BorderSize = 2;
            this.visitCount.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.visitCount.Location = new System.Drawing.Point(820, 457);
            this.visitCount.Name = "visitCount";
            this.visitCount.Size = new System.Drawing.Size(161, 84);
            this.visitCount.TabIndex = 6;
            this.visitCount.Text = "Установить число посещений";
            this.visitCount.UseVisualStyleBackColor = true;
            this.visitCount.Click += new System.EventHandler(this.visitCount_Click);
            // 
            // deleteRow
            // 
            this.deleteRow.FlatAppearance.BorderSize = 2;
            this.deleteRow.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.deleteRow.Location = new System.Drawing.Point(1238, 457);
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(161, 84);
            this.deleteRow.TabIndex = 8;
            this.deleteRow.Text = "Удалить строку";
            this.deleteRow.UseVisualStyleBackColor = true;
            this.deleteRow.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // comboBoxFilterStreet
            // 
            this.comboBoxFilterStreet.FormattingEnabled = true;
            this.comboBoxFilterStreet.Location = new System.Drawing.Point(1093, 69);
            this.comboBoxFilterStreet.Name = "comboBoxFilterStreet";
            this.comboBoxFilterStreet.Size = new System.Drawing.Size(150, 24);
            this.comboBoxFilterStreet.TabIndex = 9;
            // 
            // Filter
            // 
            this.Filter.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Filter.Location = new System.Drawing.Point(1249, 69);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(150, 55);
            this.Filter.TabIndex = 10;
            this.Filter.Text = "Фильтр";
            this.Filter.UseVisualStyleBackColor = true;
            this.Filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1090, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Фильтр по улице";
            // 
            // showListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filter);
            this.Controls.Add(this.comboBoxFilterStreet);
            this.Controls.Add(this.deleteRow);
            this.Controls.Add(this.visitCount);
            this.Controls.Add(this.showAll);
            this.Controls.Add(this.paid);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.backToForm1);
            this.Name = "showListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование списка";
            this.Load += new System.EventHandler(this.showListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backToForm1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button paid;
        private System.Windows.Forms.Button showAll;
        private System.Windows.Forms.Button visitCount;
        private System.Windows.Forms.Button deleteRow;
        private System.Windows.Forms.ComboBox comboBoxFilterStreet;
        private System.Windows.Forms.Button Filter;
        private System.Windows.Forms.Label label1;
    }
}