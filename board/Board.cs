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

        public Piece Pieces(Position pos)
        {
           return Piece[pos.Line,pos.Columm];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return Pieces(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if(ExistPiece(pos))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Piece[pos.Line, pos.Columm] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(Pieces(pos) == null)
            {
                return null;
            }
            Piece aux = Pieces(pos);
            aux.Position = null;
            Piece[pos.Line, pos.Columm] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Columm < 0 || pos.Columm >= Columms )
            {
               return false;
            }
             return true;
        }

        public void ValidatePosition(Position pos)
        {
            if(!ValidPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}