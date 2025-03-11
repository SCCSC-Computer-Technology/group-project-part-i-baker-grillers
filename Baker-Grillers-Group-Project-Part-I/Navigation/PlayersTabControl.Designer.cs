namespace Baker_Grillers_Group_Project_Part_I.Navigation
{
    partial class PlayersTabControl
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
            this.playersGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // playersGridView
            // 
            this.playersGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.playersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersGridView.Location = new System.Drawing.Point(0, 0);
            this.playersGridView.Name = "playersGridView";
            this.playersGridView.RowHeadersWidth = 62;
            this.playersGridView.Size = new System.Drawing.Size(647, 515);
            this.playersGridView.TabIndex = 0;
            this.playersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.playersGridView_CellContentClick);
            // 
            // PlayersTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.playersGridView);
            this.Name = "PlayersTabControl";
            this.Size = new System.Drawing.Size(647, 515);
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView playersGridView;
    }
}
