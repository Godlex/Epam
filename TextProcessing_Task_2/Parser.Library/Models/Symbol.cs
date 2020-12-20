namespace Parser.Library.Models
{
    using System;

    public class Symbol
    {
        public char Value { get; set; }

        public Symbol()
        {
        }

        public Symbol(char value)
        {
            Value = value;
        }

        public bool IsUpper 
        {
            get
            {
                if (Value.ToString().ToLower() == Value.ToString())
                {
                    return false;
                }
                return true;
            }
        }
        
        public override string ToString()
        {
            return Value+"";
        }
        //гласная or нет
        //Upper case or lower 
    }
}