namespace WindowsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblScore = new System.Windows.Forms.Label();
            this.lblDebug = new System.Windows.Forms.Label();
            this.tSachiel = new System.Windows.Forms.Timer(this.components);
            this.tIsrafel = new System.Windows.Forms.Timer(this.components);
            this.tWide = new System.Windows.Forms.Timer(this.components);
            this.tFast = new System.Windows.Forms.Timer(this.components);
            this.tDamage = new System.Windows.Forms.Timer(this.components);
            this.tInvuln = new System.Windows.Forms.Timer(this.components);
            this.tSpeed = new System.Windows.Forms.Timer(this.components);
            this.tShrink = new System.Windows.Forms.Timer(this.components);
            this.tHurt = new System.Windows.Forms.Timer(this.components);
            this.tShogouki = new System.Windows.Forms.Timer(this.components);
            this.tZerogouki = new System.Windows.Forms.Timer(this.components);
            this.tBombExplode = new System.Windows.Forms.Timer(this.components);
            this.tBomb = new System.Windows.Forms.Timer(this.components);
            this.tZerogoukiMove = new System.Windows.Forms.Timer(this.components);
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblHiscore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(660, 10);
            this.lblScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(131, 25);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score:";
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.BackColor = System.Drawing.Color.Red;
            this.lblDebug.ForeColor = System.Drawing.Color.White;
            this.lblDebug.Location = new System.Drawing.Point(10, 550);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 1;
            // 
            // tSachiel
            // 
            this.tSachiel.Interval = 4000;
            this.tSachiel.Tick += new System.EventHandler(this.tSachiel_Tick);
            // 
            // tIsrafel
            // 
            this.tIsrafel.Interval = 4000;
            this.tIsrafel.Tick += new System.EventHandler(this.tIsrafel_Tick);
            // 
            // tWide
            // 
            this.tWide.Interval = 10000;
            this.tWide.Tick += new System.EventHandler(this.tWide_Tick);
            // 
            // tFast
            // 
            this.tFast.Interval = 10000;
            this.tFast.Tick += new System.EventHandler(this.tFast_Tick);
            // 
            // tDamage
            // 
            this.tDamage.Interval = 10000;
            this.tDamage.Tick += new System.EventHandler(this.tDamage_Tick);
            // 
            // tInvuln
            // 
            this.tInvuln.Interval = 1000;
            this.tInvuln.Tick += new System.EventHandler(this.tInvuln_Tick);
            // 
            // tSpeed
            // 
            this.tSpeed.Interval = 10000;
            this.tSpeed.Tick += new System.EventHandler(this.tSpeed_Tick);
            // 
            // tShrink
            // 
            this.tShrink.Interval = 10000;
            this.tShrink.Tick += new System.EventHandler(this.tShrink_Tick);
            // 
            // tHurt
            // 
            this.tHurt.Interval = 2000;
            this.tHurt.Tick += new System.EventHandler(this.tHurt_Tick);
            // 
            // tShogouki
            // 
            this.tShogouki.Interval = 1000;
            this.tShogouki.Tick += new System.EventHandler(this.tShogouki_Tick);
            // 
            // tZerogouki
            // 
            this.tZerogouki.Interval = 500;
            this.tZerogouki.Tick += new System.EventHandler(this.tZerogouki_Tick);
            // 
            // tBombExplode
            // 
            this.tBombExplode.Interval = 500;
            // 
            // tBomb
            // 
            this.tBomb.Interval = 2500;
            // 
            // tZerogoukiMove
            // 
            this.tZerogoukiMove.Interval = 2000;
            this.tZerogoukiMove.Tick += new System.EventHandler(this.tZerogoukiMove_Tick);
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.ForeColor = System.Drawing.Color.White;
            this.lblHelp.Location = new System.Drawing.Point(144, 29);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(534, 390);
            this.lblHelp.TabIndex = 2;
            this.lblHelp.Text = resources.GetString("lblHelp.Text");
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
            // 
            // lblHiscore
            // 
            this.lblHiscore.BackColor = System.Drawing.Color.Transparent;
            this.lblHiscore.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblHiscore.ForeColor = System.Drawing.Color.White;
            this.lblHiscore.Location = new System.Drawing.Point(662, 35);
            this.lblHiscore.Margin = new System.Windows.Forms.Padding(0);
            this.lblHiscore.Name = "lblHiscore";
            this.lblHiscore.Size = new System.Drawing.Size(131, 25);
            this.lblHiscore.TabIndex = 0;
            this.lblHiscore.Text = "High: 1000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.lblHiscore);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Ramiel-chan VS. The Nasty Evas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Timer tSachiel;
        private System.Windows.Forms.Timer tIsrafel;
        private System.Windows.Forms.Timer tWide;
        private System.Windows.Forms.Timer tFast;
        private System.Windows.Forms.Timer tDamage;
        private System.Windows.Forms.Timer tInvuln;
        private System.Windows.Forms.Timer tSpeed;
        private System.Windows.Forms.Timer tShrink;
        private System.Windows.Forms.Timer tHurt;
        private System.Windows.Forms.Timer tShogouki;
        private System.Windows.Forms.Timer tZerogouki;
        private System.Windows.Forms.Timer tBombExplode;
        private System.Windows.Forms.Timer tBomb;
        private System.Windows.Forms.Timer tZerogoukiMove;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblHiscore;
    }
}

