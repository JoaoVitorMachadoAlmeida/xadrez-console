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

        public Piece Pieces(int line, int columm)
        {
           return Piece[line,columm];
        }

        public void PutPiece(Piece p, Position pos)
        {
            Piece[pos.Line, pos.Columm] = p;
            p.Position = pos;
        }
    }
}