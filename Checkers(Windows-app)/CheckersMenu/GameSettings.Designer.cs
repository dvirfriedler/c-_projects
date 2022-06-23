namespace CheckersMenu
{
    partial class GameSettings
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
            this.six_lbl = new System.Windows.Forms.RadioButton();
            this.eight_lbl = new System.Windows.Forms.RadioButton();
            this.ten_lbl = new System.Windows.Forms.RadioButton();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.PlayerTwoCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Players:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 254);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Player1:";
            // 
            // six_lbl
            // 
            this.six_lbl.AutoSize = true;
            this.six_lbl.Location = new System.Drawing.Point(68, 102);
            this.six_lbl.Margin = new System.Windows.Forms.Padding(4);
            this.six_lbl.Name = "six_lbl";
            this.six_lbl.Size = new System.Drawing.Size(81, 29);
            this.six_lbl.TabIndex = 5;
            this.six_lbl.TabStop = true;
            this.six_lbl.Text = "6X6";
            this.six_lbl.UseVisualStyleBackColor = true;
            // 
            // eight_lbl
            // 
            this.eight_lbl.AutoSize = true;
            this.eight_lbl.Location = new System.Drawing.Point(205, 102);
            this.eight_lbl.Margin = new System.Windows.Forms.Padding(4);
            this.eight_lbl.Name = "eight_lbl";
            this.eight_lbl.Size = new System.Drawing.Size(81, 29);
            this.eight_lbl.TabIndex = 6;
            this.eight_lbl.TabStop = true;
            this.eight_lbl.Text = "8X8";
            this.eight_lbl.UseVisualStyleBackColor = true;
            // 
            // ten_lbl
            // 
            this.ten_lbl.AutoSize = true;
            this.ten_lbl.Location = new System.Drawing.Point(332, 102);
            this.ten_lbl.Margin = new System.Windows.Forms.Padding(4);
            this.ten_lbl.Name = "ten_lbl";
            this.ten_lbl.Size = new System.Drawing.Size(105, 29);
            this.ten_lbl.TabIndex = 7;
            this.ten_lbl.TabStop = true;
            this.ten_lbl.Text = "10X10";
            this.ten_lbl.UseVisualStyleBackColor = true;
            // 
            // DoneBtn
            // 
            this.DoneBtn.Location = new System.Drawing.Point(312, 384);
            this.DoneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(128, 58);
            this.DoneBtn.TabIndex = 8;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // player1TextBox
            // 
            this.player1TextBox.Location = new System.Drawing.Point(248, 246);
            this.player1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(169, 31);
            this.player1TextBox.TabIndex = 9;
            // 
            // player2TextBox
            // 
            this.player2TextBox.Enabled = false;
            this.player2TextBox.Location = new System.Drawing.Point(248, 308);
            this.player2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(169, 31);
            this.player2TextBox.TabIndex = 10;
            this.player2TextBox.Text = "Computer";
            // 
            // PlayerTwoCheckBox
            // 
            this.PlayerTwoCheckBox.AutoSize = true;
            this.PlayerTwoCheckBox.Location = new System.Drawing.Point(67, 310);
            this.PlayerTwoCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerTwoCheckBox.Name = "PlayerTwoCheckBox";
            this.PlayerTwoCheckBox.Size = new System.Drawing.Size(123, 29);
            this.PlayerTwoCheckBox.TabIndex = 11;
            this.PlayerTwoCheckBox.Text = "Player2:";
            this.PlayerTwoCheckBox.UseVisualStyleBackColor = true;
            this.PlayerTwoCheckBox.CheckedChanged += new System.EventHandler(this.PlayerTwoCheckBox_CheckedChanged);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 748);
            this.Controls.Add(this.PlayerTwoCheckBox);
            this.Controls.Add(this.player2TextBox);
            this.Controls.Add(this.player1TextBox);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.ten_lbl);
            this.Controls.Add(this.eight_lbl);
            this.Controls.Add(this.six_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameSettings";
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton six_lbl;
        private System.Windows.Forms.RadioButton eight_lbl;
        private System.Windows.Forms.RadioButton ten_lbl;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TextBox player1TextBox;
        private System.Windows.Forms.TextBox player2TextBox;
        private System.Windows.Forms.CheckBox PlayerTwoCheckBox;
    }
}

