namespace GazethruApps
{
    partial class UCTimer
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
            this.TBCoba = new System.Windows.Forms.TextBox();
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.LblCountdown = new System.Windows.Forms.Label();
            this.LabelSoal = new System.Windows.Forms.Label();
            this.LblSoalKe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBCoba
            // 
            this.TBCoba.Location = new System.Drawing.Point(733, 552);
            this.TBCoba.Name = "TBCoba";
            this.TBCoba.Size = new System.Drawing.Size(100, 20);
            this.TBCoba.TabIndex = 1;
            // 
            // CountdownTimer
            // 
            this.CountdownTimer.Interval = 1000;
            this.CountdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick);
            // 
            // LblCountdown
            // 
            this.LblCountdown.AutoSize = true;
            this.LblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCountdown.Location = new System.Drawing.Point(903, 466);
            this.LblCountdown.Name = "LblCountdown";
            this.LblCountdown.Size = new System.Drawing.Size(20, 24);
            this.LblCountdown.TabIndex = 2;
            this.LblCountdown.Text = "3";
            // 
            // LabelSoal
            // 
            this.LabelSoal.AutoSize = true;
            this.LabelSoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSoal.Location = new System.Drawing.Point(788, 166);
            this.LabelSoal.Name = "LabelSoal";
            this.LabelSoal.Size = new System.Drawing.Size(68, 20);
            this.LabelSoal.TabIndex = 3;
            this.LabelSoal.Text = "Soal Ke ";
            // 
            // LblSoalKe
            // 
            this.LblSoalKe.AutoSize = true;
            this.LblSoalKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoalKe.Location = new System.Drawing.Point(862, 166);
            this.LblSoalKe.Name = "LblSoalKe";
            this.LblSoalKe.Size = new System.Drawing.Size(18, 20);
            this.LblSoalKe.TabIndex = 4;
            this.LblSoalKe.Text = "0";
            // 
            // UCTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblSoalKe);
            this.Controls.Add(this.LabelSoal);
            this.Controls.Add(this.LblCountdown);
            this.Controls.Add(this.TBCoba);
            this.Name = "UCTimer";
            this.Size = new System.Drawing.Size(1904, 929);
            this.Load += new System.EventHandler(this.UCTimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBCoba;
        private System.Windows.Forms.Timer CountdownTimer;
        private System.Windows.Forms.Label LblCountdown;
        private System.Windows.Forms.Label LabelSoal;
        private System.Windows.Forms.Label LblSoalKe;
    }
}
