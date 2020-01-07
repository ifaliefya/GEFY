namespace GazethruApps
{
    partial class FormVideo
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
            this.PanelTengah = new System.Windows.Forms.Panel();
            this.TbxJudulTengah = new System.Windows.Forms.RichTextBox();
            this.TbxDescTengah = new System.Windows.Forms.RichTextBox();
            this.PbxTengah = new System.Windows.Forms.PictureBox();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.PanelKiri = new System.Windows.Forms.Panel();
            this.TbxJudulKiri = new System.Windows.Forms.RichTextBox();
            this.PbxKiri = new System.Windows.Forms.PictureBox();
            this.PanelKanan = new System.Windows.Forms.Panel();
            this.TbxJudulKanan = new System.Windows.Forms.RichTextBox();
            this.PbxKanan = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnBack = new System.Windows.Forms.Button();
            this.PanelTengah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxTengah)).BeginInit();
            this.PanelKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxKiri)).BeginInit();
            this.PanelKanan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxKanan)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTengah
            // 
            this.PanelTengah.BackColor = System.Drawing.Color.Gold;
            this.PanelTengah.Controls.Add(this.TbxJudulTengah);
            this.PanelTengah.Controls.Add(this.TbxDescTengah);
            this.PanelTengah.Controls.Add(this.PbxTengah);
            this.PanelTengah.Location = new System.Drawing.Point(631, 219);
            this.PanelTengah.Name = "PanelTengah";
            this.PanelTengah.Size = new System.Drawing.Size(680, 706);
            this.PanelTengah.TabIndex = 0;
            // 
            // TbxJudulTengah
            // 
            this.TbxJudulTengah.BackColor = System.Drawing.Color.White;
            this.TbxJudulTengah.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxJudulTengah.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxJudulTengah.Location = new System.Drawing.Point(78, 351);
            this.TbxJudulTengah.Name = "TbxJudulTengah";
            this.TbxJudulTengah.ReadOnly = true;
            this.TbxJudulTengah.Size = new System.Drawing.Size(522, 54);
            this.TbxJudulTengah.TabIndex = 3;
            this.TbxJudulTengah.Text = "";
            // 
            // TbxDescTengah
            // 
            this.TbxDescTengah.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxDescTengah.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxDescTengah.Location = new System.Drawing.Point(78, 423);
            this.TbxDescTengah.Name = "TbxDescTengah";
            this.TbxDescTengah.ReadOnly = true;
            this.TbxDescTengah.Size = new System.Drawing.Size(522, 169);
            this.TbxDescTengah.TabIndex = 2;
            this.TbxDescTengah.Text = "";
            // 
            // PbxTengah
            // 
            this.PbxTengah.Location = new System.Drawing.Point(57, 41);
            this.PbxTengah.Name = "PbxTengah";
            this.PbxTengah.Size = new System.Drawing.Size(563, 295);
            this.PbxTengah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxTengah.TabIndex = 0;
            this.PbxTengah.TabStop = false;
            // 
            // BtnPlay
            // 
            this.BtnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlay.Location = new System.Drawing.Point(688, 931);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(117, 34);
            this.BtnPlay.TabIndex = 4;
            this.BtnPlay.Text = "PLAY";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(121)))));
            this.BtnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrev.Location = new System.Drawing.Point(171, 556);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(75, 47);
            this.BtnPrev.TabIndex = 1;
            this.BtnPrev.Text = "<<";
            this.BtnPrev.UseVisualStyleBackColor = false;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(121)))));
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(1690, 556);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 47);
            this.BtnNext.TabIndex = 2;
            this.BtnNext.Text = ">>";
            this.BtnNext.UseVisualStyleBackColor = false;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // PanelKiri
            // 
            this.PanelKiri.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelKiri.Controls.Add(this.TbxJudulKiri);
            this.PanelKiri.Controls.Add(this.PbxKiri);
            this.PanelKiri.Location = new System.Drawing.Point(311, 432);
            this.PanelKiri.Name = "PanelKiri";
            this.PanelKiri.Size = new System.Drawing.Size(412, 382);
            this.PanelKiri.TabIndex = 4;
            // 
            // TbxJudulKiri
            // 
            this.TbxJudulKiri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TbxJudulKiri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxJudulKiri.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxJudulKiri.Location = new System.Drawing.Point(32, 276);
            this.TbxJudulKiri.Name = "TbxJudulKiri";
            this.TbxJudulKiri.ReadOnly = true;
            this.TbxJudulKiri.Size = new System.Drawing.Size(347, 75);
            this.TbxJudulKiri.TabIndex = 3;
            this.TbxJudulKiri.Text = "";
            // 
            // PbxKiri
            // 
            this.PbxKiri.Location = new System.Drawing.Point(32, 29);
            this.PbxKiri.Name = "PbxKiri";
            this.PbxKiri.Size = new System.Drawing.Size(347, 228);
            this.PbxKiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxKiri.TabIndex = 0;
            this.PbxKiri.TabStop = false;
            // 
            // PanelKanan
            // 
            this.PanelKanan.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelKanan.Controls.Add(this.TbxJudulKanan);
            this.PanelKanan.Controls.Add(this.PbxKanan);
            this.PanelKanan.Location = new System.Drawing.Point(1243, 432);
            this.PanelKanan.Name = "PanelKanan";
            this.PanelKanan.Size = new System.Drawing.Size(412, 382);
            this.PanelKanan.TabIndex = 4;
            // 
            // TbxJudulKanan
            // 
            this.TbxJudulKanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TbxJudulKanan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbxJudulKanan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxJudulKanan.Location = new System.Drawing.Point(32, 276);
            this.TbxJudulKanan.Name = "TbxJudulKanan";
            this.TbxJudulKanan.ReadOnly = true;
            this.TbxJudulKanan.Size = new System.Drawing.Size(347, 75);
            this.TbxJudulKanan.TabIndex = 3;
            this.TbxJudulKanan.Text = "";
            // 
            // PbxKanan
            // 
            this.PbxKanan.Location = new System.Drawing.Point(32, 29);
            this.PbxKanan.Name = "PbxKanan";
            this.PbxKanan.Size = new System.Drawing.Size(347, 228);
            this.PbxKanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxKanan.TabIndex = 0;
            this.PbxKanan.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 14;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(1134, 962);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(117, 34);
            this.BtnBack.TabIndex = 5;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // FormVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.PanelTengah);
            this.Controls.Add(this.PanelKanan);
            this.Controls.Add(this.PanelKiri);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVideo";
            this.Load += new System.EventHandler(this.FormVideo_Load);
            this.PanelTengah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxTengah)).EndInit();
            this.PanelKiri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxKiri)).EndInit();
            this.PanelKanan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbxKanan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTengah;
        private System.Windows.Forms.RichTextBox TbxDescTengah;
        private System.Windows.Forms.PictureBox PbxTengah;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.RichTextBox TbxJudulTengah;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Panel PanelKiri;
        private System.Windows.Forms.RichTextBox TbxJudulKiri;
        private System.Windows.Forms.PictureBox PbxKiri;
        private System.Windows.Forms.Panel PanelKanan;
        private System.Windows.Forms.RichTextBox TbxJudulKanan;
        private System.Windows.Forms.PictureBox PbxKanan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnBack;
    }
}