using board;

namespace xadrez_console
{
    public class Screen
    {
        public static void PrintScreen(Board board)
        {
            for(int i=0; i<board.Lines;i++)
            {
                for(int j=0; j<board.Columms; j++)
                {
                    if(board.Pieces(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else{
                        Console.Write(board.Pieces(i,j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}