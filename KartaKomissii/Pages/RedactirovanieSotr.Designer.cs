
namespace Commission_map.Pages
{
    partial class RedactirovanieSotr
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
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.otchestvo = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.familia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Sotrud = new System.Windows.Forms.ComboBox();
            this.Redact = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(78, 171);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(125, 20);
            this.password.TabIndex = 27;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(78, 145);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(125, 20);
            this.login.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Пароль";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Логин";
            // 
            // otchestvo
            // 
            this.otchestvo.Location = new System.Drawing.Point(78, 119);
            this.otchestvo.Name = "otchestvo";
            this.otchestvo.Size = new System.Drawing.Size(125, 20);
            this.otchestvo.TabIndex = 22;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(78, 91);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(125, 20);
            this.name.TabIndex = 21;
            // 
            // familia
            // 
            this.familia.Location = new System.Drawing.Point(78, 65);
            this.familia.Name = "familia";
            this.familia.Size = new System.Drawing.Size(125, 20);
            this.familia.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Фамилия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Сотрудник";
            // 
            // Sotrud
            // 
            this.Sotrud.FormattingEnabled = true;
            this.Sotrud.Location = new System.Drawing.Point(78, 38);
            this.Sotrud.Name = "Sotrud";
            this.Sotrud.Size = new System.Drawing.Size(212, 21);
            this.Sotrud.TabIndex = 31;
            this.Sotrud.SelectedIndexChanged += new System.EventHandler(this.Sotrud_SelectedIndexChanged);
            // 
            // Redact
            // 
            this.Redact.BackColor = System.Drawing.Color.White;
            this.Redact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Redact.Location = new System.Drawing.Point(47, 209);
            this.Redact.Name = "Redact";
            this.Redact.Size = new System.Drawing.Size(100, 23);
            this.Redact.TabIndex = 32;
            this.Redact.Text = "Редактировать";
            this.Redact.UseVisualStyleBackColor = false;
            this.Redact.Click += new System.EventHandler(this.Redact_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back.Location = new System.Drawing.Point(12, 238);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(103, 21);
            this.Back.TabIndex = 33;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(105, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 55;
            this.radioButton2.Text = "Карта комиссии";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 54;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Сотрудник";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // RedactirovanieSotr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(297, 269);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Redact);
            this.Controls.Add(this.Sotrud);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.otchestvo);
            this.Controls.Add(this.name);
            this.Controls.Add(this.familia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "RedactirovanieSotr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование Сотрудника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox otchestvo;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox familia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Sotrud;
        private System.Windows.Forms.Button Redact;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}