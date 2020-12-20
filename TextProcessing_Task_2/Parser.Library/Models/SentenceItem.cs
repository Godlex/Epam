namespace Parser.Library.Models
{
    using System.Collections.Generic;

    public abstract class SentenceItem : ISentenceItem
    {
        public IList<Symbol> _Symbols;
        
        
        public override string ToString()
        {
            string s = null;
            
            foreach (Symbol variable in _Symbols)
            {
                s += variable.ToString();
            }

            return s;
        }
    }
}