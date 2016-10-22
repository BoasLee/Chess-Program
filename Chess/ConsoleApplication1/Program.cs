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
        static public Pieces[,] Myboard = new Pieces[8, 8]; 
     
        static void Main(string[] args)
        {
            ClearBoard();
            Pieces pawn1 = new Pawn(1, 1, Color.White);
            Pieces pawn2 = new Pawn(0, 2, Color.Black);
            Myboard[1, 1] = pawn1;
            Myboard[0, 2] = pawn2;
            DisplayPawnCapture(pawn1, 0, 2); // how am i passing a sub class?
            Console.ReadKey();
        }

        static void ClearBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Myboard[i, j] = null;
                }
            }
        }
        static void DisplayBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Myboard[(j), (7-i)] == null)
                    {
                        System.Console.Write('a');
                    }
                    else
                    {
                        System.Console.Write(Myboard[(j),(7-i)].GetPiecetype());
                    }
                }
                System.Console.WriteLine();
            }
        }
        static void DisplayPawnMove(Pieces pawn, int X, int Y)
        {
            DisplayBoard();
            if (pawn.Move(Myboard, X, Y) == true)
            {
                System.Console.WriteLine("Moved =)");
            }
            else
            {
                System.Console.WriteLine("Did not move =(");
            }
            DisplayBoard();
            System.Console.WriteLine();
        }
        static void DisplayPawnCapture(Pieces pawn, int X, int Y)
        {
            DisplayBoard();
            if (pawn.Capture(Myboard, X, Y) == true)
            {
                System.Console.WriteLine("Killed you =P");
            }
            else
            {
                System.Console.WriteLine("Silly Rabbit, Tricks are for Kids");
            }
            DisplayBoard();
            System.Console.WriteLine();
        }        
    }
}
