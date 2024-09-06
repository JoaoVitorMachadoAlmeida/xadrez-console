using board;

namespace chess
{
    public class ChessPosition
    {
        public char Columm {get;set;}
        public int Line {get;set;}

        public ChessPosition(char columm, int line)
        {
            Columm = columm;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Columm - 'a');
        }

        public override string ToString()
        {
            return "" + Columm + Line;
        }
    }
}