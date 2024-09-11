namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece GetPiece(int line, int column)
        {
            if (line < 0 || line >= Lines || column < 0 || column >= Columns)
            {
                throw new ArgumentOutOfRangeException("Position out of board bounds");
            }
            return Pieces[line, column];
        }

        public Piece GetPiece(Position pos)
        {
            return GetPiece(pos.Line, pos.Column);
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (ExistPiece(pos))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (GetPiece(pos) == null)
            {
                return null;
            }
            Piece aux = GetPiece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}