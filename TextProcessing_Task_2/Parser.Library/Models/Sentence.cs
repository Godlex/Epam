namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Sentence : ISentence, IEnumerable<SentenceItem>
    {
        private readonly IList<SentenceItem> _sentenceItems;

        public Sentence()
        {
            _sentenceItems = new List<SentenceItem>();
        }

        public Sentence(IList<SentenceItem> sentenceItems)
        {
            _sentenceItems = new List<SentenceItem>();
            foreach (var item in sentenceItems)
            {
                _sentenceItems.Add(item);
            }
        }


        public IEnumerator<SentenceItem> GetEnumerator()
        {
            return _sentenceItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in _sentenceItems)
            {
                builder.Append(item);
            }

            return builder.ToString();
        }

        //проверка на вопросительное 
        //getwordcount
        //getwordbylength
        //deletewordbyleght
        //ReplaceWordByLength
    }
}