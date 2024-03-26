using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessPiecesAsChessPieces
{
    internal class Board
    {
        private int horizontal;
        private int vertical;
        private string pictureName = "";

        public Board(int c_horizontal, int c_vertical, string c_pictureName)
        {
            horizontal = c_horizontal;
            vertical = c_vertical;
            pictureName = c_pictureName;
        
        }
        public int GetHorizontal() { return horizontal; }
        public int GetVertical() { return vertical; }
        public string GetPictureName() {  return pictureName; }

    }

}
