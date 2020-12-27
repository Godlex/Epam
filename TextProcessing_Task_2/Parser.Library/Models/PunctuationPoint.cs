namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class PunctuationPoint : SentenceItem, IPunctuationPoint
    {
        public PunctuationPoint(string s) : base(s)
        {
        }
    }
}