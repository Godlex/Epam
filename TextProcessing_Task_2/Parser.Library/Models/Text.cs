namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Text : IText, IEnumerable<Sentence>
    {
        private IList<Sentence> _sentences;

        public Text()
        {
            _sentences = new List<Sentence>();
        }
        public IEnumerator<Sentence> GetEnumerator()
        {
            return _sentences.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Text(IList<Sentence> sentence)
        {
            _sentences = sentence;
        }
        
        //GetSortedSentenceByWordCount
        //GetWordByWordLenghtForQautions
        //Delete
        //Replace       
        
    }
}