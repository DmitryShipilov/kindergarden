namespace kindergarden
{
    partial class inForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.newChildButton = new System.Windows.Forms.Button();
            this.showListButton = new System.Windows.Forms.Button();
            this.CloseApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newChildButton
            // 
            this.newChildButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.newChildButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newChildButton.Location = new System.Drawing.Point(135, 201);
            this.newChildButton.Name = "newChildButton";
            this.newChildButton.Size = new System.Drawing.Size(193, 133);
            this.newChildButton.TabIndex = 0;
            this.newChildButton.Text = "Записать ребенка ";
            this.newChildButton.UseVisualStyleBackColor = false;
            this.newChildButton.Click += new System.EventHandler(this.newChildButton_Click);
            // 
            // showListButton
            // 
            this.showListButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.showListButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showListButton.Location = new System.Drawing.Point(135, 354);
            this.showListButton.Name = "showListButton";
            this.showListButton.Size = new System.Drawing.Size(193, 133);
            this.showListButton.TabIndex = 1;
            this.showListButton.Text = "Сформировать список";
            this.showListButton.UseVisualStyleBackColor = false;
            this.showListButton.Click += new System.EventHandler(this.showListButton_Click);
            // 
            // CloseApp
            // 
            this.CloseApp.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.CloseApp.Location = new System.Drawing.Point(303, 644);
            this.CloseApp.Name = "CloseApp";
            this.CloseApp.Size = new System.Drawing.Size(150, 50);
            this.CloseApp.TabIndex = 2;
            this.CloseApp.Text = "Выход";
            this.CloseApp.UseVisualStyleBackColor = true;
            this.CloseApp.Click += new System.EventHandler(this.CloseApp_Click);
            // 
            // inForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(465, 706);
            this.Controls.Add(this.CloseApp);
            this.Controls.Add(this.showListButton);
            this.Controls.Add(this.newChildButton);
            this.Name = "inForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детский сад";
            this.Load += new System.EventHandler(this.inForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newChildButton;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.Button CloseApp;
    }
}

