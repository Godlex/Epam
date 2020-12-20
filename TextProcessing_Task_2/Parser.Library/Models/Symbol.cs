namespace Parser.Library.Models
{
    public class Symbol
    {
        public char _char;

        public Symbol()
        {
            _char = new char();
        }

        public Symbol(char c)
        {
            _char = c;
        }

        public override string ToString()
        {
            return _char.ToString();
        }

        //гласная or нет
        //Upper case or lower 
    }
}