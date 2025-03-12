namespace Baker_Grillers_Group_Project_Part_I
{
    partial class ForgotPasswordForm
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
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.sendEmailButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.resetCodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sendPanel = new System.Windows.Forms.Panel();
            this.resetPanel = new System.Windows.Forms.Panel();
            this.seePasswordButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.sendPanel.SuspendLayout();
            this.resetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(11, 25);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(156, 30);
            this.emailTextBox.TabIndex = 0;
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(11, 53);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(156, 23);
            this.sendEmailButton.TabIndex = 1;
            this.sendEmailButton.Text = "&Send";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(314, 171);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(210, 53);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(156, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "&Reset Password";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // resetCodeTextBox
            // 
            this.resetCodeTextBox.Location = new System.Drawing.Point(210, 25);
            this.resetCodeTextBox.Name = "resetCodeTextBox";
            this.resetCodeTextBox.Size = new System.Drawing.Size(156, 30);
            this.resetCodeTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reset Code";
            // 
            // sendPanel
            // 
            this.sendPanel.Controls.Add(this.emailTextBox);
            this.sendPanel.Controls.Add(this.label2);
            this.sendPanel.Controls.Add(this.sendEmailButton);
            this.sendPanel.Controls.Add(this.label1);
            this.sendPanel.Controls.Add(this.resetButton);
            this.sendPanel.Controls.Add(this.resetCodeTextBox);
            this.sendPanel.Location = new System.Drawing.Point(12, 12);
            this.sendPanel.Name = "sendPanel";
            this.sendPanel.Size = new System.Drawing.Size(377, 153);
            this.sendPanel.TabIndex = 0;
            // 
            // resetPanel
            // 
            this.resetPanel.Controls.Add(this.seePasswordButton);
            this.resetPanel.Controls.Add(this.passwordTextBox);
            this.resetPanel.Controls.Add(this.label3);
            this.resetPanel.Controls.Add(this.label4);
            this.resetPanel.Controls.Add(this.resetPasswordButton);
            this.resetPanel.Controls.Add(this.confirmPasswordTextBox);
            this.resetPanel.Location = new System.Drawing.Point(12, 13);
            this.resetPanel.Name = "resetPanel";
            this.resetPanel.Size = new System.Drawing.Size(377, 153);
            this.resetPanel.TabIndex = 8;
            this.resetPanel.Visible = false;
            // 
            // seePasswordButton
            // 
            this.seePasswordButton.BackgroundImage = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.ClosedEye;
            this.seePasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.seePasswordButton.Location = new System.Drawing.Point(268, 71);
            this.seePasswordButton.Name = "seePasswordButton";
            this.seePasswordButton.Size = new System.Drawing.Size(30, 30);
            this.seePasswordButton.TabIndex = 2;
            this.seePasswordButton.UseVisualStyleBackColor = true;
            this.seePasswordButton.Click += new System.EventHandler(this.seePasswordButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(107, 32);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(156, 30);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter New Password";
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Location = new System.Drawing.Point(107, 115);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(155, 23);
            this.resetPasswordButton.TabIndex = 3;
            this.resetPasswordButton.Text = "Reset &Password";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(106, 76);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(156, 30);
            this.confirmPasswordTextBox.TabIndex = 1;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 206);
            this.Controls.Add(this.resetPanel);
            this.Controls.Add(this.sendPanel);
            this.Controls.Add(this.exitButton);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPasswordForm";
            this.Load += new System.EventHandler(this.ForgotPasswordForm_Load);
            this.sendPanel.ResumeLayout(false);
            this.sendPanel.PerformLayout();
            this.resetPanel.ResumeLayout(false);
            this.resetPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button sendEmailButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox resetCodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sendPanel;
        private System.Windows.Forms.Panel resetPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button resetPasswordButton;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button seePasswordButton;
    }
}