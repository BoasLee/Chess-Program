using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    enum Color { White, Black };
 

    abstract class Pieces
    {

        // My constructor
        public Pieces(int X, int Y, Color Color)
        {
            this.X = X;
            this.Y = Y;
            NumberOfMoves = 0;
            this.PieceColor = Color;
        }

        //My methods
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public int GetNumberOfMoves()
        {
            return NumberOfMoves;
        }
        public Color GetColor()
        {
            return PieceColor;
        }
        public abstract bool Move(Pieces[,] _Board, int X, int Y);
        public abstract bool Capture(Pieces[,] _Board, int X, int Y);
        public abstract char GetPiecetype();

        //My attributes  
        protected int X;
        protected int Y;
        protected Color PieceColor;
        protected int NumberOfMoves;


    }
}