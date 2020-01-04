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

namespace GazethruApps
{
    public partial class FormVideo : Form
    {
        List<int> ShowID = new List<int>();
        int counter = 0;
        int maxCounter;
        int TengahID;

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);
        KendaliTombol kendali;
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public FormVideo()
        {
            InitializeComponent();
            PopulateViewID();
            kendali = new KendaliTombol();

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx[0] = 171;
            wy[0] = 333;
            wx[1] = 1690;
            wy[1] = 779;
            wx[2] = 688;
            wy[2] = 836;
            wx[3] = 1134;
            wy[3] = 962;

            kendali.TambahTombol(BtnPrev, new FungsiTombol(TombolPrevTekan));
            kendali.TambahTombol(BtnNext, new FungsiTombol(TombolNextTekan));
            kendali.TambahTombol(BtnPlay, new FungsiTombol(TombolPlayTekan));
            kendali.TambahTombol(BtnBack, new FungsiTombol(TombolBackTekan));
            kendali.Start();
        }        
        void PopulateViewID()
        {
            con.Open();
            string SelectQuery = "SELECT Id FROM Video";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    ShowID.Add((int)read.GetValue(0));
                }
                TengahID = ShowID[0];
                maxCounter = ShowID.Count;
            }
            else
            {
                maxCounter = 1;
                //PopulateButton
            }
            con.Close();

            if (maxCounter == 0)
            {
                PanelKiri.Visible = false;
                PanelKanan.Visible = false;
                Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
                PbxTengah.Image = bmp;
                TbxJudulTengah.Text = "Belum ada konten";


                BtnPrev.Enabled = false;
                BtnNext.Enabled = false;
            }
            else if (maxCounter == 1)
            {
                PanelKiri.Visible = false;
                PanelKanan.Visible = false;
                LoadTengah(ShowID[0]);

                BtnPrev.Enabled = false;
                BtnNext.Enabled = false;
            }
            else if (maxCounter > 1)
            {
                ReloadCarousel(0);
            }
        }

        void ReloadCarousel (int IDTengah)
        {
            int IDKiri = IDTengah - 1;
            int IDKanan = IDTengah + 1;
            counter = IDTengah;

            if (IDKiri < 0)
            {
                PanelKiri.Visible = false;
                PanelKanan.Visible = true;

                LoadTengah(ShowID[IDTengah]);
                LoadKanan(ShowID[IDKanan]);
                
                BtnPrev.Enabled = false;
                BtnNext.Enabled = true;
            }
            else if (IDKanan> maxCounter-1)
            {
                PanelKiri.Visible = true;
                PanelKanan.Visible = false;

                LoadTengah(ShowID[IDTengah]);
                LoadKiri(ShowID[IDKiri]);

                BtnPrev.Enabled = true;
                BtnNext.Enabled = false;
            }
            else
            {
                PanelKiri.Visible = true;
                PanelKanan.Visible = true;

                LoadTengah(ShowID[IDTengah]);
                LoadKiri(ShowID[IDKiri]);
                LoadKanan(ShowID[IDKanan]);

                BtnPrev.Enabled = true;
                BtnNext.Enabled = true;
            }
        }


        public void LoadTengah (int VideoID)
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Video WHERE Id = " + VideoID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                TbxJudulTengah.Text = read["Judul"].ToString();
                TbxDescTengah.Text = read["Ket"].ToString();

                if (!Convert.IsDBNull(read["Thumbnail"]))
                {
                    Byte[] img = (Byte[])(read["Thumbnail"]);
                    MemoryStream ms = new MemoryStream(img);
                    PbxTengah.Image = Image.FromStream(ms);
                }
                else
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
                    PbxTengah.Image = bmp;
                }
            }
            else
            {
                TbxDescTengah.Text = "";
                Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            }
            con.Close();
        }

        public void LoadKiri(int VideoID)
        {
            PanelKiri.Visible = true;
            con.Open();
            string SelectQuery = "SELECT * FROM Video WHERE Id = " + VideoID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                TbxJudulKiri.Text = read["Judul"].ToString();

                if (!Convert.IsDBNull(read["Thumbnail"]))
                {
                    Byte[] img = (Byte[])(read["Thumbnail"]);
                    MemoryStream ms = new MemoryStream(img);
                    PbxKiri.Image = Image.FromStream(ms);
                }
                else
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
                    PbxKiri.Image = bmp;
                }
            }
            else
            {
                Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            }
            con.Close();
        }

        public void LoadKanan(int VideoID)
        {
            PanelKanan.Visible = true;
            con.Open();
            string SelectQuery = "SELECT * FROM Video WHERE Id = " + VideoID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                TbxJudulKanan.Text = read["Judul"].ToString();

                if (!Convert.IsDBNull(read["Thumbnail"]))
                {
                    Byte[] img = (Byte[])(read["Thumbnail"]);
                    MemoryStream ms = new MemoryStream(img);
                    PbxKanan.Image = Image.FromStream(ms);
                }
                else
                {
                    Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
                    PbxKanan.Image = bmp;
                }
            }
            else
            {
                Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            }
            con.Close();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            counter = counter - 1;
            ReloadCarousel(counter);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            counter = counter + 1;
            ReloadCarousel(counter);
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            FormPlayVideo Play = new FormPlayVideo();
            Play.Show();
            Play.PlayVideo(ShowID[counter]);
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            FormHome frmhome = new FormHome();
            frmhome.Show();
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnPrev.Location = new Point((int)wx[0], (int)wy[0]);
            BtnNext.Location = new Point((int)wx[1], (int)wy[1]);
            BtnPlay.Location = new Point((int)wx[2], (int)wy[2]);
            BtnBack.Location = new Point((int)wx[3], (int)wy[3]);
            if(lap ==0)
            {
                wy[0]++;
                wy[1]--;
                wx[2]++;
                wx[3]--;
            }
            if(lap==1)
            {
                wy[0]--;
                wy[1]++;
                wx[2]--;
                wx[3]++;
            }
            if(wx[2]== 688)
                lap = 0;            
            if(wx[2]== 1134)
                lap = 1;
            kendali.CekTombol();
        }
        ////////////////////// Event Kendali mata ////////////
        private void TombolPrevTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                counter = counter - 1;
                ReloadCarousel(counter);
            }
        }
        private void TombolNextTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                counter = counter + 1;
                ReloadCarousel(counter);
            }
        }
        private void TombolPlayTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                FormPlayVideo Play = new FormPlayVideo();
                Play.Show();
                Play.PlayVideo(ShowID[counter]);
            }
        }
        private void TombolBackTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                FormHome frmhome = new FormHome();
                frmhome.Show();
                this.Close();
            }
        }
        ////////////////////// End kendali mata /////////////

        private void FormVideo_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Start();
        }        
    }
}
