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
    public partial class FormGame : Form
    {
        private static FormGame Instance;
        public static FormGame getInstance()
        {
            if (Instance == null || Instance.IsDisposed)
            {
                Instance = new FormGame();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }


        public FormGame()
        {
            InitializeComponent();
            if (!PanelUC.Controls.Contains(UCGameOpsi.Instance))
            {
                PanelUC.Controls.Add(UCGameOpsi.Instance);
                UCGameOpsi.Instance.Dock = DockStyle.Fill;
                UCGameOpsi.Instance.BringToFront();
                UCGameOpsi Slideshow = new UCGameOpsi();
            }
            else
                UCGameOpsi.Instance.BringToFront();
        }
    }
}
