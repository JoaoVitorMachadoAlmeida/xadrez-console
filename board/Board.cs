namespace board
{
    public class Board
    {
        public int Lines {get;set;}
        public int Columms {get;set;}
        private Piece[,] Piece;

        public Board(int lines, int columms)
        {
            Lines = lines;
            Columms = columms;
            Piece = new Piece[lines,columms];
        }
    }
}