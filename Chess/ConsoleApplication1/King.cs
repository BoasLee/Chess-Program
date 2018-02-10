using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class King : ChessPiece
    {
        // Constructor
        public King (int X, int Y, Color color) : base(X, Y, color)
        {
            MovementList.Add(new KingpMoveType());
        }
        public King() : base()
        {
            MovementList.Add(new KingpMoveType());
        }

        // Method
        public override ChessPieceType GetPiecetype()
        {
            return ChessPieceType.K;
        }

        // Need to implement ischeck
        public bool IsCheck(ChessPiece[,] Board)
        {
            return true;
        } 
        private bool IsCheck(ChessPiece[,] Board, int X, int Y)
        {
            return true;
        } 
    }
}
