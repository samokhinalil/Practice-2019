namespace Tanks
{
    partial class SettingsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lblApplesCount = new System.Windows.Forms.Label();
            this.lblTanksCount = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctlApplesCount = new System.Windows.Forms.NumericUpDown();
            this.ctlTanksCount = new System.Windows.Forms.NumericUpDown();
            this.ctlSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ctlApplesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(64, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(52, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // lblApplesCount
            // 
            this.lblApplesCount.AutoSize = true;
            this.lblApplesCount.Location = new System.Drawing.Point(12, 9);
            this.lblApplesCount.Name = "lblApplesCount";
            this.lblApplesCount.Size = new System.Drawing.Size(72, 13);
            this.lblApplesCount.TabIndex = 5;
            this.lblApplesCount.Text = "Apples count:";
            // 
            // lblTanksCount
            // 
            this.lblTanksCount.AutoSize = true;
            this.lblTanksCount.Location = new System.Drawing.Point(12, 38);
            this.lblTanksCount.Name = "lblTanksCount";
            this.lblTanksCount.Size = new System.Drawing.Size(70, 13);
            this.lblTanksCount.TabIndex = 6;
            this.lblTanksCount.Text = "Tanks count:";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(41, 67);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "Speed:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(122, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ctlApplesCount
            // 
            this.ctlApplesCount.Location = new System.Drawing.Point(90, 7);
            this.ctlApplesCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlApplesCount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ctlApplesCount.Name = "ctlApplesCount";
            this.ctlApplesCount.Size = new System.Drawing.Size(47, 20);
            this.ctlApplesCount.TabIndex = 9;
            this.ctlApplesCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ctlTanksCount
            // 
            this.ctlTanksCount.Location = new System.Drawing.Point(90, 33);
            this.ctlTanksCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ctlTanksCount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ctlTanksCount.Name = "ctlTanksCount";
            this.ctlTanksCount.Size = new System.Drawing.Size(47, 20);
            this.ctlTanksCount.TabIndex = 10;
            this.ctlTanksCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ctlSpeed
            // 
            this.ctlSpeed.Location = new System.Drawing.Point(90, 67);
            this.ctlSpeed.Maximum = 3;
            this.ctlSpeed.Minimum = 1;
            this.ctlSpeed.Name = "ctlSpeed";
            this.ctlSpeed.Size = new System.Drawing.Size(104, 45);
            this.ctlSpeed.TabIndex = 11;
            this.ctlSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ctlSpeed.Value = 1;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 145);
            this.Controls.Add(this.ctlSpeed);
            this.Controls.Add(this.ctlTanksCount);
            this.Controls.Add(this.ctlApplesCount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblTanksCount);
            this.Controls.Add(this.lblApplesCount);
            this.Controls.Add(this.btnOK);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.ctlApplesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblApplesCount;
        private System.Windows.Forms.Label lblTanksCount;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown ctlApplesCount;
        private System.Windows.Forms.NumericUpDown ctlTanksCount;
        private System.Windows.Forms.TrackBar ctlSpeed;
    }
}