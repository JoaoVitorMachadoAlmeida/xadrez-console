namespace board
{
    public class Position
    {
        public int Line{get;set;}
        public int Columm{get;set;}

        public Position(int line, int columm)
        {
            Line = line;
            Columm = columm;
        }

        public override string ToString()
        {
            return Line
            + ", "
            + Columm;
        }
    }
}