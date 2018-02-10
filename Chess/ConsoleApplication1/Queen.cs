using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Queen : ChessPiece
    {
        // Constructor
        public Queen(int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new RookMoveType());
            MovementList.Add(new BishopMoveType());
        }
        public Queen() : base()
        {
            MovementList.Add(new RookMoveType());
            MovementList.Add(new BishopMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.Q;
        }
    }
}
