using board;

namespace xadrez_console
{
    public class Screen
    {
        public static void PrintScreen(Board board)
        {
            for(int i=0; i<board.Lines;i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j<board.Columms; j++)
                {
                    if(board.Pieces(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else{
                        PrintPiece(board.Pieces(i,j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}