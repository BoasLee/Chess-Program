using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IMovementType
    {
        bool IsValidMove(ChessPiece piece, ChessPiece[,] Board, int X, int Y);
    }
}
