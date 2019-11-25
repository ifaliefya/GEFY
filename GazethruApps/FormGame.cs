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
    public partial class FormGame : Form
    {
        private static FormGame Instance;
        public static FormGame getInstance()
        {
            if (Instance == null)
            {
                Instance = new FormGame();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        List<int> GameSequence = new List<int>();
        int counter;
        int Min;
        int Max;
        List<int> randomRecords = new List<int>();


        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public Panel PnlUC
        {
            get { return PanelUC; }
            set { PanelUC = value; }

        }


        public FormGame()
        {
            InitializeComponent();
           // GetRandomRecords();
           // GameStart();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            Instance = this;

            UCGameOpsi GameOpsi = new UCGameOpsi();
            GameOpsi.Dock = DockStyle.Fill;
            PanelUC.Controls.Add(GameOpsi);
        }

        public List<int> GetRandomRecords()
        {
            con.Open();
            string SelectQuery = "SELECT No FROM Game";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    GameSequence.Add((int)read.GetValue(0));
                }
                //Min = 0;
                Max = GameSequence.Count;
            }
            con.Close();

            var numberOfRecords = GameSequence.Count;
            for (int i = 0; i < numberOfRecords; i++)
            {
                var randomGenerator = new Random();
                while (true)
                {
                    var randomIndex = randomGenerator.Next(0, numberOfRecords);
                    var GameSeq = GameSequence[randomIndex];
                    if (!randomRecords.Contains(GameSeq))
                    {
                        randomRecords.Add(GameSeq);
                        break;
                    }
                }
            }
            return randomRecords;
        }

        public void GameStart()
        {

            var counter = 0;
            int cobala = randomRecords[counter];

            //if (!PanelUC.Controls.Contains(UCGameOpsi.Instance))
            //{
            //    PanelUC.Controls.Add(UCGameOpsi.Instance);
            //    UCGameOpsi.Instance.Dock = DockStyle.Fill;
            //    UCGameOpsi.Instance.BringToFront();
                UCGameOpsi GameOpsi = new UCGameOpsi();
                GameOpsi.LoadOption(cobala);
            //}
            //else
            //{
            //    UCGameOpsi.Instance.BringToFront();
            //}

            counter++;
        }


    }
}
