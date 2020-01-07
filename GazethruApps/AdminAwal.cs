using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazethruApps
{
    public partial class AdminAwal : Form
    {
        public AdminAwal()
        {
            InitializeComponent();
            Sidepanel.Height = btn_Video.Height;
            Sidepanel.Top = btn_Video.Top;

            if (!panelUC.Controls.Contains(AdminVideo.Instance))
            {
                panelUC.Controls.Add(AdminVideo.Instance);
                AdminVideo.Instance.Dock = DockStyle.Fill;
                AdminVideo.Instance.BringToFront();
                AdminVideo Video = new AdminVideo();
                Video.VideoList("");
            }
            else
                AdminVideo.Instance.BringToFront();

            //Sidepanel.Height = btn_Slideshow.Height;
            //Sidepanel.Top = btn_Slideshow.Top;
            //if (!panelUC.Controls.Contains(AdminSlideshow.Instance))
            //{
            //    panelUC.Controls.Add(AdminSlideshow.Instance);
            //    AdminSlideshow.Instance.Dock = DockStyle.Fill;
            //    AdminSlideshow.Instance.BringToFront();
            //    AdminSlideshow Slideshow = new AdminSlideshow();
            //    //Slideshow.SlideList("");
            //}
            //else
            //    AdminSlideshow.Instance.BringToFront();
        }

        private void btn_Video_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btn_Video.Height;
            Sidepanel.Top = btn_Video.Top;

            if (!panelUC.Controls.Contains(AdminVideo.Instance))
            {
                panelUC.Controls.Add(AdminVideo.Instance);
                AdminVideo.Instance.Dock = DockStyle.Fill;
                AdminVideo.Instance.BringToFront();
                AdminVideo Video = new AdminVideo();
                Video.VideoList("");
            }
            else
                AdminVideo.Instance.BringToFront();
        }

        private void btn_Games_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btn_Games.Height;
            Sidepanel.Top = btn_Games.Top;

            if (!panelUC.Controls.Contains(AdminGame.Instance))
            {
                panelUC.Controls.Add(AdminGame.Instance);
                AdminGame.Instance.Dock = DockStyle.Fill;
                AdminGame.Instance.BringToFront();
                AdminGame Games = new AdminGame();
                Games.GameList("");
            }
            else
                AdminGame.Instance.BringToFront();
        }


        private void btn_Password_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btn_Password.Height;
            Sidepanel.Top = btn_Password.Top;

            if (!panelUC.Controls.Contains(AdminSetting.Instance))
            {
                panelUC.Controls.Add(AdminSetting.Instance);
                AdminSetting.Instance.Dock = DockStyle.Fill;
                AdminSetting.Instance.BringToFront();
                AdminSetting Peta = new AdminSetting();
            }
            else
                AdminSetting.Instance.BringToFront();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            FormHome Home = new FormHome();
            Home.Show();
            this.Hide();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
