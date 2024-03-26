using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessPiecesAsChessPieces
{
    public partial class Form1 : Form
    {
        Piece currentPiece = null;
        PictureBox pcbFrom;
        PictureBox pcbTo;
        int horizontal = 0;
        int vertical = 0;
        string pieceOptions = "";
        List<Board> boardlist = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox pb in gbxGame.Controls.OfType<PictureBox>())
            {
                pb.BackColor = Color.LightGray;
                pb.AllowDrop = true;
            }
            //A list so all boardlocatiocations are konow. Including the pictureboxnames and horizontal/vertical coordinates
            boardlist = new List<Board>();
            boardlist.Add(new Board(1, 1, "pcbOne11"));
            boardlist.Add(new Board(2, 1, "pcbtwo21"));
            boardlist.Add(new Board(3, 1, "pcbThree31"));
            boardlist.Add(new Board(1, 2, "pcbFour12"));
            boardlist.Add(new Board(2, 2, "pcbFive22"));
            boardlist.Add(new Board(3, 2, "pcbSix32"));
            boardlist.Add(new Board(1, 3, "pcbSeven13"));
            boardlist.Add(new Board(2, 3, "pcbEight23"));
            boardlist.Add(new Board(3, 3, "pcbNine33"));
        }
        private void btnRook_Click(object sender, EventArgs e)
        {
            ClearAllImagesFromBoard();
            //starting with a rook piece on location 11 (left top corner)
            currentPiece = new Piece("Rook");
            currentPiece.SetLocation(1, 1);
            Bitmap bm = new Bitmap(@"C:\Users\redfo\Desktop\C# ChatApp\ChessPiecesAsChessPieces\ChessPiecesAsChessPieces\img\rook.png");
            pcbOne11.Image = bm;
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            currentPiece = new Piece("Knight");
            currentPiece.SetLocation(1, 2);
            Bitmap bm = new Bitmap(@"C:\Users\redfo\Desktop\C# ChatApp\ChessPiecesAsChessPieces\ChessPiecesAsChessPieces\img\chess.png");
            pcbOne11.Image = bm;
        }
        private void pcbTwo21_Click(object sender, EventArgs e)
        {

        }

        private void pcbThree31_Click(object sender, EventArgs e)
        {

        }

        private void pcbFour12_Click(object sender, EventArgs e)
        {

        }

        private void pcbFive22_Click(object sender, EventArgs e)
        {

        }

        private void pcbSix32_Click(object sender, EventArgs e)
        {

        }

        private void pcbSeven13_Click(object sender, EventArgs e)
        {

        }

        private void pcbEight23_Click(object sender, EventArgs e)
        {

        }

        private void pcbNine33_Click(object sender, EventArgs e)
        {

        }

        private void pcbAll_MouseDown(object sender, MouseEventArgs e)
        {
            ClearBoardColors();
            pcbFrom = (PictureBox)sender;
            if (pcbFrom != null)
            {
                GetBoardOptions();
                UpdateBoardpieceOptions();
                pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
            }
        }
        private void ClearBoardColors()
        {
            foreach (PictureBox pb in gbxGame.Controls.OfType<PictureBox>())
            {
                pb.BackColor = Color.LightGray;
            }
        }
        private void GetBoardOptions()
        {
            pieceOptions = "";
            foreach (Board item in boardlist)
            {
                if (currentPiece != null)
                {
                    pieceOptions += currentPiece.GetMoveOptions(item.GetHorizontal(), item.GetVertical());
                }
            }
        }
        private void UpdateBoardpieceOptions()
        {
            for (int i = 0; i < pieceOptions.Length; i += 2)
            {
                foreach (PictureBox pb in gbxGame.Controls.OfType<PictureBox>())
                {
                    if (pb.Tag.ToString() == pieceOptions[i].ToString() + pieceOptions[i + 1].ToString() && pb.Image == null)
                    {
                        pb.BackColor = Color.Green;
                    }
                }
            }
        }
        private void pcbAll_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && ((PictureBox)sender).BackColor == Color.Green)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void pcbAll_DragDrop(object sender, DragEventArgs e)
        {
            pcbTo = (PictureBox)sender;
            Image getPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pcbTo.Image = getPicture;
            horizontal = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
            vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(1, 1));
            currentPiece.SetLocation(horizontal, vertical);
            pcbFrom.Image = null;
            ClearBoardColors();
        }
        public void ClearAllImagesFromBoard()
        {
            foreach (PictureBox pb in gbxGame.Controls.OfType<PictureBox>())
            {
                pb.BackColor = Color.LightGray;
                pb.Image = null;
            }
        }
    }
}
