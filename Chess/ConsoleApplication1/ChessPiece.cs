using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{    
    enum Color { White, Black, u};
    enum ChessPieceType { R, B, N, Q, K, P, u};

    abstract class ChessPiece
    {
        // My constructor
        public ChessPiece(int X, int Y, Color Color)
        {
            this.X = X;
            this.Y = Y;
            this.NumberOfMoves = 0;
            this.PieceColor = Color;
            this.MovementList = new List<IMovementType>();
        }
        public ChessPiece()
        {
            this.X = 0;
            this.Y = 0;
            this.NumberOfMoves = 0;
            this.PieceColor = Color.White;
            this.MovementList = new List<IMovementType>();
        }

        //My Public methods
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public void SetX(int X)
        {
            this.X = X;
        }
        public void SetY(int Y)
        {
            this.Y = Y;
        }
        public int GetNumberOfMoves()
        {
            return NumberOfMoves;
        }
        public void IncreaseNumberOfMoves()
        {
            NumberOfMoves++;
        }
        public Color GetColor()
        {
            return PieceColor;
        }
        public bool CheckMove(ChessPiece[,] Board, int X, int Y)
        {
            if (CheckBoardLimits(Board, X, Y) &&
                CheckDestinationMovement(Board, X, Y) &&
                GetDestinationValue(Board, X, Y) &&
                CheckMoveTypes(Board, X, Y))
            {
                return (true);
            }
            return (false);
        }
        public virtual bool CheckCapture(ChessPiece[,] Board, int X, int Y)
        {
            if (CheckBoardLimits(Board, X, Y) &&
                CheckDestinationMovement(Board, X, Y) &&
                GetDestinationValue(Board, X, Y) == false &&
                Board[X, Y].GetColor() != this.PieceColor &&
                CheckMoveTypes(Board, X, Y))
            {
                return (true);
            }
            return (false);
        }

        // My Protected Methods
        private bool CheckMoveTypes(ChessPiece[,] Board, int X, int Y)
        {
            foreach (IMovementType moveType in MovementList)
            {
                if (moveType.IsValidMove(this, Board, X, Y))
                {
                    return true;
                }
            }
            return false;
        }
        private bool GetDestinationValue(ChessPiece[,] Board, int X, int Y)
        {
            if (Board[X, Y] == null)
            {
                return (true);
            }
            return (false);
        } // Checks if the destination square is null (returns true if it's null)
        private bool CheckDestinationMovement(ChessPiece[,] Board, int X, int Y)
        {
            if (this.X == X && this.Y == Y)
            {
                return (false);
            }
            return (true);
        } // Check if the destination is not the same square where the piece is currently at.
        private  bool CheckBoardLimits(ChessPiece[,] Board, int X, int Y)
        {
            if (Board.GetLength(0) > X && Board.GetLength(1) > Y)
            {
                return (true);
            }
            return (false);
        } // Checks that the destination is within the limitation of the board size
 
      
        // My Protected Methods that need a "override" function.
        public abstract ChessPieceType GetPiecetype();

        //My attributes  
        protected int X;
        protected int Y;
        protected Color PieceColor;
        protected int NumberOfMoves;
        protected List<IMovementType> MovementList;
    }
}