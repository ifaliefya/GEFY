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
    public partial class FormPlayVideo : Form
    {
        KendaliTombol kendali;
        List<double> wx;
        List<double> wy;
        int lap = 0;

        public FormPlayVideo()
        {
            InitializeComponent();
            kendali = new KendaliTombol();

            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx[0] = 1725;
            wy[0] = 232;

            kendali.TambahTombol(BtnBack, new FungsiTombol(TombolBackTekan));
            kendali.Start();
        }

        private void TombolBackTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                this.Close();
            }
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);
        string VideoPath;

        public void PlayVideo (int VideoID)
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Video WHERE Id = " + VideoID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                LblJudul.Text = read["Judul"].ToString();
                VideoPath = (String) read["Path"];
            }
            con.Close();

            MediaPlayer.URL = VideoPath;
            MediaPlayer.Ctlcontrols.play();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnBack.Location = new Point((int)wx[0], (int)wy[0]);
            if (lap == 0)
                wy[0]++;
            if (lap == 1)
                wy[0]--;
            if (wy[0] == 823)
                lap = 1;
            if (wy[0] == 232)
                lap = 0;
            kendali.CekTombol();
        }

        private void FormPlayVideo_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 14;
            timer1.Start();
        }
    }
}
