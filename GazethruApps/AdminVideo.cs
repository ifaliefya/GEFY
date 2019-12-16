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
    public partial class AdminVideo : UserControl
    {
        private static AdminVideo _instance;
        public static AdminVideo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdminVideo();
                return _instance;
            }
        }

        public AdminVideo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Properties.Settings.Default.sqlcon);

        public int LastID;
        public int EditSession;

        private void AdminVideo_Load(object sender, EventArgs e)
        {
            VideoList("");
            DefaultPreview();
        }

        public void VideoList(string valueToSearch)
        {
            SqlCommand command = new SqlCommand("SELECT Id, Judul, Thumbnail FROM Video WHERE CONCAT(Id, Judul, Ket) LIKE '%" + valueToSearch + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command); 
            DataTable table = new DataTable(); 
            adapter.Fill(table); 

            DGVVideo.RowTemplate.Height = 80;
            DGVVideo.AllowUserToAddRows = false;
            DGVVideo.Columns.Clear();
            DGVVideo.DataSource = table; 

            CreateImageColumn();
            CreateDeleteButton();

            DGVVideo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //GetFirstID(con);
            GetLastID(con);
        }

        private void TextBoxCari_TextChanged(object sender, EventArgs e)
        {
            VideoList(TextBoxCari.Text);
        }

        private void CreateImageColumn()
        {
            DataGridViewImageColumn imgLCol = new DataGridViewImageColumn();
            imgLCol = (DataGridViewImageColumn)DGVVideo.Columns[2];
            imgLCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void CreateDeleteButton()
        {
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            deleteBtn.HeaderText = "";
            deleteBtn.Name = "Delete";
            deleteBtn.Text = "Delete";

            deleteBtn.UseColumnTextForButtonValue = true;

            DGVVideo.Columns.Add(deleteBtn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultPreview();
            EditSession = 0;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            VideoList("");
        }

        public void GetLastID(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT  ISNULL (MAX(Id), 0) FROM Video", connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LastID = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
        }

        private void BtnPilihVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV"; ;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.TbxPath.Text = opf.FileName;
                MediaPlayer.URL = TbxPath.Text;
                MediaPlayer.Ctlcontrols.play();
            }
        }

        private void BtnPilihGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG; *.PNG; *.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                PbxThumbnail.Image = Image.FromFile(opf.FileName);
            }
        }

        private void TbxPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV"; ;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.TbxPath.Text = opf.FileName;
                MediaPlayer.URL = TbxPath.Text;
                MediaPlayer.Ctlcontrols.play();
            }
        }

        private void DGVVideo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    this.DGVGame.Rows[e.RowIndex].Cells["No"].ReadOnly = true;

                int selected = (int)DGVVideo.Rows[e.RowIndex].Cells["Id"].Value;
                EditSession = selected;

                if (e.ColumnIndex == DGVVideo.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Video WHERE Id=" + EditSession, con);

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
            string SelectQuery = "SELECT * FROM Video WHERE Id=" + PreviewID;
            SqlCommand command = new SqlCommand(SelectQuery, con);
            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                if (!Convert.IsDBNull(read["Thumbnail"]))
                {
                    Byte[] img1 = (Byte[])(read["Thumbnail"]);
                    MemoryStream ms1 = new MemoryStream(img1);
                    PbxThumbnail.Image = Image.FromStream(ms1);
                }
                else
                {
                    PbxThumbnail.Image = null;
                }

                TbxJudul.Text = (String)(read["Judul"]);
                TbxPath.Text = (String)(read["Path"].ToString());
                TbxKet.Text = (String)(read["Ket"]);
            }
            else
            {
                DefaultPreview();
                con.Close();
            }
            con.Close();

            MediaPlayer.URL = TbxPath.Text;
            MediaPlayer.Ctlcontrols.play();
        }

        public void DefaultPreview ()
        {
            EditSession = 0;
            Bitmap bmp = new Bitmap(Properties.Resources.defaultPic);
            PbxThumbnail.Image = bmp;
            TbxJudul.Text = null;
            TbxKet.Text = null;
            TbxPath.Text = null;
            MediaPlayer.Ctlcontrols.stop();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (EditSession == 0)
            {
                string InsertQuery =
                "DBCC CHECKIDENT (Video, RESEED," + LastID + "); " + //DBCC adalah menyalahi aturan increment dan unique, semoga tidak error
                "INSERT INTO Video(Judul, Path, Thumbnail, Ket) VALUES (@judul, @path, @thumbnail, @ket);";
                SqlCommand command = new SqlCommand(InsertQuery, con);

                command.Parameters.Add("@judul", SqlDbType.VarChar).Value = TbxJudul.Text;
                command.Parameters.Add("@path", SqlDbType.VarBinary).Value = File.ReadAllBytes(TbxPath.Text);
                command.Parameters.Add("@ket", SqlDbType.VarChar).Value = TbxKet.Text;

                if (PbxThumbnail.Image == null )
                {
                    command.Parameters.Add("@thumbnail", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@thumbnail", SqlDbType.Image).Value = GetPic(PbxThumbnail, PbxThumbnail.Image);
                }
                ExecMyQuery(command, "Konten Video Ditambahkan");
            }
            else
            {
                string UpdateQuery = 
                "UPDATE Video SET Judul=@judul, Path=@path, Thumbnail=@thumbnail, Ket=@ket WHERE Id =" + EditSession;
                SqlCommand command = new SqlCommand(UpdateQuery, con);

                command.Parameters.Add("@judul", SqlDbType.VarChar).Value = TbxJudul.Text;
                command.Parameters.Add("@path", SqlDbType.VarBinary).Value = File.ReadAllBytes(TbxPath.Text);
                command.Parameters.Add("@ket", SqlDbType.VarChar).Value = TbxKet.Text;

                if (PbxThumbnail.Image == null)
                {
                    command.Parameters.Add("@thumbnail", SqlDbType.Image).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@thumbnail", SqlDbType.Image).Value = GetPic(PbxThumbnail, PbxThumbnail.Image);
                }
                ExecMyQuery(command, "Konten Video Diperbarui");
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
            VideoList("");
        }

        

        private void BtnStart_Click(object sender, EventArgs e)
        {
            MediaPlayer.URL = TbxPath.Text;
            MediaPlayer.Ctlcontrols.play();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.pause();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.stop();
        }

        private void MediaPlayer_Enter(object sender, EventArgs e)
        {

        }


    }
}
