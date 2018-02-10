using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PawnMoveType : IMovementType
    {
        public bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y)
        {
            int Direction;
            if (piece.GetColor() == Color.White)
            {
                Direction = 1;
            }
            else
            {
                Direction = -1;
            }
            if ((piece.GetY() + Direction == Y ||
            (piece.GetNumberOfMoves() == 0 && piece.GetY() + (Direction * 2) == Y && Board[X, piece.GetY() + Direction] == null)) &&
            piece.GetX() == X)
            {
                return true;
            }
            return false;
        }
    }
}
