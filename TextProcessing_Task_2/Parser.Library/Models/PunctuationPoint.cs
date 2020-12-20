namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class PunctuationPoint : SentenceItem, IPunctuationPoint
    {
        public PunctuationPoint()
        {
            Symbols = new List<Symbol>();
        }
        
        public PunctuationPoint(string s)
        {
            foreach (char variable in s)
            {
                Symbol c = new Symbol(variable);
                Symbols.Add(c);
            }
            
        }
    }
}