using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
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