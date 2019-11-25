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
    public partial class AdminGame : UserControl
    {
        private static AdminGame _instance;
        public static AdminGame Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminGame();
                return _instance;
            }
        }

        public AdminGame()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public int LastID;
        public int EditSession;

        private void AdminGame_Load(object sender, EventArgs e)
        {
            GameList("");
        }

        public void GameList(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT No, Quest, GambarL, GambarR FROM Game WHERE CONCAT(No, NamaL, NamaR, DescL, DescR) LIKE '%" + valueToSearch + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            DataTable table = new DataTable(); 
            adapter.Fill(table); 

            DGVGame.RowTemplate.Height = 80;
            DGVGame.AllowUserToAddRows = false;
            DGVGame.Columns.Clear();
            DGVGame.DataSource = table; 

            CreateImageColumn();
            CreateDeleteButton();

            DGVGame.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //GetFirstID(con);
            GetLastID(con);
        }

        private void TextBoxCari_TextChanged(object sender, EventArgs e)
        {
            GameList(TextBoxCari.Text);
        }

        private void CreateImageColumn()
        {
            DataGridViewImageColumn imgLCol = new DataGridViewImageColumn();
            imgLCol = (DataGridViewImageColumn)DGVGame.Columns[2];
            imgLCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewImageColumn imgRCol = new DataGridViewImageColumn();
            imgRCol = (DataGridViewImageColumn)DGVGame.Columns[3];
            imgRCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void CreateDeleteButton()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Name = "Delete";
            deleteBtn.Text = "Delete";

            deleteBtn.UseColumnTextForButtonValue = true;

            DGVGame.Columns.Add(deleteBtn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultPreview();
            EditSession = 0;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GameList("");
        }

        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT  ISNULL (MAX(No), 0) FROM Game", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LastID = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
        }

        private void BtnPilihGambarL_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                PicBoxGambarL.Image = Image.FromFile(opf.FileName);
            }
        }

        private void BtnPilihGambarR_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                PicBoxGambarR.Image = Image.FromFile(opf.FileName);
            }
        }

        private void NilaiL_CheckedChanged(object sender, EventArgs e)
        {
            NilaiR.Checked = !NilaiL.Checked;
            CheckText(NilaiL.Checked);
        }
        private void NilaiR_CheckedChanged(object sender, EventArgs e)
        {
            NilaiL.Checked = !NilaiR.Checked;
        }

        void CheckText(Boolean CekNilaiL)
        {
            if (CekNilaiL == true)
            {
                NilaiL.Text = "Jawaban BENAR";
                NilaiR.Text = "Jawaban SALAH";
            }
            else
            {
                NilaiR.Text = "Jawaban BENAR";
                NilaiL.Text = "Jawaban SALAH";
            }
        }

        private void DGVGame_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    this.DGVGame.Rows[e.RowIndex].Cells["No"].ReadOnly = true;

                int selected = (int)DGVGame.Rows[e.RowIndex].Cells["No"].Value;
                EditSession = selected;

                if (e.ColumnIndex == DGVGame.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Game WHERE No=" + EditSession, con);

                    if (MessageBox.Show("Yakin akan menghapus data ini ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ExecMyQuery(command, "Data Dihapus");
                    }
                }
                else
                {
                    PreviewDetail(EditSession);
                }
            //}
            //catch
            //{
            //    return;
            //}

        }

        public void PreviewDetail (int PreviewID)
        {
            con.Open();
            string SelectQuery = "SELECT * FROM Game WHERE No=" + PreviewID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                if (!Convert.IsDBNull(read["GambarL"]) && !Convert.IsDBNull(read["GambarR"]))
                {
                    Byte[] img1 = (Byte[])(read["GambarL"]);
                    MemoryStream ms1 = new MemoryStream(img1);
                    PicBoxGambarL.Image = Image.FromStream(ms1);

                    Byte[] img2 = (Byte[])(read["GambarR"]);
                    MemoryStream ms2 = new MemoryStream(img2);
                    PicBoxGambarR.Image = Image.FromStream(ms2);
                }
                else
                {
                    PicBoxGambarL.Image = null;
                    PicBoxGambarR.Image = null;
                }

                TextBoxQuest.Text = (String)(read["Quest"]);
                TextBoxNamaL.Text = (String)(read["NamaL"]);
                TextBoxNamaR.Text = (String)(read["NamaR"]);
                TextBoxKetL.Text = (String)(read["DescL"]);
                TextBoxKetR.Text = (String)(read["DescR"]);
                NilaiL.Checked = (Boolean)(read["NilaiL"]);
                NilaiR.Checked = (Boolean)(read["NilaiR"]);
            }
            else
            {
                DefaultPreview();
                con.Close();
            }
            con.Close();
        }

        public void DefaultPreview ()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            PicBoxGambarL.Image = bmp;
            PicBoxGambarR.Image = bmp;
            TextBoxQuest.Text = null;
            TextBoxNamaL.Text = null;
            TextBoxNamaR.Text = null;
            TextBoxKetL.Text = null;
            TextBoxKetR.Text = null;
            NilaiL.Checked = true;
            NilaiR.Checked = false;
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (EditSession == 0)
            {
                string InsertQuery =
                "DBCC CHECKIDENT (Game, RESEED," + LastID + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                "INSERT INTO Game(Quest, NamaL, NamaR, GambarL, GambarR, DescL, DescR, NilaiL, NilaiR) VALUES (@quest, @namal, @namar, @gambarl, @gambarr, @descl, @descr, @nilail, @nilair);";
                SqlCommand command = new SqlCommand(InsertQuery, con);

                command.Parameters.Add("@quest", SqlDbType.VarChar).Value = TextBoxQuest.Text;
                command.Parameters.Add("@namal", SqlDbType.VarChar).Value = TextBoxNamaL.Text;
                command.Parameters.Add("@namar", SqlDbType.VarChar).Value = TextBoxNamaR.Text;
                command.Parameters.Add("@descl", SqlDbType.VarChar).Value = TextBoxKetL.Text;
                command.Parameters.Add("@descr", SqlDbType.VarChar).Value = TextBoxKetR.Text;
                command.Parameters.Add("@nilail", SqlDbType.Bit).Value = NilaiL.Checked;
                command.Parameters.Add("@nilair", SqlDbType.Bit).Value = NilaiR.Checked;

                if (PicBoxGambarL.Image == null || PicBoxGambarR.Image == null)
                {
                    command.Parameters.Add("@gambarl", SqlDbType.Image).Value = DBNull.Value;
                    command.Parameters.Add("@gambarr", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@gambarl", SqlDbType.Image).Value = GetPic(PicBoxGambarL, PicBoxGambarL.Image);
                    command.Parameters.Add("@gambarr", SqlDbType.Image).Value = GetPic(PicBoxGambarR, PicBoxGambarR.Image);
                }
                ExecMyQuery(command, "Konten Gambar Ditambahkan");
            }
            else
            {
                string UpdateQuery =
               "UPDATE Game SET Quest=@quest, NamaL=@namal, NamaR=@namar, GambarL=@gambarl, GambarR=@gambarr, DescL=@descl, DescR=@descr, NilaiL=@nilail, NilaiR=@nilair WHERE No =" + EditSession;
                SqlCommand command = new SqlCommand(UpdateQuery, con);

                command.Parameters.Add("@quest", SqlDbType.VarChar).Value = TextBoxQuest.Text;
                command.Parameters.Add("@namal", SqlDbType.VarChar).Value = TextBoxNamaL.Text;
                command.Parameters.Add("@namar", SqlDbType.VarChar).Value = TextBoxNamaR.Text;
                command.Parameters.Add("@descl", SqlDbType.VarChar).Value = TextBoxKetL.Text;
                command.Parameters.Add("@descr", SqlDbType.VarChar).Value = TextBoxKetR.Text;
                command.Parameters.Add("@nilail", SqlDbType.Bit).Value = NilaiL.Checked;
                command.Parameters.Add("@nilair", SqlDbType.Bit).Value = NilaiR.Checked;

                if (PicBoxGambarL.Image == null || PicBoxGambarR.Image == null)
                {
                    command.Parameters.Add("@gambarl", SqlDbType.Image).Value = DBNull.Value;
                    command.Parameters.Add("@gambarr", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@gambarl", SqlDbType.Image).Value = GetPic(PicBoxGambarL, PicBoxGambarL.Image);
                    command.Parameters.Add("@gambarr", SqlDbType.Image).Value = GetPic(PicBoxGambarR, PicBoxGambarR.Image);
                }
                ExecMyQuery(command, "Konten Gambar Diperbarui");
            }
        }

        private byte[] GetPic(PictureBox PicBox, Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(PicBox.Image);
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return data;
            }
        }

        public void ExecMyQuery(SqlCommand mcomd, string myMsg)
        {
            con.Open();
            if (mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
                DefaultPreview();
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }
            con.Close();
            GameList("");
        }


    }
}
