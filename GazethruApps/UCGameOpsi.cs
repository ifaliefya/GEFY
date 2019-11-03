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


        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public UCGameOpsi()
        {
            InitializeComponent();

            //RandomingID();
            GetRandomRecords();
            Coba();
        }

        

        private void UCGameOpsi_Load(object sender, EventArgs e)
        {
            //RandomingID();
        }

        public void GetRandomRecords()
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
            for (int i=0; i<numberOfRecords; i++)
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
        }

        public void Coba()
        {
            var counter = randomRecords.Count;
            for (int i=0; i<counter; i++)
            {
                int cobala = randomRecords[i];
            }
        }
    }
}
