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
using System.IO;
using System.Media;

namespace GazethruApps
{
    public partial class FormStartGame : Form
    {
        //deklarasi untuk sfx
        private SoundPlayer SoundPilih = new SoundPlayer();
        private SoundPlayer SoundBenar = new SoundPlayer();
        private SoundPlayer SoundSalah = new SoundPlayer();
        private SoundPlayer SoundKembali = new SoundPlayer();
        private SoundPlayer BGM = new SoundPlayer();

        //deklarasi variabel
        private int counter;
        private int Sequence;
        private int GameID;
        int NextUrut;
        string Question;

        //deklarasi struct untuk menyimpan kelompok opsi kiri dan kanan
        public struct Option
        {
            public string NamaOpsi;
            public Byte[] GambarOpsi;
            public string KetOpsi;
            public bool NilaiOpsi;

            public Option(string nama, Byte[] gambar, string ket, bool nilai)
            {
                NamaOpsi = nama;
                GambarOpsi = gambar;
                KetOpsi = ket;
                NilaiOpsi = nilai;
            }
        }

        Option OpsiL;
        Option OpsiR;
        //koneksi sql
        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        //deklarasi variabel kendali tombol
        List<double> wx;
        List<double> wy;
        int lap = 0;

        //kelas kendali tombol dengan interaksi eyetracking
        KendaliTombol kendaliuser;

        public FormStartGame()
        {
            InitializeComponent();
            PlayBGMLoop(); //Play bgm

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);

            wx[0] = 372; //lokasi awal OpsiKiri
            wy[0] = 87;
            wx[1] = 1351; //lokasi awal OpsiKanan
            wy[1] = 635;

            kendaliuser = new KendaliTombol();
            kendaliuser.TambahTombol(PBOpsiKiri, new FungsiTombol(PilihOpsiKiri));
            kendaliuser.TambahTombol(PBOpsiKanan, new FungsiTombol(PilihOpsiKanan));

            kendaliuser.Start();
        }

        //////////////   Event Kendali mata    ////////////////////////////        
        private void PilihOpsiKiri(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                //SFXSeleksi();

                TombolTimer.Stop();
                TombolTimer.Tick -= TombolTimer_Tick;

                OpsiTerpilih(PBOpsiKiri, OpsiL);
            }
        }
        private void PilihOpsiKanan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                //SFXSeleksi();

                TombolTimer.Stop();
                TombolTimer.Tick -= TombolTimer_Tick;

                OpsiTerpilih(PBOpsiKanan, OpsiR);
            }

        }
        //////////////    Sampe sini kendali mata   ////////////////////////////
        
        //method pertama kali form di load
        private void FormStartGame_Load(object sender, EventArgs e)
        {
            //panel yang menampilkan timer muncul, sementara panel yg menampilkan game disembunyikan
            PnlTimer.Visible = true;
            PnlGame.Visible = false;
            //counter untuk timer
            counter = 3;
            LblTimer.Text = counter.ToString(); 
            //memanggil method StartTimer dengan melewatkan nilai 1  (untuk soal pertama)
            StartTimer(1);
        }

        //timer untuk menggerakkan tombol
        private void TombolTimer_Tick(object sender, EventArgs e)
        {
            PBOpsiKiri.Location = new Point((int)wx[0], (int)wy[0]);
            PBOpsiKanan.Location = new Point((int)wx[1], (int)wy[1]);

            //progressBarInform.Location = new Point((int)wx[0], (int)wy[0]);
            //progressBarPeta.Location = new Point((int)wx[1], (int)wy[1]);
            //progressBarBack.Location = new Point((int)wx[2], (int)wy[2]);

            if (lap == 0)
            {
                wy[0]--;
                wy[1]++;
            }
            if (lap == 1)
            {
                wy[0]++;
                wy[1]--;
            }
            if (wy[0] == 75)
            {
                lap = 1;
            }
            if (wy[0] == 475)
            {
                lap = 0;
            }

            kendaliuser.CekTombol();
        }

       //timer hitung mundur sebelum game dimulai
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter== -1)
            {
                CountdownTimer.Stop();
                counter = 3;
                //setelah timer berhenti panggil method StartGame dengan melewatkan variabel GameID serta urutan soal
                StartGame(GameID, Sequence);
                //menyembunyikan Panel Timer
                this.Controls.Remove(this.PnlTimer);
                //meenghapus event handler timer hitung mundur agar dapat di restart nantinya
                CountdownTimer.Tick -= CountdownTimer_Tick;
            }
            LblTimer.Text = counter.ToString();
            if (counter == 0)
            {
                LblTimer.Text = "Mulai";
            }
        }

        //methid untuk memulai timer serta mengambil ID hasil pengacakan urutan yang pertama dari tabel Sequence
       public void StartTimer(int urutan)
        {
            //await Task.Delay(1000);
            this.Controls.Add(this.PnlTimer);
            PnlTimer.Visible = true;
            PnlGame.Visible = false;

            LblNextSoal.Text = urutan.ToString();
            Sequence = urutan;

            con.Open();
            string SelectQuery = "SELECT GameSeq FROM Sequence WHERE Id =" + urutan;
            SqlCommand comm = new SqlCommand(SelectQuery, con);
            SqlDataReader read = comm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    //menyimpan ID tersebut dalam variabel GameId
                    GameID = read.GetInt32(0);
                }
            }
            con.Close();
            
            //memulai kembali timer hitung mundur
            CountdownTimer.Interval = 1000;
            CountdownTimer.Enabled = true;
            CountdownTimer.Tick += new EventHandler(CountdownTimer_Tick);
        }

        //method untuk menampilkan Soal/Quest dengan id yang sudah dibaca dari Tabel Sequence
        public void StartGame(int GameSeq, int urutan)
        {
            //memunculkan Panel Game dan menyembunyikan Panel timer
            PnlGame.Visible = true;
            PnlTimer.Visible = false;

            //menambah urutan menjadi urutan selanjutnya
            NextUrut = urutan + 1;

            //mengambil semua data dari tabel game pada ID = GameSeq
            con.Open();
            string SelectOption = "SELECT * FROM Game WHERE No = ";
            SqlCommand command = new SqlCommand(SelectOption + GameSeq, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    //menyimpan data ke variabel-variabel
                    Question = (String)(read["Quest"]);

                    //data opsi kiri
                    var namaL = (String)(read["NamaL"]);
                    var descL = (String)(read["DescL"]);
                    var nilaiL = (Boolean)(read["NilaiL"]);
                    Byte[] imgL = (Byte[])(read["GambarL"]);
                    OpsiL = new Option(namaL, imgL, descL, nilaiL);

                    //data opsi kanan
                    var namaR = (String)(read["NamaR"]);
                    var descR = (String)(read["DescR"]);
                    var nilaiR = (Boolean)(read["NilaiR"]);
                    Byte[] imgR = (Byte[])(read["GambarR"]);
                    OpsiR = new Option(namaR, imgR, descR, nilaiR);

                    //memuat gambar opsi kiri dankanan
                    LoadPict(imgL, imgR);
                    TBQuest.Text = Question;
                    //untuk cek id saja
                    LabelCoba.Text = GameSeq.ToString();
                }
            }
            con.Close();
            
            //memanggil method ResetGame
            ResetGame();
        }

        public void LoadPict(Byte[] img1, Byte[] img2)
        {
            MemoryStream ms1 = new MemoryStream(img1);
            PBOpsiKiri.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream(img2);
            PBOpsiKanan.Image = Image.FromStream(ms2);
        }

        //mereset tampilan game agar hanya nampak opsinya saja, textbox keterangan2 disembunyikan
        void ResetGame ()
        {
            //mengembalikan gambar opsi ke posisi semula
            PBOpsiKiri.Location = new Point(372,87);
            PBOpsiKanan.Location = new Point(1351, 635);

            //mengembalikan ukuran gambar opsi ke ukuran semula
            PBOpsiKiri.Size = new Size(200, 200);
            PBOpsiKanan.Size = new Size(200, 200);

            //menyembunyikan textbox-textbox
            foreach (Control textbox in PnlGame.Controls)
                if (textbox is TextBox)
                {
                    textbox.Visible = false;
                }
                else if (textbox is RichTextBox)
                {
                    textbox.Visible = false;
                }

            TBQuest.Visible = true;

            //memulai kembali timer untuk menggerakkan tombol
            TombolTimer.Tick += new EventHandler(TombolTimer_Tick);
            TombolTimer.Start();
        }

        //event handler apabila opsi kiri diklik
        private void PBOpsiKiri_Click(object sender, EventArgs e)
        {
            //sfx apabila diklik
            //SFXSeleksi();

            //timer untuk menggerkkan tombol berhenti
            TombolTimer.Stop();
            TombolTimer.Tick -= TombolTimer_Tick;

            //memanggil method OpsiTerpilih dengan melewatkan Opsi Kiri
            OpsiTerpilih(PBOpsiKiri, OpsiL);

        }

        //event handler apabila opsi kiri diklik
        private void PBOpsiKanan_Click(object sender, EventArgs e)
        {
            //SFXSeleksi();
            //timer untuk menggerkkan tombol berhenti
            TombolTimer.Stop();
            TombolTimer.Tick -= TombolTimer_Tick;

            //memanggil method OpsiTerpilih dengan melewatkan Opsi Kanan
            OpsiTerpilih(PBOpsiKanan, OpsiR);
        }

        //method apabila sebuah Opsi terpilih maka berturut-turut akan ditampilkan hasil jawaban
        public void OpsiTerpilih(PictureBox PBOpsiTerpilih, Option OpsiTerpilih)
        {
            //Move pict on the middle of the form
            PBOpsiKiri.Location = new Point(332, 315);
            PBOpsiKanan.Location = new Point(1403, 315);

            //Scaling choosen picture
            PopUpGambar(PBOpsiTerpilih);

            //Result Right/Wrong
            PopUpHasil(OpsiTerpilih);

            //Show pict's description
            PopUpTextBox();

            //Start timer for the next question
            //IMPORTANT! bagian ini dapat dikomen untuk melihat hasil delaynya, karena delay masih error//
            //StartTimer(NextUrut);
        }

        ////// method-method yang dipanggil dari method OpsiTerpilih(sudah disertai fungsi delay tapi belum berjalan)///

        public async void PopUpGambar(PictureBox PBOpsiTerpilih)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(1000);          //Delay 1 detik
                foreach (Control item in PnlGame.Controls)
                    if (item is PictureBox)
                    {
                        if (item == PBOpsiTerpilih)
                        {
                            item.Size = new Size(250, 250);
                        }
                        else
                        {
                            item.Size = new Size(150, 150);
                        }
                    }
            }

        }
        public async void PopUpHasil(Option OpsiTerpilih)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(3000);          //Delay 2 detik setelah po up gambar
                //cek nilai opsi 
                if (OpsiTerpilih.NilaiOpsi == true)
                {
                    TbxResult.Text = "Jawaban kamu BENAR!";
                    //poinnambah <-- sistem poin
                }
                else
                {
                    TbxResult.Text = "Jawaban kamu SALAH";
                }
            }

        }
        public async void PopUpTextBox()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(3000);              //Delay 5 detik setelah pop up hasil
                foreach (Control textbox in PnlGame.Controls)
                    if (textbox is TextBox)
                    {
                        textbox.Visible = true;
                    }
                    else if (textbox is RichTextBox)
                    {
                        textbox.Visible = true;
                    }

                TBNamaKiri.Text = OpsiL.NamaOpsi;
                TBKetKiri.Text = OpsiL.KetOpsi;
                TBNamaKanan.Text = OpsiR.NamaOpsi;
                TBKetKanan.Text = OpsiR.KetOpsi;
            }
        }
        ////// method-method yang dipanggil dari method OpsiTerpilih(sudah disertai fungsi delay tapi belum berjalan)///

        ////////////////  Bagian SFX   ///////////////////////
        private void SFXSeleksi()
        {
            PlayBGMLoop();
            this.SoundPilih.SoundLocation = @"TombolTerpilih.wav";
            this.SoundPilih.Play();
        }
        private void SFXBenar()
        {
            PlayBGMLoop();
            this.SoundBenar.SoundLocation = @"TombolBenar.wav";
            this.SoundBenar.Play();
        }
        private void SFXSalah()
        {
            PlayBGMLoop();
            this.SoundSalah.SoundLocation = @"TombolSalah.wav";
            this.SoundSalah.Play();
        }
        private void SFXBack()
        {
            PlayBGMLoop();
            this.SoundKembali.SoundLocation = @"TombolKembali.wav";
            this.SoundKembali.Play();
        }
        private void PlayBGMLoop()     // Play Background music
        {
            try
            {
                this.BGM.SoundLocation = @"BG Song Gefy.wav";
                this.BGM.PlayLooping();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FormTutorial tutorial = new FormTutorial();
            tutorial.Show();
        }



        ////////////////////////////////////////////
    }
}
