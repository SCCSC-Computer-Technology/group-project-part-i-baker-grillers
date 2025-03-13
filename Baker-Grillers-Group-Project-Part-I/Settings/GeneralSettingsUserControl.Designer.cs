namespace Baker_Grillers_Group_Project_Part_I.Settings
{
    partial class GeneralSettingsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.themeLabel = new System.Windows.Forms.Label();
            this.visibleSportsLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.enabledSportsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // themeComboBox
            // 
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Items.AddRange(new object[] {
            "Light",
            "Dark",
            "Auto (Use system)"});
            this.themeComboBox.Location = new System.Drawing.Point(10, 51);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(183, 28);
            this.themeComboBox.TabIndex = 0;
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.themeLabel.Location = new System.Drawing.Point(6, 28);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(62, 20);
            this.themeLabel.TabIndex = 1;
            this.themeLabel.Text = "Theme:";
            // 
            // visibleSportsLabel
            // 
            this.visibleSportsLabel.AutoSize = true;
            this.visibleSportsLabel.Location = new System.Drawing.Point(6, 28);
            this.visibleSportsLabel.Name = "visibleSportsLabel";
            this.visibleSportsLabel.Size = new System.Drawing.Size(123, 20);
            this.visibleSportsLabel.TabIndex = 2;
            this.visibleSportsLabel.Text = "Enabled Sports:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fontComboBox);
            this.groupBox1.Controls.Add(this.fontLabel);
            this.groupBox1.Controls.Add(this.themeLabel);
            this.groupBox1.Controls.Add(this.themeComboBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 149);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visual Appearance";
            // 
            // fontComboBox
            // 
            this.fontComboBox.FormattingEnabled = true;
            this.fontComboBox.Location = new System.Drawing.Point(10, 109);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(183, 28);
            this.fontComboBox.TabIndex = 3;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(6, 86);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(46, 20);
            this.fontLabel.TabIndex = 2;
            this.fontLabel.Text = "Font:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.enabledSportsCheckedListBox);
            this.groupBox2.Controls.Add(this.visibleSportsLabel);
            this.groupBox2.Location = new System.Drawing.Point(3, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 544);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // enabledSportsCheckedListBox
            // 
            this.enabledSportsCheckedListBox.FormattingEnabled = true;
            this.enabledSportsCheckedListBox.Items.AddRange(new object[] {
            "CSGO",
            "Football",
            "Basketball"});
            this.enabledSportsCheckedListBox.Location = new System.Drawing.Point(6, 51);
            this.enabledSportsCheckedListBox.Name = "enabledSportsCheckedListBox";
            this.enabledSportsCheckedListBox.Size = new System.Drawing.Size(187, 96);
            this.enabledSportsCheckedListBox.TabIndex = 7;
            // 
            // GeneralSettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GeneralSettingsUserControl";
            this.Size = new System.Drawing.Size(550, 747);
            this.Load += new System.EventHandler(this.GeneralSettingsUserControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Label visibleSportsLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox fontComboBox;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.CheckedListBox enabledSportsCheckedListBox;
    }
}
