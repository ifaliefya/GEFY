namespace GazethruApps
{
    partial class FormStartGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartGame));
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.TBQuest = new System.Windows.Forms.RichTextBox();
            this.PBOpsiKanan = new System.Windows.Forms.PictureBox();
            this.PBOpsiKiri = new System.Windows.Forms.PictureBox();
            this.TBNamaKiri = new System.Windows.Forms.TextBox();
            this.TBKetKiri = new System.Windows.Forms.RichTextBox();
            this.TBNamaKanan = new System.Windows.Forms.TextBox();
            this.TBKetKanan = new System.Windows.Forms.RichTextBox();
            this.LabelCoba = new System.Windows.Forms.Label();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.PnlTimer = new System.Windows.Forms.Panel();
            this.LblNextSoal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LblTimer = new System.Windows.Forms.Label();
            this.TbxResult = new System.Windows.Forms.TextBox();
            this.BTNClose = new System.Windows.Forms.Button();
            this.LBPoinKe = new System.Windows.Forms.Label();
            this.LBTotalPoin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBSoalKe = new System.Windows.Forms.Label();
            this.LBTotalSoal = new System.Windows.Forms.Label();
            this.TombolTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKiri)).BeginInit();
            this.PnlGame.SuspendLayout();
            this.PnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TBQuest
            // 
            this.TBQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(121)))));
            this.TBQuest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBQuest.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBQuest.Location = new System.Drawing.Point(696, 30);
            this.TBQuest.Name = "TBQuest";
            this.TBQuest.Size = new System.Drawing.Size(504, 106);
            this.TBQuest.TabIndex = 15;
            this.TBQuest.Text = "";
            // 
            // PBOpsiKanan
            // 
            this.PBOpsiKanan.Location = new System.Drawing.Point(1321, 662);
            this.PBOpsiKanan.Name = "PBOpsiKanan";
            this.PBOpsiKanan.Size = new System.Drawing.Size(191, 182);
            this.PBOpsiKanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOpsiKanan.TabIndex = 9;
            this.PBOpsiKanan.TabStop = false;
            this.PBOpsiKanan.Click += new System.EventHandler(this.PBOpsiKanan_Click);
            // 
            // PBOpsiKiri
            // 
            this.PBOpsiKiri.Location = new System.Drawing.Point(342, 114);
            this.PBOpsiKiri.Name = "PBOpsiKiri";
            this.PBOpsiKiri.Size = new System.Drawing.Size(200, 200);
            this.PBOpsiKiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOpsiKiri.TabIndex = 10;
            this.PBOpsiKiri.TabStop = false;
            this.PBOpsiKiri.Click += new System.EventHandler(this.PBOpsiKiri_Click);
            // 
            // TBNamaKiri
            // 
            this.TBNamaKiri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBNamaKiri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBNamaKiri.Enabled = false;
            this.TBNamaKiri.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNamaKiri.Location = new System.Drawing.Point(303, 306);
            this.TBNamaKiri.Name = "TBNamaKiri";
            this.TBNamaKiri.ReadOnly = true;
            this.TBNamaKiri.Size = new System.Drawing.Size(283, 24);
            this.TBNamaKiri.TabIndex = 12;
            // 
            // TBKetKiri
            // 
            this.TBKetKiri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBKetKiri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBKetKiri.Enabled = false;
            this.TBKetKiri.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBKetKiri.Location = new System.Drawing.Point(280, 626);
            this.TBKetKiri.Name = "TBKetKiri";
            this.TBKetKiri.ReadOnly = true;
            this.TBKetKiri.Size = new System.Drawing.Size(324, 96);
            this.TBKetKiri.TabIndex = 14;
            this.TBKetKiri.Text = "";
            // 
            // TBNamaKanan
            // 
            this.TBNamaKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBNamaKanan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBNamaKanan.Enabled = false;
            this.TBNamaKanan.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNamaKanan.Location = new System.Drawing.Point(1277, 306);
            this.TBNamaKanan.Name = "TBNamaKanan";
            this.TBNamaKanan.ReadOnly = true;
            this.TBNamaKanan.Size = new System.Drawing.Size(283, 24);
            this.TBNamaKanan.TabIndex = 11;
            // 
            // TBKetKanan
            // 
            this.TBKetKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBKetKanan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBKetKanan.Enabled = false;
            this.TBKetKanan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBKetKanan.Location = new System.Drawing.Point(1254, 626);
            this.TBKetKanan.Name = "TBKetKanan";
            this.TBKetKanan.ReadOnly = true;
            this.TBKetKanan.Size = new System.Drawing.Size(324, 96);
            this.TBKetKanan.TabIndex = 13;
            this.TBKetKanan.Text = "";
            // 
            // LabelCoba
            // 
            this.LabelCoba.AutoSize = true;
            this.LabelCoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCoba.Location = new System.Drawing.Point(55, 453);
            this.LabelCoba.Name = "LabelCoba";
            this.LabelCoba.Size = new System.Drawing.Size(60, 24);
            this.LabelCoba.TabIndex = 16;
            this.LabelCoba.Text = "label1";
            // 
            // PnlGame
            // 
            this.PnlGame.Controls.Add(this.PnlTimer);
            this.PnlGame.Controls.Add(this.TbxResult);
            this.PnlGame.Controls.Add(this.BTNClose);
            this.PnlGame.Controls.Add(this.LabelCoba);
            this.PnlGame.Controls.Add(this.TBKetKanan);
            this.PnlGame.Controls.Add(this.TBNamaKanan);
            this.PnlGame.Controls.Add(this.TBKetKiri);
            this.PnlGame.Controls.Add(this.TBNamaKiri);
            this.PnlGame.Controls.Add(this.PBOpsiKiri);
            this.PnlGame.Controls.Add(this.PBOpsiKanan);
            this.PnlGame.Controls.Add(this.TBQuest);
            this.PnlGame.Location = new System.Drawing.Point(24, 98);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(1858, 915);
            this.PnlGame.TabIndex = 0;
            // 
            // PnlTimer
            // 
            this.PnlTimer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnlTimer.Controls.Add(this.LblNextSoal);
            this.PnlTimer.Controls.Add(this.button1);
            this.PnlTimer.Controls.Add(this.LblTimer);
            this.PnlTimer.Location = new System.Drawing.Point(457, 214);
            this.PnlTimer.Name = "PnlTimer";
            this.PnlTimer.Size = new System.Drawing.Size(944, 486);
            this.PnlTimer.TabIndex = 22;
            // 
            // LblNextSoal
            // 
            this.LblNextSoal.AutoSize = true;
            this.LblNextSoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNextSoal.Location = new System.Drawing.Point(454, 158);
            this.LblNextSoal.Name = "LblNextSoal";
            this.LblNextSoal.Size = new System.Drawing.Size(51, 20);
            this.LblNextSoal.TabIndex = 18;
            this.LblNextSoal.Text = "label1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(931, 865);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LblTimer
            // 
            this.LblTimer.AutoSize = true;
            this.LblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimer.Location = new System.Drawing.Point(453, 217);
            this.LblTimer.Name = "LblTimer";
            this.LblTimer.Size = new System.Drawing.Size(60, 24);
            this.LblTimer.TabIndex = 16;
            this.LblTimer.Text = "label1";
            // 
            // TbxResult
            // 
            this.TbxResult.BackColor = System.Drawing.Color.MistyRose;
            this.TbxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxResult.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TbxResult.Location = new System.Drawing.Point(805, 280);
            this.TbxResult.Name = "TbxResult";
            this.TbxResult.ReadOnly = true;
            this.TbxResult.Size = new System.Drawing.Size(312, 22);
            this.TbxResult.TabIndex = 20;
            this.TbxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BTNClose
            // 
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(931, 865);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(75, 23);
            this.BTNClose.TabIndex = 17;
            this.BTNClose.Text = "Next";
            this.BTNClose.UseVisualStyleBackColor = true;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // LBPoinKe
            // 
            this.LBPoinKe.AutoSize = true;
            this.LBPoinKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPoinKe.Location = new System.Drawing.Point(1790, 31);
            this.LBPoinKe.Name = "LBPoinKe";
            this.LBPoinKe.Size = new System.Drawing.Size(21, 24);
            this.LBPoinKe.TabIndex = 10;
            this.LBPoinKe.Text = "0";
            // 
            // LBTotalPoin
            // 
            this.LBTotalPoin.AutoSize = true;
            this.LBTotalPoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotalPoin.Location = new System.Drawing.Point(1819, 31);
            this.LBTotalPoin.Name = "LBTotalPoin";
            this.LBTotalPoin.Size = new System.Drawing.Size(33, 24);
            this.LBTotalPoin.TabIndex = 9;
            this.LBTotalPoin.Text = "/ 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1720, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // LBSoalKe
            // 
            this.LBSoalKe.AutoSize = true;
            this.LBSoalKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBSoalKe.Location = new System.Drawing.Point(50, 31);
            this.LBSoalKe.Name = "LBSoalKe";
            this.LBSoalKe.Size = new System.Drawing.Size(21, 24);
            this.LBSoalKe.TabIndex = 6;
            this.LBSoalKe.Text = "0";
            // 
            // LBTotalSoal
            // 
            this.LBTotalSoal.AutoSize = true;
            this.LBTotalSoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotalSoal.Location = new System.Drawing.Point(79, 31);
            this.LBTotalSoal.Name = "LBTotalSoal";
            this.LBTotalSoal.Size = new System.Drawing.Size(33, 24);
            this.LBTotalSoal.TabIndex = 6;
            this.LBTotalSoal.Text = "/ 0";
            // 
            // TombolTimer
            // 
            this.TombolTimer.Tick += new System.EventHandler(this.TombolTimer_Tick);
            // 
            // FormStartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.PnlGame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBTotalPoin);
            this.Controls.Add(this.LBPoinKe);
            this.Controls.Add(this.LBTotalSoal);
            this.Controls.Add(this.LBSoalKe);
            this.Name = "FormStartGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStartGame";
            this.Load += new System.EventHandler(this.FormStartGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKiri)).EndInit();
            this.PnlGame.ResumeLayout(false);
            this.PnlGame.PerformLayout();
            this.PnlTimer.ResumeLayout(false);
            this.PnlTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer CountdownTimer;
        private System.Windows.Forms.RichTextBox TBQuest;
        private System.Windows.Forms.PictureBox PBOpsiKanan;
        private System.Windows.Forms.PictureBox PBOpsiKiri;
        private System.Windows.Forms.TextBox TBNamaKiri;
        private System.Windows.Forms.RichTextBox TBKetKiri;
        private System.Windows.Forms.TextBox TBNamaKanan;
        private System.Windows.Forms.RichTextBox TBKetKanan;
        private System.Windows.Forms.Label LabelCoba;
        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Label LBPoinKe;
        private System.Windows.Forms.Label LBTotalPoin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBSoalKe;
        private System.Windows.Forms.Label LBTotalSoal;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.TextBox TbxResult;
        private System.Windows.Forms.Timer TombolTimer;
        private System.Windows.Forms.Panel PnlTimer;
        private System.Windows.Forms.Label LblNextSoal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LblTimer;
    }
}