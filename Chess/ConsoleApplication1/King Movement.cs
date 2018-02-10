using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class KingpMoveType : IMovementType
    {
        public bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y)
        {
            int Xdiff, Ydiff;
            Xdiff = Math.Abs(X - piece.GetX());
            Ydiff = Math.Abs(Y - piece.GetY());

            if ((Xdiff == 1 || Xdiff == 0) &&
                (Ydiff == 1 || Ydiff == 0))
            {
                return true;
            }
            return false;
        }
    }
}
