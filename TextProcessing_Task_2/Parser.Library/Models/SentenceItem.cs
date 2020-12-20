namespace Parser.Library.Models
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class SentenceItem : ISentenceItem
    {
        public IList<Symbol> Symbols;

        public SentenceItem()
        {
            Symbols = new List<Symbol>();
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