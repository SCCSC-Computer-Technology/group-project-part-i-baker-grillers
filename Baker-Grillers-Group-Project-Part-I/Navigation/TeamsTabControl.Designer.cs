namespace Baker_Grillers_Group_Project_Part_I.Navigation
{
    partial class TeamsTabControl
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
            this.teamsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.teamsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // teamsGridView
            // 
            this.teamsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.teamsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamsGridView.Location = new System.Drawing.Point(0, 0);
            this.teamsGridView.Name = "teamsGridView";
            this.teamsGridView.RowHeadersWidth = 62;
            this.teamsGridView.Size = new System.Drawing.Size(757, 505);
            this.teamsGridView.TabIndex = 1;
            // 
            // TeamsTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.teamsGridView);
            this.Name = "TeamsTabControl";
            this.Size = new System.Drawing.Size(757, 505);
            ((System.ComponentModel.ISupportInitialize)(this.teamsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView teamsGridView;
    }
}
