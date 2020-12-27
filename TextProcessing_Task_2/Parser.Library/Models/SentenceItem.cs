namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public abstract class SentenceItem : ISentenceItem, IEnumerable<Symbol>
    {
        protected IList<Symbol> Symbols = new List<Symbol>();

        protected SentenceItem(string s)
        {
            foreach (char variable in s)
            {
                Symbol c = new Symbol(variable);
                Symbols.Add(c);
            }
        }

        public int Lenght => Symbols.Count;

        public IEnumerator<Symbol> GetEnumerator()
        {
            return Symbols.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsBeginningByConsonant()
        {
            return Symbols[0].IsConsonant();
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