
namespace moduls.pages
{
    partial class Ocenka2
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
            this.ocenkaBox = new System.Windows.Forms.TextBox();
            this.Deskription = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Estimate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.Button();
            this.commentBox = new System.Windows.Forms.RichTextBox();
            this.Comment = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Block = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Archetype = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ocenkaBox
            // 
            this.ocenkaBox.Location = new System.Drawing.Point(523, 44);
            this.ocenkaBox.Name = "ocenkaBox";
            this.ocenkaBox.Size = new System.Drawing.Size(100, 20);
            this.ocenkaBox.TabIndex = 66;
            this.ocenkaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Deskription
            // 
            this.Deskription.BackColor = System.Drawing.Color.Red;
            this.Deskription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Deskription.ForeColor = System.Drawing.Color.White;
            this.Deskription.Location = new System.Drawing.Point(225, 44);
            this.Deskription.Multiline = true;
            this.Deskription.Name = "Deskription";
            this.Deskription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Deskription.Size = new System.Drawing.Size(213, 259);
            this.Deskription.TabIndex = 65;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(106, 91);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(110, 17);
            this.radioButton3.TabIndex = 64;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "От 3 до 5 баллов";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(106, 68);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 63;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "От 1 до 3 баллов";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(106, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(110, 17);
            this.radioButton1.TabIndex = 62;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "От 0 до 1 баллов";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Estimate
            // 
            this.Estimate.BackColor = System.Drawing.Color.White;
            this.Estimate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Estimate.Location = new System.Drawing.Point(523, 67);
            this.Estimate.Name = "Estimate";
            this.Estimate.Size = new System.Drawing.Size(100, 23);
            this.Estimate.TabIndex = 61;
            this.Estimate.Text = "Оценить";
            this.Estimate.UseVisualStyleBackColor = false;
            this.Estimate.Click += new System.EventHandler(this.Estimate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(472, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Оценка";
            // 
            // Link
            // 
            this.Link.BackColor = System.Drawing.Color.White;
            this.Link.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Link.Location = new System.Drawing.Point(523, 9);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(100, 21);
            this.Link.TabIndex = 58;
            this.Link.Text = "Скопировать git";
            this.Link.UseVisualStyleBackColor = false;
            this.Link.Click += new System.EventHandler(this.Link_Click);
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(457, 96);
            this.commentBox.Name = "commentBox";
            this.commentBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.commentBox.Size = new System.Drawing.Size(166, 87);
            this.commentBox.TabIndex = 57;
            this.commentBox.Text = "";
            // 
            // Comment
            // 
            this.Comment.BackColor = System.Drawing.Color.White;
            this.Comment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Comment.Location = new System.Drawing.Point(457, 189);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(166, 23);
            this.Comment.TabIndex = 56;
            this.Comment.Text = "Комментировать";
            this.Comment.UseVisualStyleBackColor = false;
            this.Comment.Click += new System.EventHandler(this.Comment_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Back.Location = new System.Drawing.Point(4, 45);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(95, 23);
            this.Back.TabIndex = 55;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit.Location = new System.Drawing.Point(4, 74);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(95, 23);
            this.Exit.TabIndex = 54;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Block
            // 
            this.Block.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Block.FormattingEnabled = true;
            this.Block.Location = new System.Drawing.Point(220, 9);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(152, 21);
            this.Block.TabIndex = 53;
            this.Block.SelectedIndexChanged += new System.EventHandler(this.Block_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(187, 9);
            this.label2.MinimumSize = new System.Drawing.Size(0, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 52;
            this.label2.Text = "Блок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MinimumSize = new System.Drawing.Size(0, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 51;
            this.label1.Text = "Архетип";
            // 
            // Archetype
            // 
            this.Archetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Archetype.FormattingEnabled = true;
            this.Archetype.Location = new System.Drawing.Point(66, 9);
            this.Archetype.Name = "Archetype";
            this.Archetype.Size = new System.Drawing.Size(115, 21);
            this.Archetype.TabIndex = 50;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 116);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(215, 187);
            this.listView1.TabIndex = 67;
            this.listView1.TileSize = new System.Drawing.Size(170, 30);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(379, 9);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(138, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 21);
            this.dateTimePicker1.TabIndex = 69;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // Ocenka2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(633, 314);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ocenkaBox);
            this.Controls.Add(this.Deskription);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Estimate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Block);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Archetype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(660, 360);
            this.MinimumSize = new System.Drawing.Size(649, 353);
            this.Name = "Ocenka2";
            this.Text = "Оценивание членом комиссии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ocenkaBox;
        private System.Windows.Forms.TextBox Deskription;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button Estimate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Link;
        private System.Windows.Forms.RichTextBox commentBox;
        private System.Windows.Forms.Button Comment;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox Block;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Archetype;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}