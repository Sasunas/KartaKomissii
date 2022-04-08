
namespace Commission_map.Pages
{
    partial class Admin
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
            this.Exit = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Regist = new System.Windows.Forms.Button();
            this.Redact = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.sotr = new System.Windows.Forms.RadioButton();
            this.karty = new System.Windows.Forms.RadioButton();
            this.roli = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.Location = new System.Drawing.Point(12, 126);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(103, 21);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back.Location = new System.Drawing.Point(12, 99);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(103, 21);
            this.Back.TabIndex = 2;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Regist
            // 
            this.Regist.BackColor = System.Drawing.Color.White;
            this.Regist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Regist.Location = new System.Drawing.Point(12, 12);
            this.Regist.Name = "Regist";
            this.Regist.Size = new System.Drawing.Size(103, 23);
            this.Regist.TabIndex = 3;
            this.Regist.Text = " Регистрация";
            this.Regist.UseVisualStyleBackColor = false;
            this.Regist.Click += new System.EventHandler(this.Regist_Click);
            // 
            // Redact
            // 
            this.Redact.BackColor = System.Drawing.Color.White;
            this.Redact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Redact.Location = new System.Drawing.Point(12, 41);
            this.Redact.Name = "Redact";
            this.Redact.Size = new System.Drawing.Size(103, 23);
            this.Redact.TabIndex = 4;
            this.Redact.Text = "Редактирование";
            this.Redact.UseVisualStyleBackColor = false;
            this.Redact.Click += new System.EventHandler(this.Redact_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete.Location = new System.Drawing.Point(12, 70);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(103, 23);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Удаление";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // sotr
            // 
            this.sotr.AutoSize = true;
            this.sotr.Location = new System.Drawing.Point(121, 15);
            this.sotr.MaximumSize = new System.Drawing.Size(0, 23);
            this.sotr.Name = "sotr";
            this.sotr.Size = new System.Drawing.Size(84, 17);
            this.sotr.TabIndex = 6;
            this.sotr.TabStop = true;
            this.sotr.Text = "Сотрудники";
            this.sotr.UseVisualStyleBackColor = true;
            this.sotr.CheckedChanged += new System.EventHandler(this.Sotr_CheckedChanged);
            // 
            // karty
            // 
            this.karty.AutoSize = true;
            this.karty.Location = new System.Drawing.Point(308, 15);
            this.karty.MaximumSize = new System.Drawing.Size(0, 23);
            this.karty.Name = "karty";
            this.karty.Size = new System.Drawing.Size(108, 17);
            this.karty.TabIndex = 7;
            this.karty.TabStop = true;
            this.karty.Text = "Карта комиссии";
            this.karty.UseVisualStyleBackColor = true;
            this.karty.CheckedChanged += new System.EventHandler(this.Karty_CheckedChanged);
            // 
            // roli
            // 
            this.roli.AutoSize = true;
            this.roli.Location = new System.Drawing.Point(211, 15);
            this.roli.MaximumSize = new System.Drawing.Size(0, 23);
            this.roli.Name = "roli";
            this.roli.Size = new System.Drawing.Size(91, 17);
            this.roli.TabIndex = 8;
            this.roli.TabStop = true;
            this.roli.Text = "Роли в карте";
            this.roli.UseVisualStyleBackColor = true;
            this.roli.CheckedChanged += new System.EventHandler(this.Roli_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(133, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(495, 135);
            this.dataGridView1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(728, 227);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.roli);
            this.Controls.Add(this.karty);
            this.Controls.Add(this.sotr);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Redact);
            this.Controls.Add(this.Regist);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(805, 370);
            this.MinimumSize = new System.Drawing.Size(300, 240);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Regist;
        private System.Windows.Forms.Button Redact;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.RadioButton sotr;
        private System.Windows.Forms.RadioButton karty;
        private System.Windows.Forms.RadioButton roli;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}