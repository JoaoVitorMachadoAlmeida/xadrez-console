using System;
using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.GetPiece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // above
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // below
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // right
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // left
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetPiece(pos) != null && Board.GetPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}