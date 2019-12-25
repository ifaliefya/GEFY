namespace GazethruApps
{
    partial class UCGameOpsi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGameOpsi));
            this.PanelOpsi = new System.Windows.Forms.Panel();
            this.BTNClose = new System.Windows.Forms.Button();
            this.TBKetKanan = new System.Windows.Forms.RichTextBox();
            this.TBNamaKanan = new System.Windows.Forms.TextBox();
            this.TBKetKiri = new System.Windows.Forms.RichTextBox();
            this.TBNamaKiri = new System.Windows.Forms.TextBox();
            this.LabelResult = new System.Windows.Forms.Label();
            this.LabelCoba = new System.Windows.Forms.Label();
            this.PBOpsiKiri = new System.Windows.Forms.PictureBox();
            this.PBOpsiKanan = new System.Windows.Forms.PictureBox();
            this.TimerTombol = new System.Windows.Forms.Timer(this.components);
            this.TBQuest = new System.Windows.Forms.RichTextBox();
            this.LBTotalSoal = new System.Windows.Forms.Label();
            this.LBTotalPoin = new System.Windows.Forms.Label();
            this.LBPoinKe = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBSoalKe = new System.Windows.Forms.Label();
            this.PanelOpsi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKiri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelOpsi
            // 
            this.PanelOpsi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(144)))), ((int)(((byte)(65)))));
            this.PanelOpsi.Controls.Add(this.BTNClose);
            this.PanelOpsi.Controls.Add(this.TBKetKanan);
            this.PanelOpsi.Controls.Add(this.TBNamaKanan);
            this.PanelOpsi.Controls.Add(this.TBKetKiri);
            this.PanelOpsi.Controls.Add(this.TBNamaKiri);
            this.PanelOpsi.Controls.Add(this.LabelResult);
            this.PanelOpsi.Controls.Add(this.LabelCoba);
            this.PanelOpsi.Controls.Add(this.PBOpsiKiri);
            this.PanelOpsi.Controls.Add(this.PBOpsiKanan);
            this.PanelOpsi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelOpsi.Location = new System.Drawing.Point(0, 112);
            this.PanelOpsi.Name = "PanelOpsi";
            this.PanelOpsi.Size = new System.Drawing.Size(1904, 929);
            this.PanelOpsi.TabIndex = 0;
            this.PanelOpsi.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelOpsi_Paint);
            // 
            // BTNClose
            // 
            this.BTNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.Location = new System.Drawing.Point(900, 877);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(75, 23);
            this.BTNClose.TabIndex = 7;
            this.BTNClose.Text = "Next";
            this.BTNClose.UseVisualStyleBackColor = true;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // TBKetKanan
            // 
            this.TBKetKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBKetKanan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBKetKanan.Enabled = false;
            this.TBKetKanan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBKetKanan.Location = new System.Drawing.Point(1284, 599);
            this.TBKetKanan.Name = "TBKetKanan";
            this.TBKetKanan.ReadOnly = true;
            this.TBKetKanan.Size = new System.Drawing.Size(324, 96);
            this.TBKetKanan.TabIndex = 6;
            this.TBKetKanan.Text = "";
            // 
            // TBNamaKanan
            // 
            this.TBNamaKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBNamaKanan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBNamaKanan.Enabled = false;
            this.TBNamaKanan.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNamaKanan.Location = new System.Drawing.Point(1307, 279);
            this.TBNamaKanan.Name = "TBNamaKanan";
            this.TBNamaKanan.ReadOnly = true;
            this.TBNamaKanan.Size = new System.Drawing.Size(283, 24);
            this.TBNamaKanan.TabIndex = 5;
            // 
            // TBKetKiri
            // 
            this.TBKetKiri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBKetKiri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBKetKiri.Enabled = false;
            this.TBKetKiri.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBKetKiri.Location = new System.Drawing.Point(310, 599);
            this.TBKetKiri.Name = "TBKetKiri";
            this.TBKetKiri.ReadOnly = true;
            this.TBKetKiri.Size = new System.Drawing.Size(324, 96);
            this.TBKetKiri.TabIndex = 6;
            this.TBKetKiri.Text = "";
            // 
            // TBNamaKiri
            // 
            this.TBNamaKiri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TBNamaKiri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBNamaKiri.Enabled = false;
            this.TBNamaKiri.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNamaKiri.Location = new System.Drawing.Point(333, 279);
            this.TBNamaKiri.Name = "TBNamaKiri";
            this.TBNamaKiri.ReadOnly = true;
            this.TBNamaKiri.Size = new System.Drawing.Size(283, 24);
            this.TBNamaKiri.TabIndex = 5;
            // 
            // LabelResult
            // 
            this.LabelResult.AutoSize = true;
            this.LabelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelResult.Location = new System.Drawing.Point(952, 377);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(0, 24);
            this.LabelResult.TabIndex = 4;
            // 
            // LabelCoba
            // 
            this.LabelCoba.AutoSize = true;
            this.LabelCoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCoba.Location = new System.Drawing.Point(100, 377);
            this.LabelCoba.Name = "LabelCoba";
            this.LabelCoba.Size = new System.Drawing.Size(60, 24);
            this.LabelCoba.TabIndex = 3;
            this.LabelCoba.Text = "label1";
            // 
            // PBOpsiKiri
            // 
            this.PBOpsiKiri.Location = new System.Drawing.Point(372, 87);
            this.PBOpsiKiri.Name = "PBOpsiKiri";
            this.PBOpsiKiri.Size = new System.Drawing.Size(200, 200);
            this.PBOpsiKiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOpsiKiri.TabIndex = 2;
            this.PBOpsiKiri.TabStop = false;
            this.PBOpsiKiri.Click += new System.EventHandler(this.PBOpsiKiri_Click);
            // 
            // PBOpsiKanan
            // 
            this.PBOpsiKanan.Location = new System.Drawing.Point(1351, 635);
            this.PBOpsiKanan.Name = "PBOpsiKanan";
            this.PBOpsiKanan.Size = new System.Drawing.Size(191, 182);
            this.PBOpsiKanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOpsiKanan.TabIndex = 1;
            this.PBOpsiKanan.TabStop = false;
            this.PBOpsiKanan.Click += new System.EventHandler(this.PBOpsiKanan_Click);
            // 
            // TimerTombol
            // 
            this.TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            // 
            // TBQuest
            // 
            this.TBQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(121)))));
            this.TBQuest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBQuest.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBQuest.Location = new System.Drawing.Point(700, 73);
            this.TBQuest.Name = "TBQuest";
            this.TBQuest.Size = new System.Drawing.Size(504, 106);
            this.TBQuest.TabIndex = 8;
            this.TBQuest.Text = "";
            // 
            // LBTotalSoal
            // 
            this.LBTotalSoal.AutoSize = true;
            this.LBTotalSoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotalSoal.Location = new System.Drawing.Point(114, 31);
            this.LBTotalSoal.Name = "LBTotalSoal";
            this.LBTotalSoal.Size = new System.Drawing.Size(33, 24);
            this.LBTotalSoal.TabIndex = 6;
            this.LBTotalSoal.Text = "/ 0";
            // 
            // LBTotalPoin
            // 
            this.LBTotalPoin.AutoSize = true;
            this.LBTotalPoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotalPoin.Location = new System.Drawing.Point(1802, 31);
            this.LBTotalPoin.Name = "LBTotalPoin";
            this.LBTotalPoin.Size = new System.Drawing.Size(33, 24);
            this.LBTotalPoin.TabIndex = 9;
            this.LBTotalPoin.Text = "/ 0";
            // 
            // LBPoinKe
            // 
            this.LBPoinKe.AutoSize = true;
            this.LBPoinKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPoinKe.Location = new System.Drawing.Point(1773, 31);
            this.LBPoinKe.Name = "LBPoinKe";
            this.LBPoinKe.Size = new System.Drawing.Size(21, 24);
            this.LBPoinKe.TabIndex = 10;
            this.LBPoinKe.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1703, 12);
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
            this.LBSoalKe.Location = new System.Drawing.Point(85, 31);
            this.LBSoalKe.Name = "LBSoalKe";
            this.LBSoalKe.Size = new System.Drawing.Size(21, 24);
            this.LBSoalKe.TabIndex = 6;
            this.LBSoalKe.Text = "0";
            // 
            // UCGameOpsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBTotalPoin);
            this.Controls.Add(this.LBPoinKe);
            this.Controls.Add(this.TBQuest);
            this.Controls.Add(this.LBTotalSoal);
            this.Controls.Add(this.LBSoalKe);
            this.Controls.Add(this.PanelOpsi);
            this.Name = "UCGameOpsi";
            this.Size = new System.Drawing.Size(1904, 1041);
            this.Load += new System.EventHandler(this.UCGameOpsi_Load);
            this.PanelOpsi.ResumeLayout(false);
            this.PanelOpsi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKiri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOpsiKanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelOpsi;
        private System.Windows.Forms.PictureBox PBOpsiKanan;
        private System.Windows.Forms.PictureBox PBOpsiKiri;
        private System.Windows.Forms.Label LabelCoba;
        private System.Windows.Forms.Timer TimerTombol;
        private System.Windows.Forms.Label LabelResult;
        private System.Windows.Forms.RichTextBox TBKetKanan;
        private System.Windows.Forms.TextBox TBNamaKanan;
        private System.Windows.Forms.RichTextBox TBKetKiri;
        private System.Windows.Forms.TextBox TBNamaKiri;
        private System.Windows.Forms.RichTextBox TBQuest;
        private System.Windows.Forms.Label LBTotalSoal;
        private System.Windows.Forms.Label LBTotalPoin;
        private System.Windows.Forms.Label LBPoinKe;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBSoalKe;
    }
}
