namespace GazethruApps
{
    partial class AdminVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminVideo));
            this.label3 = new System.Windows.Forms.Label();
            this.PanelPreview = new System.Windows.Forms.Panel();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnPilihVideo = new System.Windows.Forms.Button();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelThumbnail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnPilihGambar = new System.Windows.Forms.Button();
            this.PbxThumbnail = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxKet = new System.Windows.Forms.RichTextBox();
            this.BtnSimpan = new System.Windows.Forms.Button();
            this.TbxJudul = new System.Windows.Forms.TextBox();
            this.DGVVideo = new System.Windows.Forms.DataGridView();
            this.LabelCari = new System.Windows.Forms.Label();
            this.TextBoxCari = new System.Windows.Forms.TextBox();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LabelTotal = new System.Windows.Forms.Label();
            this.TbxTotal = new System.Windows.Forms.TextBox();
            this.PanelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(405, 45);
            this.label3.TabIndex = 28;
            this.label3.Text = "Pengaturan Konten Video";
            // 
            // PanelPreview
            // 
            this.PanelPreview.Controls.Add(this.BtnStop);
            this.PanelPreview.Controls.Add(this.BtnPause);
            this.PanelPreview.Controls.Add(this.BtnStart);
            this.PanelPreview.Controls.Add(this.BtnPilihVideo);
            this.PanelPreview.Controls.Add(this.MediaPlayer);
            this.PanelPreview.Controls.Add(this.labelThumbnail);
            this.PanelPreview.Controls.Add(this.label4);
            this.PanelPreview.Controls.Add(this.TbxPath);
            this.PanelPreview.Controls.Add(this.label2);
            this.PanelPreview.Controls.Add(this.BtnPilihGambar);
            this.PanelPreview.Controls.Add(this.PbxThumbnail);
            this.PanelPreview.Controls.Add(this.label1);
            this.PanelPreview.Controls.Add(this.TbxKet);
            this.PanelPreview.Controls.Add(this.BtnSimpan);
            this.PanelPreview.Controls.Add(this.TbxJudul);
            this.PanelPreview.Location = new System.Drawing.Point(533, 168);
            this.PanelPreview.Name = "PanelPreview";
            this.PanelPreview.Size = new System.Drawing.Size(1036, 811);
            this.PanelPreview.TabIndex = 37;
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStop.Location = new System.Drawing.Point(882, 513);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(126, 36);
            this.BtnStop.TabIndex = 66;
            this.BtnStop.Text = "STOP";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPause.Location = new System.Drawing.Point(882, 459);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(126, 36);
            this.BtnPause.TabIndex = 65;
            this.BtnPause.Text = "PAUSE";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(882, 404);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(126, 36);
            this.BtnStart.TabIndex = 64;
            this.BtnStart.Text = "START";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnPilihVideo
            // 
            this.BtnPilihVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPilihVideo.Location = new System.Drawing.Point(630, 333);
            this.BtnPilihVideo.Name = "BtnPilihVideo";
            this.BtnPilihVideo.Size = new System.Drawing.Size(203, 26);
            this.BtnPilihVideo.TabIndex = 63;
            this.BtnPilihVideo.Text = "PILIH FILE ";
            this.BtnPilihVideo.UseVisualStyleBackColor = true;
            this.BtnPilihVideo.Click += new System.EventHandler(this.BtnPilihVideo_Click);
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(33, 380);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(843, 418);
            this.MediaPlayer.TabIndex = 62;
            this.MediaPlayer.Enter += new System.EventHandler(this.MediaPlayer_Enter);
            // 
            // labelThumbnail
            // 
            this.labelThumbnail.AutoSize = true;
            this.labelThumbnail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThumbnail.Location = new System.Drawing.Point(33, 36);
            this.labelThumbnail.Name = "labelThumbnail";
            this.labelThumbnail.Size = new System.Drawing.Size(125, 16);
            this.labelThumbnail.TabIndex = 61;
            this.labelThumbnail.Text = "Thumbnail Video";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Folder Video :";
            // 
            // TbxPath
            // 
            this.TbxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxPath.Location = new System.Drawing.Point(33, 333);
            this.TbxPath.Margin = new System.Windows.Forms.Padding(2);
            this.TbxPath.Name = "TbxPath";
            this.TbxPath.Size = new System.Drawing.Size(601, 26);
            this.TbxPath.TabIndex = 59;
            this.TbxPath.Click += new System.EventHandler(this.TbxPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "Judul Video";
            // 
            // BtnPilihGambar
            // 
            this.BtnPilihGambar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPilihGambar.Location = new System.Drawing.Point(36, 256);
            this.BtnPilihGambar.Name = "BtnPilihGambar";
            this.BtnPilihGambar.Size = new System.Drawing.Size(228, 36);
            this.BtnPilihGambar.TabIndex = 57;
            this.BtnPilihGambar.Text = "PILIH GAMBAR";
            this.BtnPilihGambar.UseVisualStyleBackColor = true;
            this.BtnPilihGambar.Click += new System.EventHandler(this.BtnPilihGambar_Click);
            // 
            // PbxThumbnail
            // 
            this.PbxThumbnail.BackColor = System.Drawing.SystemColors.Control;
            this.PbxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxThumbnail.Location = new System.Drawing.Point(36, 64);
            this.PbxThumbnail.Margin = new System.Windows.Forms.Padding(2);
            this.PbxThumbnail.Name = "PbxThumbnail";
            this.PbxThumbnail.Size = new System.Drawing.Size(391, 228);
            this.PbxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxThumbnail.TabIndex = 56;
            this.PbxThumbnail.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Keterangan Video :";
            // 
            // TbxKet
            // 
            this.TbxKet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxKet.Location = new System.Drawing.Point(444, 164);
            this.TbxKet.Name = "TbxKet";
            this.TbxKet.Size = new System.Drawing.Size(549, 128);
            this.TbxKet.TabIndex = 54;
            this.TbxKet.Text = "";
            // 
            // BtnSimpan
            // 
            this.BtnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSimpan.Location = new System.Drawing.Point(755, 14);
            this.BtnSimpan.Name = "BtnSimpan";
            this.BtnSimpan.Size = new System.Drawing.Size(248, 38);
            this.BtnSimpan.TabIndex = 43;
            this.BtnSimpan.Text = "SIMPAN PERUBAHAN";
            this.BtnSimpan.UseVisualStyleBackColor = true;
            this.BtnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            // 
            // TbxJudul
            // 
            this.TbxJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxJudul.Location = new System.Drawing.Point(444, 105);
            this.TbxJudul.Margin = new System.Windows.Forms.Padding(2);
            this.TbxJudul.Name = "TbxJudul";
            this.TbxJudul.Size = new System.Drawing.Size(562, 26);
            this.TbxJudul.TabIndex = 52;
            // 
            // DGVVideo
            // 
            this.DGVVideo.AllowUserToAddRows = false;
            this.DGVVideo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVVideo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVVideo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVideo.Location = new System.Drawing.Point(54, 168);
            this.DGVVideo.Margin = new System.Windows.Forms.Padding(2);
            this.DGVVideo.Name = "DGVVideo";
            this.DGVVideo.RowTemplate.Height = 24;
            this.DGVVideo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVVideo.Size = new System.Drawing.Size(417, 737);
            this.DGVVideo.TabIndex = 38;
            this.DGVVideo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVVideo_CellClick);
            // 
            // LabelCari
            // 
            this.LabelCari.AutoSize = true;
            this.LabelCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCari.Location = new System.Drawing.Point(60, 134);
            this.LabelCari.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelCari.Name = "LabelCari";
            this.LabelCari.Size = new System.Drawing.Size(43, 18);
            this.LabelCari.TabIndex = 40;
            this.LabelCari.Text = "Cari :";
            // 
            // TextBoxCari
            // 
            this.TextBoxCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCari.Location = new System.Drawing.Point(104, 131);
            this.TextBoxCari.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxCari.Name = "TextBoxCari";
            this.TextBoxCari.Size = new System.Drawing.Size(135, 24);
            this.TextBoxCari.TabIndex = 39;
            this.TextBoxCari.TextChanged += new System.EventHandler(this.TextBoxCari_TextChanged);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnRefresh.FlatAppearance.BorderSize = 0;
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Location = new System.Drawing.Point(301, 125);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(82, 34);
            this.BtnRefresh.TabIndex = 42;
            this.BtnRefresh.Text = "REFRESH";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(185)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(388, 125);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(82, 34);
            this.BtnAdd.TabIndex = 41;
            this.BtnAdd.Text = "BARU";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LabelTotal
            // 
            this.LabelTotal.AutoSize = true;
            this.LabelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotal.Location = new System.Drawing.Point(529, 135);
            this.LabelTotal.Name = "LabelTotal";
            this.LabelTotal.Size = new System.Drawing.Size(150, 24);
            this.LabelTotal.TabIndex = 51;
            this.LabelTotal.Text = "Jumlah Video :";
            // 
            // TbxTotal
            // 
            this.TbxTotal.BackColor = System.Drawing.SystemColors.Menu;
            this.TbxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxTotal.Location = new System.Drawing.Point(685, 134);
            this.TbxTotal.Name = "TbxTotal";
            this.TbxTotal.Size = new System.Drawing.Size(60, 26);
            this.TbxTotal.TabIndex = 50;
            // 
            // AdminVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TbxTotal);
            this.Controls.Add(this.LabelTotal);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LabelCari);
            this.Controls.Add(this.TextBoxCari);
            this.Controls.Add(this.DGVVideo);
            this.Controls.Add(this.PanelPreview);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminVideo";
            this.Size = new System.Drawing.Size(1630, 1004);
            this.Load += new System.EventHandler(this.AdminVideo_Load);
            this.PanelPreview.ResumeLayout(false);
            this.PanelPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PanelPreview;
        private System.Windows.Forms.DataGridView DGVVideo;
        private System.Windows.Forms.Label LabelCari;
        private System.Windows.Forms.TextBox TextBoxCari;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnSimpan;
        private System.Windows.Forms.Label LabelTotal;
        private System.Windows.Forms.TextBox TbxTotal;
        private System.Windows.Forms.TextBox TbxJudul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnPilihGambar;
        private System.Windows.Forms.PictureBox PbxThumbnail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TbxKet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbxPath;
        private System.Windows.Forms.Label labelThumbnail;
        private System.Windows.Forms.Button BtnPilihVideo;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
    }
}
