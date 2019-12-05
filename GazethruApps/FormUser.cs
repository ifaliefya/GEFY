﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class formUser : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendaliuser;
        
        public formUser()
        {
            InitializeComponent();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);

            wx[0] = 375; //lokasi awal btnInformasi 375; 400
            wy[0] = 400;
            wx[1] = 1420; //lokasi awal btnPeta 1420; 400
            wy[1] = 400;
            wx[2] = 884; //lokasi awal btnBack 884; 940
            wy[2] = 940;

            kendaliuser = new KendaliTombol();
            kendaliuser.TambahTombol(btnInfo, new FungsiTombol(InfoTekan));
            kendaliuser.TambahTombol(btnPeta, new FungsiTombol(PetaTekan));
            kendaliuser.TambahTombol(btnBack, new FungsiTombol(BackTekan));

            kendaliuser.Start();
        }

        private static formUser Instance;
        public static formUser getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formUser();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnInfo.Location = new Point((int)wx[0], (int)wy[0]);
            btnPeta.Location = new Point((int)wx[1], (int)wy[1]);
            btnBack.Location = new Point((int)wx[2], (int)wy[2]);

            progressBarInform.Location = new Point((int)wx[0], (int)wy[0]);
            progressBarPeta.Location = new Point((int)wx[1], (int)wy[1]);
            progressBarBack.Location = new Point((int)wx[2], (int)wy[2]);

            if (lap == 0)
            {
                wx[0]--;
                wx[1]++;
                wy[2]--;
            }
            if (lap == 1)
            {
                wx[0]++;
                wx[1]--;
                wy[2]++;
            }
            if (wx[0] == 75)
            {
                lap = 1;
            }
            if (wx[0] == 375)
            {
                lap = 0;
            }

            kendaliuser.CekTombol();
        }

       private void btnBack_Click(object sender, EventArgs e)
        {
            formAwal FormHome = formAwal.getInstance();
            FormHome.Show();
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            formInformasi FormInformasi = new formInformasi();
            FormInformasi.Show();
            this.Close();
        }

        private void btnPeta_Click(object sender, EventArgs e)
        {
            formPeta FormPeta = new formPeta();
            FormPeta.Show();
            this.Close();
        }

        private void InfoTekan(ArgumenKendaliTombol e)
        {
            PresenceCheck.Visible = false;
            if (e.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            
            if (e.status)
            {
                formInformasi FormInformasi = formInformasi.getInstance();
                FormInformasi.Show();
                timer1.Stop();
                this.Close();
            }

            progressBarInform.Value = e.DataKor;
        }
        private void PetaTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                formPeta FormPeta = formPeta.getInstance();
                FormPeta.Show();
                timer1.Stop();
                this.Close();
            }

            progressBarPeta.Value = e.DataKor;
        }
        private void BackTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                formAwal FormHome = formAwal.getInstance();
                FormHome.Show();
                timer1.Stop();
                this.Close();
            }

            progressBarBack.Value = e.DataKor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
