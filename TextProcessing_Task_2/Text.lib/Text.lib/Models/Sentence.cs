namespace Text.lib.Models
{
    using System.Collections.Generic;

    public class Sentence
    {
        private IList<SentenceItem> _sentenceItems;

        public Sentence()
        {
            _sentenceItems = new List<SentenceItem>();
        }
    }
}