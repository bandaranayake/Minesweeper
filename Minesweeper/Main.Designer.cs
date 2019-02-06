namespace Minesweeper
{
    partial class Main
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cmbxLevel = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblMines = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 70);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(576, 576);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_MouseClick);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // cmbxLevel
            // 
            this.cmbxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxLevel.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cmbxLevel.Location = new System.Drawing.Point(18, 18);
            this.cmbxLevel.Name = "cmbxLevel";
            this.cmbxLevel.Size = new System.Drawing.Size(80, 21);
            this.cmbxLevel.TabIndex = 2;
            this.cmbxLevel.SelectedIndexChanged += new System.EventHandler(this.Play);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(348, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(60, 23);
            this.lblTime.TabIndex = 3;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(268, 8);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 40);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.Play);
            // 
            // lblMines
            // 
            this.lblMines.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMines.ForeColor = System.Drawing.Color.Black;
            this.lblMines.Location = new System.Drawing.Point(168, 17);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(60, 23);
            this.lblMines.TabIndex = 4;
            this.lblMines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.LightGray;
            this.menu.Controls.Add(this.lblMines);
            this.menu.Controls.Add(this.btnPlay);
            this.menu.Controls.Add(this.lblTime);
            this.menu.Controls.Add(this.cmbxLevel);
            this.menu.Location = new System.Drawing.Point(12, 4);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(576, 60);
            this.menu.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(600, 671);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Minesweeper 🎮 ";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Label lblMines;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbxLevel;
    }
}

