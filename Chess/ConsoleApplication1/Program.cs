using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        // "Global Variable"
        static public ChessPiece[,] Myboard = new ChessPiece[8, 8];
        static Color Turn = Color.White; 
        static List<ChessPiece> WhiteRook = new List<ChessPiece>();
        static List<ChessPiece> WhiteKnight = new List<ChessPiece>();
        static List<ChessPiece> WhiteBishop = new List<ChessPiece>();
        static List<ChessPiece> WhiteKing = new List<ChessPiece>();
        static List<ChessPiece> WhiteQueen = new List<ChessPiece>();
        static List<ChessPiece> WhitePawn = new List<ChessPiece>();
        static List<ChessPiece> BlackRook = new List<ChessPiece>();
        static List<ChessPiece> BlackKnight = new List<ChessPiece>();
        static List<ChessPiece> BlackBishop = new List<ChessPiece>();
        static List<ChessPiece> BlackKing = new List<ChessPiece>();
        static List<ChessPiece> BlackQueen = new List<ChessPiece>();
        static List<ChessPiece> BlackPawn = new List<ChessPiece>();
        static List<ChessPiece> PossiblePieces = new List<ChessPiece>();
        static Dictionary<ChessPieceType, List<ChessPiece>> WhitePieces = new Dictionary<ChessPieceType, List<ChessPiece>>();
        static Dictionary<ChessPieceType, List<ChessPiece>> BlackPieces = new Dictionary<ChessPieceType, List<ChessPiece>>();


        static void Main(string[] args)
        {
            String Move = "e4";
            AddLists();
            NewGame();
            while (Move.ToLower() != "resign")
            {
                DisplayBoard();
                Console.Write("Please enter a move for " + EnumAndColor(Turn) + ":");
                Move = Console.ReadLine();
                if (MakeMove(Move))
                {
                    ChangeTurn();
                }
                DisplayList(ChessPieceType.P, Color.White);
                Console.WriteLine();
            }
        }

        //Public Functions
        public static void DisplayBoard() // not dynamic, will change later =P
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7 - i)] == null)
                    {
                        System.Console.Write('-');
                    }
                    else
                    {
                        if (Myboard[(j), (7 - i)].GetColor() == Color.White)
                        {
                           
                            System.Console.Write(char.ToUpper(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                        }
                        else
                        {
                           System.Console.Write(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype()));
                        }
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static void NewGame()
        {
            ClearBoard();
            ClearPieces();
            AddStartingPieces();
        }
        public static void DisplayMovementPossablilty(ChessPiece Piece)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7 - i)] != null)
                    {
                        if (Myboard[(j), (7 - i)].GetColor() == Color.White)
                        {
                            System.Console.Write(char.ToUpper(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                        }
                        else
                        {
                            System.Console.Write(char.ToLower(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                        }
                    }
                    else
                    {
                        if (Piece.CheckMove(Myboard, j, (7 - i)))
                        {
                            System.Console.Write('O');
                        }
                        else
                        {
                            System.Console.Write('-');
                        }
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static void DisplayMovementPossablilty(ChessPieceType PieceType, Color color)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7 - i)] != null)
                    {
                        if (Myboard[(j), (7 - i)].GetColor() == Color.White)
                        {
                            System.Console.Write(char.ToUpper(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                        }
                        else
                        {
                            System.Console.Write(char.ToLower(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                        }
                    }
                    else
                    {
                        if (CheckPieceMovement(PieceType, color, j, (7 - i)))
                        {
                            System.Console.Write('O');
                        }
                        else
                        {
                            System.Console.Write('-');
                        }
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static void DisplayCapturePossability(ChessPiece Piece)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7 - i)] != null)
                    {
                        if (Piece.CheckCapture(Myboard, j, (7 - i)))
                        {
                            System.Console.Write('O');
                        }
                        else
                        {
                            if (Myboard[(j), (7 - i)].GetColor() == Color.White)
                            {
                                System.Console.Write(char.ToUpper(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                            }
                            else
                            {
                                System.Console.Write(char.ToLower(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                            }
                        }
                    }
                    else
                    {
                        System.Console.Write('-');
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static void DisplayCapturePossability(ChessPieceType PieceType, Color color)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7 - i)] != null)
                    {
                        if (CheckPieceCapture(PieceType, color, j, (7 - i)))
                        {
                            System.Console.Write('O');
                        }
                        else
                        {
                            if (Myboard[(j), (7 - i)].GetColor() == Color.White)
                            {
                                System.Console.Write(char.ToUpper(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                            }
                            else
                            {
                                System.Console.Write(char.ToLower(EnumAndPiece(Myboard[(j), (7 - i)].GetPiecetype())));
                            }
                        }
                    }
                    else
                    {
                        System.Console.Write('-');
                    }
                }
                System.Console.WriteLine();
            }
        }
        public static bool MakeMove(string Move)
        {
            if (Move.Contains("X") || Move.Contains("x"))
            {
                return (Capture(Move));
            }
            else
            {
                return (Movement(Move));
            }
        }

        // Functions to use.
        private static void ClearBoard() 
        {
            for (int i = 0; i < Myboard.GetLength(0); i++)
            {
                for (int j = 0; j < Myboard.GetLength(1); j++)
                {
                    Myboard[i, j] = null;
                }
            }
        }
        private static void AddStartingPieces()
        {
            //Adding White Pieces
            AddRandomPiece(ChessPieceType.R, 0, 0, Color.White);
            AddRandomPiece(ChessPieceType.R, 7, 0, Color.White);
            AddRandomPiece(ChessPieceType.N, 1, 0, Color.White);
            AddRandomPiece(ChessPieceType.N, 6, 0, Color.White);
            AddRandomPiece(ChessPieceType.B, 2, 0, Color.White);
            AddRandomPiece(ChessPieceType.B, 5, 0, Color.White);
            AddRandomPiece(ChessPieceType.Q, 3, 0, Color.White);
            AddRandomPiece(ChessPieceType.K, 4, 0, Color.White);
            AddRandomPiece(ChessPieceType.P, 0, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 1, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 2, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 3, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 4, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 5, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 6, 1, Color.White);
            AddRandomPiece(ChessPieceType.P, 7, 1, Color.White);
 


            //Adding Black Pieces
            AddRandomPiece(ChessPieceType.R, 0, 7, Color.Black);
            AddRandomPiece(ChessPieceType.R, 7, 7, Color.Black);
            AddRandomPiece(ChessPieceType.N, 1, 7, Color.Black);
            AddRandomPiece(ChessPieceType.N, 6, 7, Color.Black);
            AddRandomPiece(ChessPieceType.B, 2, 7, Color.Black);
            AddRandomPiece(ChessPieceType.B, 5, 7, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 3, 7, Color.Black);
            AddRandomPiece(ChessPieceType.K, 4, 7, Color.Black);
            AddRandomPiece(ChessPieceType.P, 0, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 1, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 2, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 3, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 4, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 5, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 6, 6, Color.Black);
            AddRandomPiece(ChessPieceType.P, 7, 6, Color.Black);

            
            AddRandomPiece(ChessPieceType.Q, 0, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 1, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 2, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 3, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 4, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 5, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 6, 2, Color.Black);
            AddRandomPiece(ChessPieceType.Q, 7, 2, Color.Black);
        }
        private static void ClearPieces()
        {
            WhitePieces[ChessPieceType.R].Clear();
            WhitePieces[ChessPieceType.N].Clear();
            WhitePieces[ChessPieceType.B].Clear();
            WhitePieces[ChessPieceType.K].Clear();
            WhitePieces[ChessPieceType.Q].Clear();
            WhitePieces[ChessPieceType.P].Clear();
            BlackPieces[ChessPieceType.R].Clear();
            BlackPieces[ChessPieceType.N].Clear();
            BlackPieces[ChessPieceType.B].Clear();
            BlackPieces[ChessPieceType.K].Clear();
            BlackPieces[ChessPieceType.Q].Clear();
            BlackPieces[ChessPieceType.P].Clear();
        }
        private static void AddLists() //Adding lists to dictionary. 
        {            
        	List<ChessPiece> mypointer = new List<ChessPiece>();
        	
        	WhitePieces.Add(ChessPieceType.K, mypointer);
        	
            WhitePieces.Add(ChessPieceType.R, new List<ChessPiece>());
            WhitePieces.Add(ChessPieceType.K, new List<ChessPiece>());
            WhitePieces.Add(ChessPieceType.N, new List<ChessPiece>());
            WhitePieces.Add(ChessPieceType.B, new List<ChessPiece>());
            WhitePieces.Add(ChessPieceType.Q, new List<ChessPiece>());
            WhitePieces.Add(ChessPieceType.P, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.R, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.K, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.N, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.B, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.Q, new List<ChessPiece>());
            BlackPieces.Add(ChessPieceType.P, new List<ChessPiece>());
        }
        public static void DisplayList(ChessPieceType ChessPiece, Color color)
        {
            if (Color.White == color)
            {
                foreach (ChessPiece Piece in WhitePieces[ChessPiece])
                {
                    Console.Write(Piece.GetX());
                    Console.Write(Piece.GetY());
                    Console.WriteLine();
                }
            }
            else
            {
                foreach (ChessPiece Piece in BlackPieces[ChessPiece])
                {
                    Console.Write(Piece.GetX());
                    Console.Write(Piece.GetY());
                    Console.WriteLine();
                }
            }
        }
        private static bool CheckPieceMovement(ChessPieceType PieceType, Color color, int X, int Y)
        {
            PossiblePieces.Clear();
            if (Color.White == color)
            {
                foreach (ChessPiece Piece in WhitePieces[PieceType])
                {
                    if (Piece.CheckMove(Myboard, X, Y))
                    {
                        PossiblePieces.Add(Piece);
                    }
                }
            }
            else
            {
                foreach (ChessPiece Piece in BlackPieces[PieceType])
                {
                    if (Piece.CheckMove(Myboard, X, Y))
                    {
                        PossiblePieces.Add(Piece);
                    }
                }
            }
            if (PossiblePieces.Count() == 0)
            {
                return (false);
            }
            else
            {
                return (true);
            } 
        }
        private static bool CheckPieceCapture(ChessPieceType PieceType, Color color, int X, int Y)
        {
            PossiblePieces.Clear();
            if (Color.White == color)
            {
                foreach (ChessPiece Piece in WhitePieces[PieceType])
                {
                    if (Piece.CheckCapture(Myboard, X, Y))
                    {
                        PossiblePieces.Add(Piece);
                    }
                }
            }
            else
            {
                foreach (ChessPiece Piece in BlackPieces[PieceType])
                {
                    if (Piece.CheckCapture(Myboard, X, Y))
                    {
                        PossiblePieces.Add(Piece);
                    }
                }
            }
            if (PossiblePieces.Count() == 0)
            {
                Console.WriteLine("Check Piece Capture in main failed");
                return (false);
            }
            else
            {
                return (true);
            }
        }
        private static void FillBoard()
        {
            ChessPiece pawn = new Pawn(0, 0, Color.Black);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Myboard[i, j] = pawn;
                }
            }
        }// Creates board filled with all black pawns for testing
        private static ChessPiece AddRandomPiece(ChessPieceType PieceType)
        {
            int X, Y;
            System.Random RandNum = new System.Random();
            X = RandNum.Next(0, Myboard.GetLength(0));
            Y = RandNum.Next(0, Myboard.GetLength(1));
            return (AddRandomPiece(PieceType, X, Y, Color.White));
        }
        private static ChessPiece AddRandomPiece(ChessPieceType PieceType, int X, int Y, Color color)
        {
            switch (PieceType)
            {
                case ChessPieceType.P:
                {
                    ChessPiece piece = new Pawn(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                       BlackPieces[ChessPieceType.P].Add(piece);
                    }
                    else
                    {
                       WhitePieces[ChessPieceType.P].Add(piece);
                    }
                    return (piece);
                }
                case ChessPieceType.B:
                {
                    ChessPiece piece = new Bishop(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                        BlackPieces[ChessPieceType.B].Add(piece);
                    }
                    else
                    {
                        WhitePieces[ChessPieceType.B].Add(piece);
                    }
                    return (piece);
                }
                case ChessPieceType.Q:
                {
                    ChessPiece piece = new Queen(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                        BlackPieces[ChessPieceType.Q].Add(piece);
                    }
                    else
                    {
                        WhitePieces[ChessPieceType.Q].Add(piece);
                    }
                    return (piece);
                }
                case ChessPieceType.K:
                {
                    ChessPiece piece = new King(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                        BlackPieces[ChessPieceType.K].Add(piece);
                    }
                    else
                    {
                        WhitePieces[ChessPieceType.K].Add(piece);
                    }
                    return (piece);
                }
                case ChessPieceType.R:
                {
                    ChessPiece piece = new Rook(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                        BlackPieces[ChessPieceType.R].Add(piece);
                    }
                    else
                    {
                        WhitePieces[ChessPieceType.R].Add(piece);
                    }
                    return (piece);
                }
                case ChessPieceType.N:
                {
                    ChessPiece piece = new Knight(X, Y, color);
                    Myboard[X, Y] = piece;
                    if (color == Color.Black)
                    {
                        BlackPieces[ChessPieceType.N].Add(piece);
                    }
                    else
                    {
                        WhitePieces[ChessPieceType.N].Add(piece);
                    }
                    return (piece);
                }
                default:
                {
                    return (null);
                }
            }
        }
        private static void UpdateBoard(ChessPiece Piece, int X, int Y)
        {
            Myboard[Piece.GetX(), Piece.GetY()] = null;
            Myboard[X, Y] = Piece;
            Piece.SetX(X);
            Piece.SetY(Y);
            Piece.IncreaseNumberOfMoves();
        }
        private static void ChangeTurn()
        {
            if (Turn == Color.Black)
            {
                Turn = Color.White;
            }
            else
            {
                Turn = Color.Black;
            }
        }
        private static void UpdateList(int X, int Y)
        {
            ChessPiece PieceDeleted = Myboard[X, Y];
            if (Color.Black == PieceDeleted.GetColor())
            {
                BlackPieces[PieceDeleted.GetPiecetype()].Remove(PieceDeleted);
                Console.WriteLine("Deleting a Black piece");
            }
            else
            {
                WhitePieces[PieceDeleted.GetPiecetype()].Remove(PieceDeleted);
                Console.WriteLine("Deleting a white piece");
            }
        }
        private static bool Movement(string Move)
        {
            ChessPieceType PieceType;
            int SpecificLocation, X, Y;
            ReadUserInput(Move, out PieceType, out SpecificLocation, out X, out Y);
            CheckPieceMovement(PieceType, Turn, X, Y);
            if (PossiblePieces.Count() == 1)
            {
                UpdateBoard(PossiblePieces.First(), X, Y);
                return (true);
            }
            return (false);
        }
        private static bool Capture(string Move)
        {
            ChessPieceType PieceType;
            int SpecificLocation, X, Y;
            ReadUserInput(Move, out PieceType, out SpecificLocation, out X, out Y);
            CheckPieceCapture(PieceType, Turn, X, Y);
            if (PossiblePieces.Count() == 1)
            {
                UpdateList(X, Y);
                UpdateBoard(PossiblePieces.First(), X, Y);
                return (true);
            }
            return (false);
        }

        // Input Maniupuation functions
        private static void ReadMove(string Move, out ChessPieceType PieceType, out int X, out int Y) // Piece Move 
        {
            PieceType = EnumAndPiece(char.ToLower(Move[0]));
            ReadMove(Move.Remove(0, 1), out X, out Y);
        }
        private static void ReadMove(string Move, out ChessPieceType PieceType, out int SpecificLocation, out int X, out int Y) // Specific Piece Move 
        {
            ReadMove(Move.Remove(1, 1), out PieceType, out X, out Y);
            SpecificLocation = Convert.ToByte(Move[1]);
            SpecificLocation -= 97; // subtracting 96 to get to 1 then another 1 to start at 0
        }
        private static void ReadMove(string Move, out int X, out int Y) // Pawn move
        {
            X = Convert.ToByte(Move[0]);
            X -= 97; // subtracting 96 to get to 1 then another 1 to start at 0
            Y = Int32.Parse(char.ToString(Move[1]));
            Y -= 1;
        }
        private static void ReadCapture(string Move, out int X, out int Y) // pawn capture
        {
            ReadMove(Move.Remove(0, 1), out X, out Y);
        }
        private static void ReadCapture(string Move, out ChessPieceType PieceType, out int X, out int Y)
        {
            if (char.IsLower(Move[0]))
            {
                PieceType = ChessPieceType.P;
            }
            else
            {
                PieceType = EnumAndPiece(char.ToLower(Move[0]));
            }
            ReadMove(Move.Remove(0, 2), out X, out Y);
        } //Specific pawn or piece capture
        private static void ReadCapture(string Move, out ChessPieceType PieceType, out int SpecificLocation, out int X, out int Y)
        {
            SpecificLocation = Convert.ToByte(Move[1]);
            SpecificLocation -= 97;
            ReadCapture(Move.Remove(1, 1), out PieceType, out X, out Y);
        } // specific piece capture
        private static void DeleteSpaces(ref string Move)
        {
            Move = Move.Replace(" ","" );
            Move = Move.Replace("  ","");
        }
        private static void ReadUserInput(string Move, out ChessPieceType PieceType, out int SpecificLocation, out int X, out int Y)
        {
            DeleteSpaces(ref Move);
            if (Move.Contains("X") || Move.Contains("x"))
            {
                switch (Move.Length)
                {
                    case 3:
                    {
                        PieceType = ChessPieceType.P;
                        SpecificLocation = -1;
                        ReadCapture(Move, out X, out Y);
                        break;
                    }
                    case 4:
                    {
                        SpecificLocation = -1;
                        ReadCapture(Move, out PieceType, out X, out Y);
                        break;
                    }
                    case 5:
                    { 
                        ReadCapture(Move,out PieceType, out SpecificLocation, out X, out Y);
                        break;
                    }
                    default:
                    {
                        PieceType = ChessPieceType.u; 
                        SpecificLocation = -1;
                        X = -1;
                        Y = -1;
                        break;
                    }
                }
            }
            else
            {
                switch (Move.Length)
                {
                    case 2:
                    {
                        PieceType = ChessPieceType.P;
                        SpecificLocation = -1;
                        ReadMove(Move, out X, out Y);
                        break;
                    }
                    case 3:
                    {
                        SpecificLocation = -1;
                        ReadMove(Move, out PieceType, out X, out Y);
                        break;
                    }
                    case 4:
                    {
                        ReadMove(Move, out PieceType, out SpecificLocation, out X, out Y);
                        break;
                    }
                    default:
                    {
                        PieceType = ChessPieceType.u;
                        SpecificLocation = -1;
                        X = -1;
                        Y = -1;
                        break;
                    }
                }
            }
        }
        private static void DisplayInput(string Move)
        {
            ChessPieceType PieceType;
            int X, Y, SpecificLocation;
            ReadUserInput(Move, out PieceType, out SpecificLocation, out X, out Y);
            Console.WriteLine(EnumAndPiece(PieceType));
            Console.WriteLine(SpecificLocation);
            Console.WriteLine(X);
            Console.WriteLine(Y);
        }

        //Enum Manipulation
        private static char EnumAndPiece(ChessPieceType PieceType) 
        {
            switch (PieceType)
            {
                case ChessPieceType.P:
                {
                    return ('p');
                }
                case ChessPieceType.B:
                {
                    return ('b');
                }

                case ChessPieceType.Q:
                {
                    return ('q');
                }
                case ChessPieceType.K:
                {
                    return ('k');
                }
                case ChessPieceType.R:
                {
                    return ('r');
                }
                case ChessPieceType.N:
                {
                    return ('n');
                }
                default:
                {
                    return ('u');
                }
            }
        }
        private static ChessPieceType EnumAndPiece( char PieceType)
        {
            switch (PieceType)
            {
                case 'p':
                    {
                        return (ChessPieceType.P);
                    }
                case 'b':
                    {
                        return (ChessPieceType.B);
                    }

                case 'q':
                    {
                        return (ChessPieceType.Q);
                    }
                case 'k':
                    {
                        return (ChessPieceType.K);
                    }
                case 'r':
                    {
                        return (ChessPieceType.R);
                    }
                case 'n':
                    {
                        return (ChessPieceType.N);
                    }
                default:
                    {
                        return (ChessPieceType.u);
                    }
            }
        }
        private static string EnumAndColor(Color color)
        {
            if (color == Color.Black)
            {
                return ("Black");
            }
            else
            {
                return ("White");
            }
        }
    }
}