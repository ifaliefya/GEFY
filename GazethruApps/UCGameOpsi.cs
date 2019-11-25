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

        List<int> GameSequence = new List<int>();
        int counter;
        int Min;
        int Max;
        List<int> randomRecords = new List<int>();
        string Question;
        public struct OpsiKiri
        {
            public string NamaOpsiKiri;
            public Byte[] GambarOpsiKiri;
            public string KetOpsiKiri;
            public bool NilaiOpsiKiri;

            public OpsiKiri(string namaA, Byte[] gambarA, string ketA, bool nilaiA)
            {
                NamaOpsiKiri = namaA;
                GambarOpsiKiri = gambarA;
                KetOpsiKiri = ketA;
                NilaiOpsiKiri = nilaiA;
            }
        }

        public struct OpsiKanan
        {
            public string NamaOpsiKanan;
            public Byte[] GambarOpsiKanan;
            public string KetOpsiKanan;
            public bool NilaiOpsiKanan;

            public OpsiKanan(string namaB, Byte[] gambarB, string ketB, bool nilaiB)
            {
                NamaOpsiKanan = namaB;
                GambarOpsiKanan = gambarB;
                KetOpsiKanan = ketB;
                NilaiOpsiKanan = nilaiB;
            }
        }


        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        List<double> wx;
        List<double> wy;
        int lap = 0;

        KendaliTombol kendaliuser;

        public UCGameOpsi()
        {
            InitializeComponent();


        }

        

        private void UCGameOpsi_Load(object sender, EventArgs e)
        {
            //RandomingID();
        }

        public void LoadOption (int GameSeq)
        {
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
                    var OpsiL = new OpsiKiri(namaL, imgL, descL, nilaiL);

                    var namaR = (String)(read["NamaR"]);
                    var descR = (String)(read["DescR"]);
                    var nilaiR= (Boolean)(read["NilaiR"]);
                    Byte[] imgR = (Byte[])(read["GambarR"]);
                    var OpsiR = new OpsiKanan(namaR, imgR, descR, nilaiR);

                    PictureBox OpsiLeft = AddOpsi(true, imgL);
                    PanelOpsi.Controls.Add(OpsiLeft);

                    //AddOpsi(false, imgR);
                }
            }
            con.Close();
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


    }
}
