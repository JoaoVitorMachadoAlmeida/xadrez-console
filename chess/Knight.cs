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

    // Possible Knight moves (L-shape)

    // Move up-left
    pos.DefineValues(position.Line - 1, position.Column - 2);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move up-right
    pos.DefineValues(position.Line - 1, position.Column + 2);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move down-left
    pos.DefineValues(position.Line + 1, position.Column - 2);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move down-right
    pos.DefineValues(position.Line + 1, position.Column + 2);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move left-up
    pos.DefineValues(position.Line - 2, position.Column - 1);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move left-down
    pos.DefineValues(position.Line + 2, position.Column - 1);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move right-up
    pos.DefineValues(position.Line - 2, position.Column + 1);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    // Move right-down
    pos.DefineValues(position.Line + 2, position.Column + 1);
    if (board.ValidPosition(pos) && CanMove(pos))
    {
        mat[pos.Line, pos.Column] = true;
    }

    return mat;
        }
    }
}
