namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Word : SentenceItem, IWord
    {
        private IList<Symbol> _symbols;
        
        public Word(string s)
        {
            foreach (char variable in s)
            {
                Symbol c = new Symbol(variable);
                _symbols.Add(c);
            }

            //get legth
            ////гласная
        }
    }
}