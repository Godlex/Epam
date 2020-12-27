namespace Parser.Library.Models
{
    using System.Collections.Generic;

    public class Word : SentenceItem, IWord
    {
        public Word() : base()
        {
            Symbols = new List<Symbol>();
        }

        public Word(string s) : base(s)
        {
        }

        
        //get legth
        //гласная
    }
}