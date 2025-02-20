namespace Baker_Grillers_Group_Project_Part_I
{
    partial class MainForm
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
            this.exitButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.teamSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.teamNameTxtBx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stadiumNameResultLabel = new System.Windows.Forms.Label();
            this.teamNameResultLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.playersListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(846, 484);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(741, 484);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "&Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // teamSearchButton
            // 
            this.teamSearchButton.Location = new System.Drawing.Point(329, 73);
            this.teamSearchButton.Name = "teamSearchButton";
            this.teamSearchButton.Size = new System.Drawing.Size(101, 37);
            this.teamSearchButton.TabIndex = 2;
            this.teamSearchButton.Text = "Search";
            this.teamSearchButton.UseVisualStyleBackColor = true;
            this.teamSearchButton.Click += new System.EventHandler(this.teamsSearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Teams:";
            // 
            // teamNameTxtBx
            // 
            this.teamNameTxtBx.Location = new System.Drawing.Point(159, 6);
            this.teamNameTxtBx.Name = "teamNameTxtBx";
            this.teamNameTxtBx.Size = new System.Drawing.Size(271, 30);
            this.teamNameTxtBx.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.stadiumNameResultLabel);
            this.panel1.Controls.Add(this.teamNameResultLabel);
            this.panel1.Controls.Add(this.teamNameTxtBx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.teamSearchButton);
            this.panel1.Location = new System.Drawing.Point(22, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 113);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Event Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team Name:";
            // 
            // stadiumNameResultLabel
            // 
            this.stadiumNameResultLabel.AutoSize = true;
            this.stadiumNameResultLabel.Location = new System.Drawing.Point(155, 74);
            this.stadiumNameResultLabel.Name = "stadiumNameResultLabel";
            this.stadiumNameResultLabel.Size = new System.Drawing.Size(109, 23);
            this.stadiumNameResultLabel.TabIndex = 6;
            this.stadiumNameResultLabel.Text = "Placeholder";
            // 
            // teamNameResultLabel
            // 
            this.teamNameResultLabel.AutoSize = true;
            this.teamNameResultLabel.Location = new System.Drawing.Point(126, 51);
            this.teamNameResultLabel.Name = "teamNameResultLabel";
            this.teamNameResultLabel.Size = new System.Drawing.Size(109, 23);
            this.teamNameResultLabel.TabIndex = 5;
            this.teamNameResultLabel.Text = "Placeholder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "API Testing";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.playersListBox);
            this.panel2.Location = new System.Drawing.Point(22, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 253);
            this.panel2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Players:";
            // 
            // playersListBox
            // 
            this.playersListBox.FormattingEnabled = true;
            this.playersListBox.ItemHeight = 23;
            this.playersListBox.Location = new System.Drawing.Point(0, 37);
            this.playersListBox.Name = "playersListBox";
            this.playersListBox.Size = new System.Drawing.Size(433, 211);
            this.playersListBox.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.exitButton);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BG Sports Stats";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button teamSearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox teamNameTxtBx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label teamNameResultLabel;
        private System.Windows.Forms.Label stadiumNameResultLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox playersListBox;
    }
}

