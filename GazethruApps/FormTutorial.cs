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
        List<int> GameSequence = new List<int>();
        int Max;
        List<int> randomRecords = new List<int>();

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public FormTutorial()
        {
            InitializeComponent();
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
    }
}
