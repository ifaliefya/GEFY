using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GazethruApps
{
    public partial class FormHome : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendali;

        private SoundPlayer SelectSound = new SoundPlayer();

        public FormHome()
        {
            InitializeComponent();
            TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            TimerTombol.Start();

            kendali = new KendaliTombol();

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);

            wx[0] = 1592; //lokasi awal 900; 830
            wy[0] = 900;
            wx[1] = 218;
            wy[1] = 377;

            kendali.TambahTombol(btnUser, new FungsiTombol(TombolUserTekan));
            kendali.TambahTombol(buttonInfo, new FungsiTombol(TombolTahukahKamu));

            kendali.Start();
        }

        private static FormHome Instance;
        public static FormHome getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new FormHome();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            TimerTombol.Interval = 1;
            TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            TimerTombol.Start();
        }

        private void TimerTombol_Tick(object sender, EventArgs e)
        {
            buttonInfo.Location = new Point((int)wx[1], (int)wy[1]);
            progressBar2.Location = new Point((int)wx[1], (int)wy[1]);
            btnUser.Location = new Point((int)wx[0], (int)wy[0]);
            progressBar1.Location = new Point((int)wx[0], (int)wy[0]);

            if (lap == 0) //titik awal
            {
                wy[0]--;
                wy[1]++;
            }

            if (lap == 1) //titik akhir, balik
            {
                wy[0]++;
                wy[1]--;
            }

            if (wy[0] == 477)
            {
                lap = 1; //titik akhir
            }

            if (wy[0] == 1000)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }

        private void TombolUserTekan(ArgumenKendaliTombol eawal)
        {

            //Console.WriteLine(eawal.korelasiX + "      " + eawal.korelasiY + "        " + eawal.DataKor);
            PresenceCheck.Visible = false;
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            if (eawal.status)
            {
                FormGame FormUser = FormGame.getInstance();
                FormUser.Show();
                this.Hide();
                TimerTombol.Stop();
                TimerTombol.Tick -= TimerTombol_Tick;
            }

            //btnUser.BackColor = Color.FromArgb(eawal.DataKor, 0, 150, 185);     //untuk opacity
            //progressBar1.Value = eawal.DataKor;                                //untuk progressbar
        }

        private void TombolTahukahKamu(ArgumenKendaliTombol eawal)
        {
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            if (eawal.status)
            {
                //FormTutorial FormGame = Tutorial.getInstance();
                //FormGame.Show();
                this.Hide();
                TimerTombol.Stop();
                TimerTombol.Tick -= TimerTombol_Tick;
            }

            //buttonInfo.BackColor = Color.FromArgb(eawal.DataKor, 0, 150, 185);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            SFXSeleksi();
            FormVideo FormVideo = new FormVideo();
            FormVideo.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SFXSeleksi();
            FormTutorial FormGame = new FormTutorial();
            FormGame.Show();
            this.Hide();
        }

        private void buttonAdmin2_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            this.Hide();
        }

        private void SFXSeleksi()
        {
            this.SelectSound.SoundLocation = @"TombolTerpilih.wav";
            this.SelectSound.Play();
        }
    }
}
