using System.Collections.Generic;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;
        public bool Check { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMove(Position origin, Position destination)
        {
            Piece movingPiece = board.RemovePiece(origin);
            Piece capturedPiece = board.RemovePiece(destination);
            board.PutPiece(movingPiece, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            movingPiece.IncrementMoveCount();
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece movingPiece = board.RemovePiece(destination);
            movingPiece.DecrementMoveCount();
            if (capturedPiece != null)
            {
                board.PutPiece(capturedPiece, destination);
                capturedPieces.Remove(capturedPiece);
            }
            board.PutPiece(movingPiece, origin);
        }

        public void MakeMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(GetOpponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
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

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> GetPiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        private Color GetOpponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in GetPiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);
            if (king == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }

            foreach (Piece piece in GetPiecesInGame(GetOpponent(color)))
            {
                bool[,] possibleMoves = piece.PossibleMoves();
                if (possibleMoves[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {

            PutNewPiece('c', 1, new Tower(board, Color.White));
            PutNewPiece('c', 2, new Tower(board, Color.White));
            PutNewPiece('d', 2, new Tower(board, Color.White));
            PutNewPiece('e', 2, new Tower(board, Color.White));
            PutNewPiece('e', 1, new Tower(board, Color.White));
            PutNewPiece('d', 1, new King(board, Color.White));

            PutNewPiece('c', 7, new Tower(board, Color.Black));
            PutNewPiece('c', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 7, new Tower(board, Color.Black));
            PutNewPiece('e', 8, new Tower(board, Color.Black));
            PutNewPiece('d', 8, new King(board, Color.Black));
            
        }
    }
}