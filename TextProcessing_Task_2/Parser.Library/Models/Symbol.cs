namespace Parser.Library.Models
{
    using System;
    using System.Linq;
    using Constant;

    public class Symbol
    {
        public char Value { get; private set; }

        public Symbol()
        {
        }

        public Symbol(char value)
        {
            Value = value; 
        }

        public bool IsLower 
        {
            get
            {
                return Value.ToString().ToLower() == Value.ToString();
            }
        }

        public bool IsConsonant()
        {
            return Constants.Consonant.Contains(Char.ToLower(Value).ToString()); 
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        //гласная or нет
        //Upper case or lower 
    }
}