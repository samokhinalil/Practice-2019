namespace Tanks
{
    partial class TanksForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.tbScore = new System.Windows.Forms.TextBox();
            this.shotTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctlFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctlExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctlMap = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartGame.Location = new System.Drawing.Point(371, 2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(129, 23);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // tbScore
            // 
            this.tbScore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbScore.Enabled = false;
            this.tbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbScore.Location = new System.Drawing.Point(209, 0);
            this.tbScore.Name = "tbScore";
            this.tbScore.Size = new System.Drawing.Size(100, 26);
            this.tbScore.TabIndex = 1;
            this.tbScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // shotTimer
            // 
            this.shotTimer.Interval = 30;
            this.shotTimer.Tick += new System.EventHandler(this.ShotTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ctlFile
            // 
            this.ctlFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlAbout,
            this.toolStripMenuItem1,
            this.ctlExit});
            this.ctlFile.Name = "ctlFile";
            this.ctlFile.Size = new System.Drawing.Size(37, 20);
            this.ctlFile.Text = "File";
            // 
            // ctlAbout
            // 
            this.ctlAbout.Enabled = false;
            this.ctlAbout.Name = "ctlAbout";
            this.ctlAbout.Size = new System.Drawing.Size(107, 22);
            this.ctlAbout.Text = "About";
            this.ctlAbout.Click += new System.EventHandler(this.CtlAbout_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 6);
            // 
            // ctlExit
            // 
            this.ctlExit.Name = "ctlExit";
            this.ctlExit.Size = new System.Drawing.Size(107, 22);
            this.ctlExit.Text = "Exit";
            this.ctlExit.Click += new System.EventHandler(this.CtlExit_Click);
            // 
            // ctlMap
            // 
            this.ctlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlMap.Location = new System.Drawing.Point(0, 27);
            this.ctlMap.Name = "ctlMap";
            this.ctlMap.Size = new System.Drawing.Size(500, 500);
            this.ctlMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ctlMap.TabIndex = 3;
            this.ctlMap.TabStop = false;
            // 
            // TanksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 530);
            this.Controls.Add(this.ctlMap);
            this.Controls.Add(this.tbScore);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(520, 540);
            this.Name = "TanksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanks";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TanksForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.Timer shotTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctlFile;
        private System.Windows.Forms.ToolStripMenuItem ctlAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctlExit;
        private System.Windows.Forms.PictureBox ctlMap;
    }
}

