using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BishopMoveType : IMovementType
    {
        public bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y)
        {
            int Xdiff, Ydiff, XMovement, YMovement;
            Xdiff = X - piece.GetX();
            Ydiff = Y - piece.GetY();

            if (Math.Abs(Xdiff) == Math.Abs(Ydiff)) // Verifies that the Bishop is moving the same amount in the X direction as the Y direction 
            {
                if (Xdiff > 0)
                {
                    XMovement = 1;
                }
                else
                {
                    XMovement = -1;
                }
                if (Ydiff > 0)
                {
                    YMovement = 1;
                }
                else
                {
                    YMovement = -1;
                }

                while ((Y - YMovement) != piece.GetY() && (X - XMovement) != piece.GetX())
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
