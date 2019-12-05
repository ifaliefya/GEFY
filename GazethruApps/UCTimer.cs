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

namespace GazethruApps
{
    public partial class UCTimer : UserControl
    {
        private static UCTimer _instance;
        public static UCTimer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UCTimer();
                return _instance;
            }
        }
        List<int> GameSequence = new List<int>();
        int Max;
        int Sequence;
        int OnPlay;
        List<int> randomRecords = new List<int>();

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public UCTimer()
        {
            InitializeComponent();
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

        public void SetRandomSequence ()
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

        int counter;
        public void StartGame (int urutan)
        {
            LblSoalKe.Text = urutan.ToString();
            Sequence = urutan;

            con.Open();
            string SelectQuery = "SELECT GameSeq FROM Sequence WHERE Id =" + urutan;
            SqlCommand comm = new SqlCommand(SelectQuery, con);
            SqlDataReader read = comm.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    OnPlay = read.GetInt32(0);
                }
            }
            counter = 3;
            CountdownTimer.Start();
            LblCountdown.Text = counter.ToString();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            LblCountdown.Text = counter.ToString();
            if (counter == 0)
            {
                LblCountdown.Text = "Mulai";
            }
            else if (counter < 0)
            {
                CountdownTimer.Stop();
                if (!FormGame.Instance.PnlUC.Controls.ContainsKey("UCGameOpsi"))
                {
                    UCGameOpsi GameOpsi = new UCGameOpsi();
                    GameOpsi.Dock = DockStyle.Fill;
                    FormGame.Instance.PnlUC.Controls.Add(GameOpsi);
                    GameOpsi.LoadOption(OnPlay, Sequence);
                }
                FormGame.Instance.PnlUC.Controls["UCGameOpsi"].BringToFront();
            }
        }

        private void UCTimer_Load(object sender, EventArgs e)
        {

        }
    }
}
