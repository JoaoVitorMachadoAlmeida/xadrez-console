using System;
using board;
using xadrez_console;
using chess;
using System.Linq.Expressions;


class Program
{
    public static void Main()
    {
        try
        {
            Board board = new Board(8, 8);

            board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(0, 2));

            Screen.PrintScreen(board);

            Console.ReadLine();
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);

        }
    }
}


