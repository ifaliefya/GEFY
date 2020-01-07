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
        //variabel untuk menyimpan koordinat posisi tombol yang ada pada form ini
        List<double> wx;
        List<double> wy;
        int lap = 0;

        //deklarasi  kelas KendaliTombol untuk seleksi objek menggunakan eyetracking
        KendaliTombol kendali;

        //deklarasi  kelas Soundplayer untuk memberikan efek suara
        private SoundPlayer SelectSound = new SoundPlayer();

        public FormHome()
        {
            InitializeComponent();
            //Menambahkan timer untuk menggerakkan tombol
            TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            TimerTombol.Start();

            kendali = new KendaliTombol();

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);

            //lokasi awal tiap tombol
            wx[0] = 1592; 
            wy[0] = 800;
            wx[1] = 218;
            wy[1] = 427;

            //penambahan eventhandler tiap tombol untuk seleksi objek menggunakan eyetracking
            kendali.TambahTombol(BtnMisi, new FungsiTombol(TombolMisiTekan));
            kendali.TambahTombol(BtnTahu, new FungsiTombol(TombolTahukahKamu));

            //mulai jalankan kelas KendaliTombol
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

        //methode load dipanggil ketika form di load setelah dibuka
        private void FormHome_Load(object sender, EventArgs e)
        {
            TimerTombol.Interval = 1;
            TimerTombol.Tick += new System.EventHandler(this.TimerTombol_Tick);
            TimerTombol.Start();
        }

        //eventhandler timer untuk menggerakkan tombol, serta menjalankan method CekTombol di kelas kendali
        private void TimerTombol_Tick(object sender, EventArgs e)
        {
            BtnTahu.Location = new Point((int)wx[1], (int)wy[1]);
            progressBar2.Location = new Point((int)wx[1], (int)wy[1]);
            BtnMisi.Location = new Point((int)wx[0], (int)wy[0]);
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

            if (wy[0] == 427)
            {
                lap = 1; //titik akhir
            }

            if (wy[0] == 800)
            {
                lap = 0;
            }

            kendali.CekTombol();
        }

        //eventhandler tombol Misi menggunakan interaksi eyetracking
        private void TombolMisiTekan(ArgumenKendaliTombol eawal)
        {

            
            PresenceCheck.Visible = false;
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            if (eawal.status)
            {
                FormTutorial FormGame = FormTutorial.getInstance();
                FormGame.Show();
                this.Hide();
                TimerTombol.Stop();
                TimerTombol.Tick -= TimerTombol_Tick;
            }

            BtnMisi.BackColor = Color.FromArgb(eawal.DataKor, 0, 150, 185);     //untuk opacity
            progressBar1.Value = eawal.DataKor;                                //untuk progressbar
        }

        //eventhandler tombol Tahukah kamu menggunakan interaksi eyetracking
        private void TombolTahukahKamu(ArgumenKendaliTombol eawal)
        {
            if (eawal.CekMata)
            {
                PresenceCheck.Visible = true;
            }
            if (eawal.status)
            {
                FormTutorial FormGame = FormTutorial.getInstance();
                FormGame.Show();
                this.Hide();
                TimerTombol.Stop();
                TimerTombol.Tick -= TimerTombol_Tick;
            }

            BtnTahu.BackColor = Color.FromArgb(eawal.DataKor, 0, 150, 185);
            progressBar2.Value = eawal.DataKor;
        }

        //eventhandler tombol Tahukah kamu menggunakan interaksi klik
        private void BtnTahu_Click(object sender, EventArgs e)
        {
            SFXSeleksi();
            FormVideo FormVideo = new FormVideo();
            FormVideo.Show();
            this.Hide();
        }

        //eventhandler tombol Misi menggunakan interaksi klik
        private void BtnMisi_Click(object sender, EventArgs e)
        {
            SFXSeleksi();
            FormTutorial FormGame = new FormTutorial();
            FormGame.Show();
            this.Hide();
        }

        //eventhandler tombol Login Admin menggunakan interaksi klik
        private void buttonAdmin2_Click(object sender, EventArgs e)
        {
            AdminLogin LoginAdmin = new AdminLogin();
            LoginAdmin.Show();
            this.Hide();
        }

        //method untuk memberikan efek suara ketika tombol terpilih 
        private void SFXSeleksi()
        {
            this.SelectSound.SoundLocation = @"TombolTerpilih.wav";
            this.SelectSound.Play();
        }

        //eventhandler tombol minimize
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //eventhandler tombol close
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
