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
        private SoundPlayer SoundPilih = new SoundPlayer();
        private SoundPlayer SoundBenar = new SoundPlayer();
        private SoundPlayer SoundSalah = new SoundPlayer();
        private SoundPlayer SoundKembali = new SoundPlayer();

        private int counter;
        private int Sequence;
        private int GameID;
        int NextUrut;
        string Question;
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
        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendaliuser;

        public FormStartGame()
        {
            InitializeComponent();
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

        //////////////   Kendali Pake mata    ////////////////////////////        
        private void PilihOpsiKiri(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                SFXSeleksi();

                TombolTimer.Stop();
                TombolTimer.Tick -= TombolTimer_Tick;

                OpsiTerpilih(PBOpsiKiri, OpsiL);
            }
        }
        private void PilihOpsiKanan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                SFXSeleksi();

                TombolTimer.Stop();
                TombolTimer.Tick -= TombolTimer_Tick;

                OpsiTerpilih(PBOpsiKanan, OpsiR);
            }

        }
        //////////////    Sampe sini kendali mata   ////////////////////////////
        ///
        private void FormStartGame_Load(object sender, EventArgs e)
        {
            PnlTimer.Visible = true;
            PnlGame.Visible = false;
            counter = 3;
            LblTimer.Text = counter.ToString(); 
            StartTimer(1);
        }

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

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter== -1)
            {
                CountdownTimer.Stop();
                counter = 3;
                StartGame(GameID, Sequence);
                this.Controls.Remove(this.PnlTimer);
                CountdownTimer.Tick -= CountdownTimer_Tick;
            }
            LblTimer.Text = counter.ToString();
            if (counter == 0)
            {
                LblTimer.Text = "Mulai";
            }
        }

       public void StartTimer(int urutan)
        {
            this.Controls.Add(this.PnlTimer);
            PnlTimer.Visible = true;
            PnlGame.Visible = false;
            ResetGame();
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
                    GameID = read.GetInt32(0);
                }
            }
            con.Close();
            
            CountdownTimer.Interval = 1000;
            CountdownTimer.Enabled = true;
            CountdownTimer.Tick += new EventHandler(CountdownTimer_Tick);
        }

        public void StartGame(int GameSeq, int urutan)
        {
            PnlGame.Visible = true;
            PnlTimer.Visible = false;

            NextUrut = urutan + 1;
            con.Open();
            string SelectOption = "SELECT * FROM Game WHERE No = ";
            SqlCommand command = new SqlCommand(SelectOption + GameSeq, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Question = (String)(read["Quest"]);

                    var namaL = (String)(read["NamaL"]);
                    var descL = (String)(read["DescL"]);
                    var nilaiL = (Boolean)(read["NilaiL"]);
                    Byte[] imgL = (Byte[])(read["GambarL"]);
                    OpsiL = new Option(namaL, imgL, descL, nilaiL);

                    var namaR = (String)(read["NamaR"]);
                    var descR = (String)(read["DescR"]);
                    var nilaiR = (Boolean)(read["NilaiR"]);
                    Byte[] imgR = (Byte[])(read["GambarR"]);
                    OpsiR = new Option(namaR, imgR, descR, nilaiR);

                    LoadPict(imgL, imgR);
                    TBQuest.Text = Question;
                    LabelCoba.Text = GameSeq.ToString();
                }
            }
            con.Close();
            TombolTimer.Tick += new EventHandler(TombolTimer_Tick);
        }

        public void LoadPict(Byte[] img1, Byte[] img2)
        {
            MemoryStream ms1 = new MemoryStream(img1);
            PBOpsiKiri.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream(img2);
            PBOpsiKanan.Image = Image.FromStream(ms2);
        }

        void ResetGame ()
        {
            PBOpsiKiri.Location = new Point(372,87);
            PBOpsiKanan.Location = new Point(1351, 635);
            foreach (Control textbox in PnlGame.Controls)
                if (textbox is TextBox)
                {
                    textbox.Visible = false;
                }
                else if (textbox is RichTextBox)
                {
                    textbox.Visible = false;
                }
        }

        private void PBOpsiKiri_Click(object sender, EventArgs e)
        {
            SFXSeleksi();

            TombolTimer.Stop();
            TombolTimer.Tick -= TombolTimer_Tick;

            OpsiTerpilih(PBOpsiKiri, OpsiL);

        }

        private void PBOpsiKanan_Click(object sender, EventArgs e)
        {
            SFXSeleksi();

            TombolTimer.Stop();
            TombolTimer.Tick -= TombolTimer_Tick;

            OpsiTerpilih(PBOpsiKanan, OpsiR);
        }

        public void OpsiTerpilih(PictureBox PBOpsiTerpilih, Option OpsiTerpilih)
        {
            PBOpsiKiri.Location = new Point(332, 315);
            PBOpsiKanan.Location = new Point(1403, 315);

            PopUpGambar(PBOpsiTerpilih);
            PopUpHasil(OpsiTerpilih);
            PopUpTextBox();
            //StartTimer(NextUrut);
        }

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
                if (OpsiTerpilih.NilaiOpsi == true)
                {
                    TbxResult.Text = "Jawaban kamu BENAR!";
                    //poinnambah
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

        ////////////////  Bagian SFX   ///////////////////////
        private void SFXSeleksi()
        {
            this.SoundPilih.SoundLocation = @"TombolTerpilih.wav";
            this.SoundPilih.Play();
        }
        private void SFXBenar()
        {
            this.SoundBenar.SoundLocation = @"TombolBenar.wav";
            this.SoundBenar.Play();
        }
        private void SFXSalah()
        {
            this.SoundSalah.SoundLocation = @"TombolSalah.wav";
            this.SoundSalah.Play();
        }
        private void SFXBack()
        {
            this.SoundKembali.SoundLocation = @"TombolKembali.wav";
            this.SoundKembali.Play();
        }



        ////////////////////////////////////////////
    }
}
