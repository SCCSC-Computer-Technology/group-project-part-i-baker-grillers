<<<<<<< Updated upstream
﻿namespace GroupProjectTesting
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.btnFootBall = new System.Windows.Forms.Button();
            this.btnBasketBall = new System.Windows.Forms.Button();
            this.btnBaseBall = new System.Windows.Forms.Button();
            this.btnSoccer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.welcomeToSportsStrip = new System.Windows.Forms.ToolStrip();
            this.selectSportDropDB = new System.Windows.Forms.ToolStripDropDownButton();
            this.footballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basketballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soccerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeToSportsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFootBall
            // 
            this.btnFootBall.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonFootball1;
            this.btnFootBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFootBall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFootBall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFootBall.ForeColor = System.Drawing.Color.White;
            this.btnFootBall.Location = new System.Drawing.Point(12, 110);
            this.btnFootBall.Name = "btnFootBall";
            this.btnFootBall.Size = new System.Drawing.Size(126, 102);
            this.btnFootBall.TabIndex = 0;
            this.btnFootBall.Text = "Football";
            this.btnFootBall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFootBall.UseVisualStyleBackColor = true;
            this.btnFootBall.Click += new System.EventHandler(this.btnFootBall_Click);
            // 
            // btnBasketBall
            // 
            this.btnBasketBall.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonBasketball3;
            this.btnBasketBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBasketBall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBasketBall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasketBall.ForeColor = System.Drawing.Color.White;
            this.btnBasketBall.Location = new System.Drawing.Point(28, 334);
            this.btnBasketBall.Name = "btnBasketBall";
            this.btnBasketBall.Size = new System.Drawing.Size(126, 99);
            this.btnBasketBall.TabIndex = 1;
            this.btnBasketBall.Text = "BasketBall";
            this.btnBasketBall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBasketBall.UseVisualStyleBackColor = true;
            this.btnBasketBall.Click += new System.EventHandler(this.btnBasketBall_Click);
            // 
            // btnBaseBall
            // 
            this.btnBaseBall.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonBaseball2;
            this.btnBaseBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBaseBall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBaseBall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaseBall.ForeColor = System.Drawing.Color.White;
            this.btnBaseBall.Location = new System.Drawing.Point(668, 110);
            this.btnBaseBall.Name = "btnBaseBall";
            this.btnBaseBall.Size = new System.Drawing.Size(139, 91);
            this.btnBaseBall.TabIndex = 2;
            this.btnBaseBall.Text = "Baseball";
            this.btnBaseBall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBaseBall.UseVisualStyleBackColor = true;
            this.btnBaseBall.Click += new System.EventHandler(this.btnBaseBall_Click);
            // 
            // btnSoccer
            // 
            this.btnSoccer.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonSoccer1;
            this.btnSoccer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSoccer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSoccer.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoccer.ForeColor = System.Drawing.Color.White;
            this.btnSoccer.Location = new System.Drawing.Point(671, 298);
            this.btnSoccer.Name = "btnSoccer";
            this.btnSoccer.Size = new System.Drawing.Size(136, 102);
            this.btnSoccer.TabIndex = 3;
            this.btnSoccer.Text = "Soccer";
            this.btnSoccer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSoccer.UseVisualStyleBackColor = true;
            this.btnSoccer.Click += new System.EventHandler(this.btnSoccer_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(356, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 80);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(293, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose Your Sport!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeToSportsStrip
            // 
            this.welcomeToSportsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSportDropDB});
            this.welcomeToSportsStrip.Location = new System.Drawing.Point(0, 0);
            this.welcomeToSportsStrip.Name = "welcomeToSportsStrip";
            this.welcomeToSportsStrip.Size = new System.Drawing.Size(819, 25);
            this.welcomeToSportsStrip.TabIndex = 6;
            this.welcomeToSportsStrip.Text = "Sports";
            // 
            // selectSportDropDB
            // 
            this.selectSportDropDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectSportDropDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footballToolStripMenuItem,
            this.basketballToolStripMenuItem,
            this.baseballToolStripMenuItem,
            this.soccerToolStripMenuItem});
            this.selectSportDropDB.Image = ((System.Drawing.Image)(resources.GetObject("selectSportDropDB.Image")));
            this.selectSportDropDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectSportDropDB.Name = "selectSportDropDB";
            this.selectSportDropDB.Size = new System.Drawing.Size(53, 22);
            this.selectSportDropDB.Text = "Sports";
            // 
            // footballToolStripMenuItem
            // 
            this.footballToolStripMenuItem.Name = "footballToolStripMenuItem";
            this.footballToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.footballToolStripMenuItem.Text = "Football";
            this.footballToolStripMenuItem.Click += new System.EventHandler(this.footballToolStripMenuItem_Click);
            // 
            // basketballToolStripMenuItem
            // 
            this.basketballToolStripMenuItem.Name = "basketballToolStripMenuItem";
            this.basketballToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.basketballToolStripMenuItem.Text = "Basketball";
            this.basketballToolStripMenuItem.Click += new System.EventHandler(this.basketballToolStripMenuItem_Click);
            // 
            // baseballToolStripMenuItem
            // 
            this.baseballToolStripMenuItem.Name = "baseballToolStripMenuItem";
            this.baseballToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.baseballToolStripMenuItem.Text = "Baseball";
            this.baseballToolStripMenuItem.Click += new System.EventHandler(this.baseballToolStripMenuItem_Click);
            // 
            // soccerToolStripMenuItem
            // 
            this.soccerToolStripMenuItem.Name = "soccerToolStripMenuItem";
            this.soccerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.soccerToolStripMenuItem.Text = "Soccer";
            this.soccerToolStripMenuItem.Click += new System.EventHandler(this.soccerToolStripMenuItem_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GroupProjectTesting.Properties.Resources.welcome_Basic2Form_Cropped_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 497);
            this.Controls.Add(this.welcomeToSportsStrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSoccer);
            this.Controls.Add(this.btnBaseBall);
            this.Controls.Add(this.btnBasketBall);
            this.Controls.Add(this.btnFootBall);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.welcomeToSportsStrip.ResumeLayout(false);
            this.welcomeToSportsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFootBall;
        private System.Windows.Forms.Button btnBasketBall;
        private System.Windows.Forms.Button btnBaseBall;
        private System.Windows.Forms.Button btnSoccer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip welcomeToSportsStrip;
        private System.Windows.Forms.ToolStripDropDownButton selectSportDropDB;
        private System.Windows.Forms.ToolStripMenuItem footballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basketballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soccerToolStripMenuItem;
    }
=======
﻿namespace GroupProjectTesting
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.btnFootBall = new System.Windows.Forms.Button();
            this.btnBasketBall = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.welcomeToSportsStrip = new System.Windows.Forms.ToolStrip();
            this.selectSportDropDB = new System.Windows.Forms.ToolStripDropDownButton();
            this.footballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basketballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSGOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCSGO = new System.Windows.Forms.Button();
            this.groupTeamtip = new System.Windows.Forms.ToolTip(this.components);
            this.picFan1 = new System.Windows.Forms.PictureBox();
            this.picFan2 = new System.Windows.Forms.PictureBox();
            this.picFan3 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.welcomeToSportsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFan1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFan2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFan3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFootBall
            // 
            this.btnFootBall.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonFootball1;
            this.btnFootBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFootBall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFootBall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFootBall.ForeColor = System.Drawing.Color.White;
            this.btnFootBall.Location = new System.Drawing.Point(12, 387);
            this.btnFootBall.Name = "btnFootBall";
            this.btnFootBall.Size = new System.Drawing.Size(122, 107);
            this.btnFootBall.TabIndex = 0;
            this.btnFootBall.Text = "Football";
            this.btnFootBall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.groupTeamtip.SetToolTip(this.btnFootBall, "Football");
            this.btnFootBall.UseVisualStyleBackColor = true;
            this.btnFootBall.Click += new System.EventHandler(this.btnFootBall_Click);
            // 
            // btnBasketBall
            // 
            this.btnBasketBall.BackgroundImage = global::GroupProjectTesting.Properties.Resources.buttonBasketball3;
            this.btnBasketBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBasketBall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBasketBall.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasketBall.ForeColor = System.Drawing.Color.White;
            this.btnBasketBall.Location = new System.Drawing.Point(733, 202);
            this.btnBasketBall.Name = "btnBasketBall";
            this.btnBasketBall.Size = new System.Drawing.Size(126, 99);
            this.btnBasketBall.TabIndex = 1;
            this.btnBasketBall.Text = "BasketBall";
            this.btnBasketBall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.groupTeamtip.SetToolTip(this.btnBasketBall, "Basketball");
            this.btnBasketBall.UseVisualStyleBackColor = true;
            this.btnBasketBall.Click += new System.EventHandler(this.btnBasketBall_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(704, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 174);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Choose Your Sport!";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // welcomeToSportsStrip
            // 
            this.welcomeToSportsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSportDropDB});
            this.welcomeToSportsStrip.Location = new System.Drawing.Point(0, 0);
            this.welcomeToSportsStrip.Name = "welcomeToSportsStrip";
            this.welcomeToSportsStrip.Size = new System.Drawing.Size(871, 25);
            this.welcomeToSportsStrip.TabIndex = 6;
            this.welcomeToSportsStrip.Text = "Sports";
            // 
            // selectSportDropDB
            // 
            this.selectSportDropDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectSportDropDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.footballToolStripMenuItem,
            this.basketballToolStripMenuItem,
            this.cSGOToolStripMenuItem});
            this.selectSportDropDB.Image = ((System.Drawing.Image)(resources.GetObject("selectSportDropDB.Image")));
            this.selectSportDropDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectSportDropDB.Name = "selectSportDropDB";
            this.selectSportDropDB.Size = new System.Drawing.Size(53, 22);
            this.selectSportDropDB.Text = "Sports";
            this.selectSportDropDB.ToolTipText = "Sports Category Drop Down Menu";
            // 
            // footballToolStripMenuItem
            // 
            this.footballToolStripMenuItem.Name = "footballToolStripMenuItem";
            this.footballToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.footballToolStripMenuItem.Text = "Football";
            this.footballToolStripMenuItem.ToolTipText = "Football Form";
            this.footballToolStripMenuItem.Click += new System.EventHandler(this.footballToolStripMenuItem_Click);
            // 
            // basketballToolStripMenuItem
            // 
            this.basketballToolStripMenuItem.Name = "basketballToolStripMenuItem";
            this.basketballToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.basketballToolStripMenuItem.Text = "Basketball";
            this.basketballToolStripMenuItem.ToolTipText = "Basketball Form";
            this.basketballToolStripMenuItem.Click += new System.EventHandler(this.basketballToolStripMenuItem_Click);
            // 
            // cSGOToolStripMenuItem
            // 
            this.cSGOToolStripMenuItem.Name = "cSGOToolStripMenuItem";
            this.cSGOToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.cSGOToolStripMenuItem.Text = "CSGO";
            this.cSGOToolStripMenuItem.ToolTipText = "Counter-Strike: Global Offensive Form";
            this.cSGOToolStripMenuItem.Click += new System.EventHandler(this.cSGOToolStripMenuItem_Click);
            // 
            // btnCSGO
            // 
            this.btnCSGO.BackgroundImage = global::GroupProjectTesting.Properties.Resources.CSGO_button_image;
            this.btnCSGO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCSGO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCSGO.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCSGO.ForeColor = System.Drawing.Color.White;
            this.btnCSGO.Location = new System.Drawing.Point(12, 141);
            this.btnCSGO.Name = "btnCSGO";
            this.btnCSGO.Size = new System.Drawing.Size(122, 107);
            this.btnCSGO.TabIndex = 7;
            this.btnCSGO.Text = "CSGO";
            this.btnCSGO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.groupTeamtip.SetToolTip(this.btnCSGO, "Counter-Strike: Global Offensive");
            this.btnCSGO.UseVisualStyleBackColor = true;
            this.btnCSGO.Click += new System.EventHandler(this.btnCSGO_Click);
            // 
            // picFan1
            // 
            this.picFan1.BackColor = System.Drawing.Color.Transparent;
            this.picFan1.BackgroundImage = global::GroupProjectTesting.Properties.Resources.New_Fans_cheering;
            this.picFan1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFan1.Location = new System.Drawing.Point(377, 425);
            this.picFan1.Name = "picFan1";
            this.picFan1.Size = new System.Drawing.Size(100, 105);
            this.picFan1.TabIndex = 8;
            this.picFan1.TabStop = false;
            // 
            // picFan2
            // 
            this.picFan2.BackColor = System.Drawing.Color.Transparent;
            this.picFan2.BackgroundImage = global::GroupProjectTesting.Properties.Resources.New_Fans_cheering;
            this.picFan2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFan2.Location = new System.Drawing.Point(173, 425);
            this.picFan2.Name = "picFan2";
            this.picFan2.Size = new System.Drawing.Size(100, 105);
            this.picFan2.TabIndex = 9;
            this.picFan2.TabStop = false;
            // 
            // picFan3
            // 
            this.picFan3.BackColor = System.Drawing.Color.Transparent;
            this.picFan3.BackgroundImage = global::GroupProjectTesting.Properties.Resources.New_Fans_cheering;
            this.picFan3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFan3.Location = new System.Drawing.Point(560, 425);
            this.picFan3.Name = "picFan3";
            this.picFan3.Size = new System.Drawing.Size(100, 105);
            this.picFan3.TabIndex = 10;
            this.picFan3.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(735, 417);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(114, 97);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.Text = "Log out";
            this.groupTeamtip.SetToolTip(this.btnLogOut, "Log out");
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GroupProjectTesting.Properties.Resources.welcome_Basic2Form_Cropped_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 527);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.picFan3);
            this.Controls.Add(this.picFan2);
            this.Controls.Add(this.picFan1);
            this.Controls.Add(this.btnCSGO);
            this.Controls.Add(this.welcomeToSportsStrip);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBasketBall);
            this.Controls.Add(this.btnFootBall);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome Form";
            this.welcomeToSportsStrip.ResumeLayout(false);
            this.welcomeToSportsStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFan1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFan2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFan3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFootBall;
        private System.Windows.Forms.Button btnBasketBall;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolStrip welcomeToSportsStrip;
        private System.Windows.Forms.ToolStripDropDownButton selectSportDropDB;
        private System.Windows.Forms.ToolStripMenuItem footballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basketballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSGOToolStripMenuItem;
        private System.Windows.Forms.Button btnCSGO;
        private System.Windows.Forms.ToolTip groupTeamtip;
        private System.Windows.Forms.PictureBox picFan1;
        private System.Windows.Forms.PictureBox picFan2;
        private System.Windows.Forms.PictureBox picFan3;
        private System.Windows.Forms.Button btnLogOut;
    }
>>>>>>> Stashed changes
}