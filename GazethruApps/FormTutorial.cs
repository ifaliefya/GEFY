using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;


namespace GazethruApps
{
    public partial class FormTutorial : Form
    {
        public static FormTutorial Instance;
        private SoundPlayer SoundPilih = new SoundPlayer();
        private SoundPlayer BGM = new SoundPlayer();
        private SoundPlayer SoundKembali = new SoundPlayer();

        public static FormTutorial getInstance()
        {
            if (Instance == null)
            {
                Instance = new FormTutorial();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        //deklarasi list GameSequence untuk menyimpan Id dari tabel Games
        List<int> GameSequence = new List<int>();
        //deklarasi variabel Max
        int Max;
        //deklarasi list randomRecords untuk menyimpan hasil pengacakan list GameSequence
        List<int> randomRecords = new List<int>();

        //deklarasi koneksi database sql yang sudah diatur di Properties
        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        //variabel untuk kendali tombol menggunakan interaksi eyetracking
        KendaliTombol kendali;
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public FormTutorial()
        {
            InitializeComponent();
            //inisialisasi variabel interaksi eyetracking
            kendali = new KendaliTombol();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx[0] = 744;
            wy[0] = 807;
            wx[1] = 1704;
            wy[1] = 222;

            //deklarasi eventhandler untuk interaksi eyetracking pada tombol start dan kembali
            kendali.TambahTombol(BtnStart, new FungsiTombol(TombolStartTekan));
            kendali.TambahTombol(BtnBack, new FungsiTombol(TombolBackTekan));
            kendali.Start();
        }
        
        //method untuk mengacak urutan soal games
        public void SetRandomSequence()
        {
            //kosongkan isi tabel Sequence sebelum diisi lagi 
            con.Open();
            string sqlTrunc = "TRUNCATE TABLE Sequence";
            SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            //membaca data Id dari tabel Game untuk disimpan ke List GameSequence
            string SelectQuery = "SELECT No FROM Game";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    GameSequence.Add((int)read.GetValue(0));
                }
                //Max = jumlah data dari tabel Game
                Max = GameSequence.Count;
            }
            con.Close();

            //perulangan untuk mengacak urutan Id Tabel Game yang sudah disimpan di list GameSequence dan disimpan dalam tabel Sequence
            for (int i = 0; i < Max; i++)
            {
                var randomGenerator = new Random();
                while (true)
                {
                    //mengambil angka acak dari 0 sampai Max(jumlah data) disimpan dalam variabel randomIndex
                    var randomIndex = randomGenerator.Next(0, Max);
                    //mengambil nilai list GameSequence dengan indeks randomIndex
                    var GameSeq = GameSequence[randomIndex];
                    //Jika list randomrecords belum memiliki nilai GameSeq maka tambahkan nilai GameSeq ke tabel Sequence
                    if (!randomRecords.Contains(GameSeq))
                    {
                        randomRecords.Add(GameSeq);
                        string InsertQuery = "INSERT INTO Sequence(GameSeq) VALUES (@gameseq);";
                        SqlCommand insert = new SqlCommand(InsertQuery, con);
                        insert.Parameters.Add("@gameseq", SqlDbType.Int).Value = GameSeq;
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();

                        break;

                    }
                }
            }

        }

        //eventhandler untuk tombol Mulai akan menjalankan method untuk mengacak id serta membuka form Game
        private void BtnStart_Click(object sender, EventArgs e)
        {
            SFXSeleksi();

            SetRandomSequence();
            FormStartGame Start = new FormStartGame();
            Start.Show();
        }

        //eventhandler tombol Kembali menggunakan klik akan menutup form ini dan membuka kembali halaman formHome
        private void BtnBack_Click(object sender, EventArgs e)
        {
            SFXBack();

            FormHome frmawal = new FormHome();
            frmawal.Show();
            this.Close();
        }

        //timer berjalan untuk menggerakkan tombol yang ada pada halaman form
        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnStart.Location = new Point((int)wx[0], (int)wy[0]);
            BtnBack.Location = new Point((int)wx[1], (int)wy[1]);
            if(lap==0)
            {
                wx[0]++;
                wy[1]++;
            }
            if(lap==1)
            {
                wx[0]--;
                wy[1]--;
            }
            if(wx[0]==1144)
                lap = 1;
            if(wx[0]==744)
                lap = 0;

            kendali.CekTombol();
        }

        //Saat FormTutorial dibuka akan memulai timer untuk menggerakkan tombol 
        private void FormTutorial_Load(object sender, EventArgs e)
        {
            //PlayBGMLoop(); //Play bgm

            timer1.Enabled = true;
            timer1.Interval = 14;
            timer1.Start();
        }

        /////////////// Eventhandler Kendali mata /////////
        private void TombolStartTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                SFXSeleksi();

                SetRandomSequence();
                FormStartGame Start = new FormStartGame();
                Start.Show();
                this.Close();
            }
        }
        private void TombolBackTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                SFXBack();

                FormHome frmawal = new FormHome();
                frmawal.Show();
                this.Close();
            }
        }
        ////////////////// End Event kendali ////////////

        //private void PlayBGMLoop()     // Play Background music
        //{
        //    try
        //    {
        //        this.BGM.SoundLocation = @"BG Song Gefy.wav";
        //        this.BGM.PlayLooping();
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        private void SFXSeleksi()
        {
            this.SoundPilih.SoundLocation = @"TombolTerpilih.wav";
            this.SoundPilih.Play();
        }
        private void SFXBack()
        {
            this.SoundKembali.SoundLocation = @"TombolKembali.wav";
            this.SoundKembali.Play();
        }
    }
}
