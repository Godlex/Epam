namespace Parser.Library.Models
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class SentenceItem : ISentenceItem 
    {
        protected IList<Symbol> Symbols;

        protected SentenceItem()
        {
            Symbols = new List<Symbol>();
        }

        protected SentenceItem(string s)
        {
            foreach (char variable in s)
            {
                Symbol c = new Symbol(variable);
                Symbols.Add(c);
            }
        }
        public override string ToString()
        { 
            StringBuilder builder = new StringBuilder();
            foreach (var item in Symbols)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
    }
}