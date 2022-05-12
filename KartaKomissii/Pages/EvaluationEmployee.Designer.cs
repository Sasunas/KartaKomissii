
namespace Commission_map.Pages
{
    partial class EvaluationEmployee
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
            this.components = new System.ComponentModel.Container();
            this.Block = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Archetype = new System.Windows.Forms.ComboBox();
            this.Back = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.commentBox = new System.Windows.Forms.RichTextBox();
            this.linkBox = new System.Windows.Forms.RichTextBox();
            this.Link = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Estimate = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.Deskription = new System.Windows.Forms.TextBox();
            this.ocenkaBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Block
            // 
            this.Block.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Block.FormattingEnabled = true;
            this.Block.Location = new System.Drawing.Point(285, 12);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(152, 21);
            this.Block.TabIndex = 27;
            this.Block.SelectedIndexChanged += new System.EventHandler(this.Block_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(247, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Блок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Архетип";
            // 
            // Archetype
            // 
            this.Archetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Archetype.FormattingEnabled = true;
            this.Archetype.Location = new System.Drawing.Point(126, 12);
            this.Archetype.Name = "Archetype";
            this.Archetype.Size = new System.Drawing.Size(115, 21);
            this.Archetype.TabIndex = 24;
            this.Archetype.SelectedIndexChanged += new System.EventHandler(this.Archetype_SelectedIndexChanged);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back.Location = new System.Drawing.Point(10, 266);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 32;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.Location = new System.Drawing.Point(10, 295);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 31;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(358, 128);
            this.commentBox.Name = "commentBox";
            this.commentBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.commentBox.Size = new System.Drawing.Size(166, 87);
            this.commentBox.TabIndex = 40;
            this.commentBox.Text = "";
            // 
            // linkBox
            // 
            this.linkBox.Location = new System.Drawing.Point(358, 230);
            this.linkBox.Name = "linkBox";
            this.linkBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.linkBox.Size = new System.Drawing.Size(166, 59);
            this.linkBox.TabIndex = 42;
            this.linkBox.Text = "";
            // 
            // Link
            // 
            this.Link.BackColor = System.Drawing.Color.White;
            this.Link.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Link.Location = new System.Drawing.Point(358, 292);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(166, 23);
            this.Link.TabIndex = 41;
            this.Link.Text = "Сохранить ссылку на git";
            this.Link.UseVisualStyleBackColor = false;
            this.Link.Click += new System.EventHandler(this.Link_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(355, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Оценка";
            // 
            // Estimate
            // 
            this.Estimate.BackColor = System.Drawing.Color.White;
            this.Estimate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Estimate.Location = new System.Drawing.Point(424, 79);
            this.Estimate.Name = "Estimate";
            this.Estimate.Size = new System.Drawing.Size(100, 23);
            this.Estimate.TabIndex = 44;
            this.Estimate.Text = "Оценить";
            this.Estimate.UseVisualStyleBackColor = false;
            this.Estimate.Click += new System.EventHandler(this.Estimate_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(10, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(110, 17);
            this.radioButton1.TabIndex = 45;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "От 0 до 1 баллов";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(10, 85);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 46;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "От 1 до 3 баллов";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(10, 108);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(110, 17);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "От 3 до 5 баллов";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // Deskription
            // 
            this.Deskription.BackColor = System.Drawing.Color.Red;
            this.Deskription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Deskription.ForeColor = System.Drawing.Color.White;
            this.Deskription.Location = new System.Drawing.Point(126, 56);
            this.Deskription.Multiline = true;
            this.Deskription.Name = "Deskription";
            this.Deskription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Deskription.Size = new System.Drawing.Size(213, 259);
            this.Deskription.TabIndex = 48;
            // 
            // ocenkaBox
            // 
            this.ocenkaBox.Location = new System.Drawing.Point(424, 56);
            this.ocenkaBox.Name = "ocenkaBox";
            this.ocenkaBox.Size = new System.Drawing.Size(100, 20);
            this.ocenkaBox.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(355, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Комментарий";
            // 
            // EvaluationEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(538, 327);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ocenkaBox);
            this.Controls.Add(this.Deskription);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Estimate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Block);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Archetype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(570, 370);
            this.MinimumSize = new System.Drawing.Size(554, 366);
            this.Name = "EvaluationEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оценивание сотрудником";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Block;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Archetype;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.RichTextBox commentBox;
        private System.Windows.Forms.RichTextBox linkBox;
        private System.Windows.Forms.Button Link;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Estimate;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox Deskription;
        private System.Windows.Forms.TextBox ocenkaBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
    }
}