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
                Console.Clear();
                Screen.PrintScreen(game.board);

                Console.WriteLine();
                Console.Write("Origin: ");
                Position origin = Screen.ReadChessPosition().ToPosition();

                bool[,] possibleMoves = game.board.GetPiece(origin).PossibleMoves();

                Console.Clear();
                Screen.PrintScreen(game.board, possibleMoves);

                Console.Write("Destination: ");
                Position destination = Screen.ReadChessPosition().ToPosition();

                game.ExecuteMove(origin, destination);
            }
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }
}