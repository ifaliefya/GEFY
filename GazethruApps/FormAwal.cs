using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Media;


namespace GazethruApps
{
    public partial class formAwal : Form
    {
        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendali;

        private SoundPlayer SelectSound = new SoundPlayer();
        public formAwal()
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
            wy[0] = 1000;
            wx[1] = 218;
            wy[1] = 477;
            
            kendali.TambahTombol(btnUser, new FungsiTombol(TombolUserTekan));
            kendali.TambahTombol(buttonInfo, new FungsiTombol(TombolTahukahKamu));
            kendali.Start();
        }

        private static formAwal Instance;
        public static formAwal getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new formAwal();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formAwal_Load(object sender, EventArgs e)
        {
            TimerTombol.Interval = 14;
            TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            TimerTombol.Start();
            TimerTombol.Enabled = true;
        }

        private void TimerTombol_Tick(object sender, EventArgs e)
        {
            buttonInfo.Location = new Point((int)wx[1], (int)wy[1]);
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
                lap = 1; //titik akhir            
            if (wy[0] == 1000)
                lap = 0;
                        
            kendali.CekTombol();
        }

        /////////////  Event Kendali mata ///////
        private void TombolUserTekan(ArgumenKendaliTombol eawal)
        {                        
            PresenceCheck.Visible = false;
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            if (eawal.status)
            {
                SFXSeleksi();

                //FormGame FormUser = FormGame.getInstance();
                FormTutorial FormUser = new FormTutorial();
                FormUser.Show();
                this.Hide();
            }
                        
        }
        private void TombolTahukahKamu(ArgumenKendaliTombol eawal)
        {            
            if (eawal.status)
            {                
                FormVideo FormVideo = new FormVideo();
                FormVideo.Show();
            }
            
        }
        ////////////////  Sampai disini event kendali mata ////////////

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            this.Hide();
        }

        private void buttonAdmin2_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            //AdminAwal test = new AdminAwal();
            //test.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonInfo_Click(object sender, EventArgs e)  //Button Tahukah Kamu
        {
            FormVideo FormVideo = new FormVideo();
            FormVideo.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)     //Button Game
        {
            SFXSeleksi();

            //FormGame FormUser = FormGame.getInstance();
            FormTutorial FormUser = new FormTutorial();
            FormUser.Show();
            this.Hide();
        }
        private void SFXSeleksi()
        {
            this.SelectSound.SoundLocation = @"TombolTerpilih.wav";
            this.SelectSound.Play();
        }
    }           
}
