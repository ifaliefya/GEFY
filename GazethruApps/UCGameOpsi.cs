using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace GazethruApps
{
    public partial class UCGameOpsi : UserControl
    {
        private static UCGameOpsi _instance;
        public static UCGameOpsi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCGameOpsi();
                return _instance;
            }
        }

        string Question;
        int NextUrut;
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

        public UCGameOpsi()
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

        //////////////Kendali Pake mata
        private void PilihOpsiKanan(ArgumenKendaliTombol e)     
        {
            if (e.status)
            {
                TimerTombol.Stop();

                OpsiTerpilih(PBOpsiKiri, OpsiL);
            }
            
        }

        private void PilihOpsiKiri(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                TimerTombol.Stop();

                OpsiTerpilih(PBOpsiKanan, OpsiR);
            }
        }
        //////////////Sampe sini kendali mata
        private void UCGameOpsi_Load(object sender, EventArgs e)
        {
            TimerTombol.Interval = 1;
            TimerTombol.Start();

            foreach (Control textbox in PanelOpsi.Controls)
                if (textbox is TextBox)
                {
                    textbox.Visible = false;
                }
               else if (textbox is  RichTextBox)
               {
                    textbox.Visible = false;
               }
        }

        private void TimerTombol_Tick(object sender, EventArgs e)
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

        public void LoadOption (int GameSeq, int Urutan)
        {
            NextUrut = Urutan + 1;
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
                    var nilaiL= (Boolean)(read["NilaiL"]);
                    Byte[] imgL = (Byte[])(read["GambarL"]);
                    OpsiL = new Option(namaL, imgL, descL, nilaiL);

                    var namaR = (String)(read["NamaR"]);
                    var descR = (String)(read["DescR"]);
                    var nilaiR= (Boolean)(read["NilaiR"]);
                    Byte[] imgR = (Byte[])(read["GambarR"]);
                    OpsiR = new Option(namaR, imgR, descR, nilaiR);

                    LoadPict(imgL, imgR);
                    TBQuest.Text = Question;
                    LabelCoba.Text = GameSeq.ToString();
                }
            }
            con.Close();
        }
        
        public void LoadPict (Byte[] img1, Byte[] img2)
        {
            MemoryStream ms1 = new MemoryStream(img1);
            PBOpsiKiri.Image = Image.FromStream(ms1);

            MemoryStream ms2 = new MemoryStream(img2);
            PBOpsiKanan.Image = Image.FromStream(ms2);
        }

        PictureBox AddOpsi (bool Kiri, Byte[] img)
        {
            PictureBox Opsi = new PictureBox();
            Opsi.Size = new Size(200, 200);
            Opsi.SizeMode = PictureBoxSizeMode.Zoom;
            MemoryStream ms = new MemoryStream(img);
            Opsi.Image = Image.FromStream(ms);
            Opsi.BackColor = Color.Transparent;

            if (Kiri == true)
            {
                Opsi.Name = "OpsiKiri"; 
                Opsi.Location = new Point(332, 87);
            }
            else
            {
                Opsi.Name = "OpsiKanan";
                Opsi.Location = new Point(1403, 642);
            }
            return Opsi;
        }

        private void PBOpsiKiri_Click(object sender, EventArgs e)
        {
            TimerTombol.Stop();
            
            OpsiTerpilih(PBOpsiKiri, OpsiL);
           
        }

        private void PBOpsiKanan_Click(object sender, EventArgs e)
        {
            TimerTombol.Stop();
            
            OpsiTerpilih(PBOpsiKanan, OpsiR);
        }

        public async void PopUpGambar(PictureBox PBOpsiTerpilih)
        {
            for(int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(1000);
                foreach (Control item in PanelOpsi.Controls)
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
            for(int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(3000);
                if (OpsiTerpilih.NilaiOpsi == true)
                {
                    LabelResult.Text = "Jawaban kamu BENAR!";
                    //poinnambah
                }
                else
                {
                    LabelResult.Text = "Jawaban kamu SALAH";
                }
            }
           
        }
        public async void PopUpTextBox()
        {
            for(int i = 0; i < 3; i++)
            {
                if (i == 0) await Task.Delay(8000);
                foreach (Control textbox in PanelOpsi.Controls)
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

        public void OpsiTerpilih(PictureBox PBOpsiTerpilih, Option OpsiTerpilih)
        {
            PBOpsiKiri.Location = new Point(332, 315);
            PBOpsiKanan.Location = new Point(1403, 315);

            PopUpGambar(PBOpsiTerpilih);
            PopUpHasil(OpsiTerpilih);
            PopUpTextBox();
                       
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            FormGame.Instance.PnlUC.Controls["UCTimer"].BringToFront();
            UCTimer.Instance.StartGame(NextUrut);
        }
    }
}
