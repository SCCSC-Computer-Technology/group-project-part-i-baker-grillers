﻿namespace Baker_Grillers_Group_Project_Part_I
{
    partial class CreateAccountForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.seePasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(255, 208);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "&Close";
            this.toolTip1.SetToolTip(this.closeButton, "Close this window");
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(33, 37);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(240, 30);
            this.emailTextBox.TabIndex = 0;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(30, 19);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(154, 23);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Enter Your Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(33, 90);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(240, 30);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Confirm Password";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(33, 138);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(240, 30);
            this.confirmPasswordTextBox.TabIndex = 2;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // createAccountButton
            // 
            this.createAccountButton.Location = new System.Drawing.Point(100, 166);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(105, 39);
            this.createAccountButton.TabIndex = 4;
            this.createAccountButton.Text = "Create &Account";
            this.toolTip1.SetToolTip(this.createAccountButton, "Create an account using the entered information");
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // seePasswordButton
            // 
            this.seePasswordButton.BackgroundImage = global::Baker_Grillers_Group_Project_Part_I.Properties.Resources.ClosedEye;
            this.seePasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.seePasswordButton.Location = new System.Drawing.Point(279, 133);
            this.seePasswordButton.Name = "seePasswordButton";
            this.seePasswordButton.Size = new System.Drawing.Size(30, 30);
            this.seePasswordButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.seePasswordButton, "Click to unhide/hide password");
            this.seePasswordButton.UseVisualStyleBackColor = true;
            this.seePasswordButton.Click += new System.EventHandler(this.seePasswordButton_Click);
            // 
            // CreateAccountForm
            // 
            this.AcceptButton = this.createAccountButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(342, 243);
            this.Controls.Add(this.seePasswordButton);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CreateAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Account";
            this.Load += new System.EventHandler(this.CreateAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button seePasswordButton;
    }
}