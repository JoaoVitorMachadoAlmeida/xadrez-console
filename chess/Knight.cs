using System;
using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "N"; 
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

       public override bool[,] PossibleMoves()
        {
    bool[,] mat = new bool[board.Lines, board.Columns];

        Position pos = new Position(0, 0);

        pos.SetValues(Position.Line - 1, Position.Column - 2);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line - 2, Position.Column - 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line - 2, Position.Column + 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line - 1, Position.Column + 2);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 1, Position.Column + 2);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 2, Position.Column + 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 2, Position.Column - 1);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        pos.SetValues(Position.Line + 1, Position.Column - 2);
        if (Board.ValidPosition(pos) && CanMove(pos))
        {
            mat[pos.Line, pos.Column] = true;
        }

        return mat;
        }
    }
}
