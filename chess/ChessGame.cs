using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMove(Position origin, Position destination)
        {
            Piece capturedPiece = board.RemovePiece(origin);
            capturedPiece.IncrementMoveCount();
            Piece piece = board.RemovePiece(destination);
            board.PutPiece(capturedPiece, destination);
        }

        public void MakeMove(Position origin, Position destination)
        {
            ExecuteMove(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if (board.GetPiece(position) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }

            if (CurrentPlayer != board.GetPiece(position).Color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }

            if (!board.GetPiece(position).IsTherePossibleMove())
            {
                throw new BoardException("There are no possible moves for the chosen piece!");
            }
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!board.GetPiece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destination position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPieces()
        {
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());

            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}