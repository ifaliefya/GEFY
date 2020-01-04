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

namespace GazethruApps
{
    public partial class FormTutorial : Form
    {
        public static FormTutorial Instance;

        public static FormTutorial getInstance()
        {
            if (Instance == null)
            {
                Instance = new FormTutorial();
            }
            else
            {
                Instance.BringToFront();
            }
            return Instance;
        }

        List<int> GameSequence = new List<int>();
        int Max;
        List<int> randomRecords = new List<int>();

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        KendaliTombol kendali;
        List<double> wx;
        List<double> wy;
        int lap = 0;
        public FormTutorial()
        {
            InitializeComponent();
            kendali = new KendaliTombol();
            wx = new List<double>();
            wy = new List<double>();
            wx.Add(0);
            wy.Add(0);
            wx.Add(0);
            wy.Add(0);
            wx[0] = 744;
            wy[0] = 807;
            wx[1] = 1704;
            wy[1] = 222;

            kendali.TambahTombol(BtnStart, new FungsiTombol(TombolStartTekan));
            kendali.TambahTombol(BtnBack, new FungsiTombol(TombolBackTekan));
            kendali.Start();
        }
        
        public void SetRandomSequence()
        {
            con.Open();
            string sqlTrunc = "TRUNCATE TABLE Sequence";
            SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            cmd.ExecuteNonQuery();

            string SelectQuery = "SELECT No FROM Game";
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    GameSequence.Add((int)read.GetValue(0));
                }
                Max = GameSequence.Count;
            }
            con.Close();

            for (int i = 0; i < Max; i++)
            {
                var randomGenerator = new Random();
                while (true)
                {
                    var randomIndex = randomGenerator.Next(0, Max);
                    var GameSeq = GameSequence[randomIndex];
                    if (!randomRecords.Contains(GameSeq))
                    {
                        randomRecords.Add(GameSeq);
                        string InsertQuery = "INSERT INTO Sequence(GameSeq) VALUES (@gameseq);";
                        SqlCommand insert = new SqlCommand(InsertQuery, con);
                        insert.Parameters.Add("@gameseq", SqlDbType.Int).Value = GameSeq;
                        con.Open();
                        insert.ExecuteNonQuery();
                        con.Close();

                        break;

                    }
                }
            }

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            SetRandomSequence();
            FormStartGame Start = new FormStartGame();
            Start.Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            formAwal frmawal = new formAwal();
            frmawal.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BtnStart.Location = new Point((int)wx[0], (int)wy[0]);
            BtnBack.Location = new Point((int)wx[1], (int)wy[1]);
            if(lap==0)
            {
                wx[0]++;
                wy[1]++;
            }
            if(lap==1)
            {
                wx[0]--;
                wy[1]--;
            }
            if(wx[0]==1144)
                lap = 1;
            if(wx[0]==744)
                lap = 0;

            kendali.CekTombol();
        }

        private void FormTutorial_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 14;
            timer1.Start();
        }
        /////////////// Event Kendali mata /////////
        private void TombolStartTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                SetRandomSequence();
                FormStartGame Start = new FormStartGame();
                Start.Show();
                this.Close();
            }
        }
        private void TombolBackTekan(ArgumenKendaliTombol e)
        {
            if (e.status)
            {
                formAwal frmawal = new formAwal();
                frmawal.Show();
                this.Close();
            }
        }
        ////////////////// End Event kendali ////////////
    }
}
