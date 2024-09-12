using System;
using board;
using xadrez_console;
using chess;

class Program
{
    public static void Main()
    {
        try
        {
            ChessGame game = new ChessGame();

            while (!game.Finished)
            {
                try
                {
                Console.Clear();
                Screen.PrintGame(game);
                

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Screen.ReadChessPosition().ToPosition();
                game.ValidateOriginPosition(origin);

                bool[,] possibleMoves = game.board.GetPiece(origin).PossibleMoves();

                Console.Clear();
                Screen.PrintScreen(game.board, possibleMoves);

                Console.WriteLine();
                Console.Write("Destination: ");
                Position destination = Screen.ReadChessPosition().ToPosition();
                game.ValidateDestinationPosition(origin, destination);

                game.MakeMove(origin, destination);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                }
            }
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }
}