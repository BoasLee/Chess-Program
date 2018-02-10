using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RookMoveType : IMovementType
    {
        public bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y)
        {
            int Xdiff, Ydiff, XMovement, YMovement;
            Xdiff = X - piece.GetX();
            Ydiff = Y - piece.GetY();
            if (Xdiff == 0 || Ydiff == 0) // Verifies that the rook is moving only in the X or the Y direction
            {
                if (Xdiff > 0)
                {
                    XMovement = 1;
                }
                else if (Xdiff == 0)
                {
                    XMovement = 0;
                }
                else
                {
                    XMovement = -1;
                }
                if (Ydiff > 0)
                {
                    YMovement = 1;
                }
                else if (Ydiff == 0)
                {
                    YMovement = 0;
                }
                else
                {
                    YMovement = -1;
                }

                while (!(Y - YMovement == piece.GetY() && X - XMovement == piece.GetX()))
                {
                    X -= XMovement;
                    Y -= YMovement;
                    if (Board[X, Y] != null)
                    {
                        return (false);
                    }
             
                }
                return (true);
            }
            return false;
        }
    }
}
