using System;

namespace ChessPiecesAsChessPieces
{
    internal class Piece
    {
        private string name;
        private string moveOptions;
        private int curHor, newHor, curVer, newVer;

        public Piece(string c_name)
        {
            this.name = c_name;
        }

        public void SetLocation(int newHor, int newVer)
        {
            curHor = newHor;
            curVer = newVer;
        }

        public string GetName()
        {
            return name;
        }

        public string GetMoveOptions(int _newHor, int _newVer)
        {
            newHor = _newHor;
            newVer = _newVer;
            moveOptions = "";
            switch (name)
            {
                case "Rook":
                    MoveRook();
                    break;
                case "Knight":
                    MoveKnight();
                    break;
                default:
                    break;
            }
            return moveOptions;
        }

        public void MoveRook()
        {
            int temp_x = Math.Abs(newHor - curHor);
            int temp_y = Math.Abs(newVer - curVer);
            if (temp_y == 2 || temp_y == 1)
            {
                if (temp_x == 0)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
            else if (temp_x == 2 || temp_x == 1)
            {

                if (temp_y == 0)

                {
                    moveOptions = $"{newHor}{newVer}";
                }

            }


        }

        public void MoveKnight()
        {
            // Initialize an array with possible knight moves relative to its current position
            int[] knightMoves = { -2, -1, 1, 2 };
            moveOptions = "";

            foreach (int dx in knightMoves)
            {
                foreach (int dy in knightMoves)
                {
                    // Valid knight moves are L-shaped: 2 in one direction, 1 in the other
                    if (Math.Abs(dx) != Math.Abs(dy) && Math.Abs(dx) + Math.Abs(dy) == 3)
                    {
                        int newX = curHor + dx;
                        int newY = curVer + dy;

                        // Check if the new position is within the board boundaries
                        if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                        {
                            moveOptions += $"{newX}{newY}, ";
                        }
                    }
                }
            }

            // Remove the trailing comma and space
            if (!string.IsNullOrEmpty(moveOptions))
            {
                moveOptions = moveOptions.TrimEnd(',', ' ');
            }
        }
    }
}
