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
        public FormPlayVideo()
        {
            InitializeComponent();
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
    }
}
