namespace GazethruApps
{
    partial class FormPlayVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayVideo));
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblJudul = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(12, 83);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(1645, 946);
            this.MediaPlayer.TabIndex = 0;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(1725, 523);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(112, 65);
            this.BtnBack.TabIndex = 1;
            this.BtnBack.Text = "Kembali";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // LblJudul
            // 
            this.LblJudul.AutoSize = true;
            this.LblJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJudul.Location = new System.Drawing.Point(41, 39);
            this.LblJudul.Name = "LblJudul";
            this.LblJudul.Size = new System.Drawing.Size(122, 24);
            this.LblJudul.TabIndex = 2;
            this.LblJudul.Text = "Judul Video";
            // 
            // FormPlayVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.LblJudul);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.MediaPlayer);
            this.Name = "FormPlayVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPlayVideo";
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label LblJudul;
    }
}