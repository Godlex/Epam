namespace Parser.Library.Models
{
    using System;
    using System.Linq;
    using Constant;

    public class Symbol
    {
        public char Value { get; private set; }

        public Symbol(char value)
        {
            Value = value;
        }

        public bool IsConsonant()
        {
            return Constants.Consonant.Contains(Char.ToLower(Value).ToString());
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}