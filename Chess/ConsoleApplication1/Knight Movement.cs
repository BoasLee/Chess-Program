using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class KnightMoveType : IMovementType
    {
       public bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y)
        {
            int Xdiff, Ydiff;
            Xdiff = Math.Abs(piece.GetX() - X);
            Ydiff = Math.Abs(piece.GetY() - Y);
            if ((Xdiff == 1 && Ydiff == 2) ||
                (Xdiff == 2 && Ydiff == 1))
            {
                return true;
            }
            return false;
        }
    }
}
