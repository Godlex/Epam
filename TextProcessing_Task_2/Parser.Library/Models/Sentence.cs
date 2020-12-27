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

        public int GetWordCount
        {
            get
            {
                int count = 0;
                foreach (var sentenceItem in _sentenceItems)
                {
                    if (sentenceItem is Word)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public IEnumerable<SentenceItem> GetUniqueWordByLenght(int wordLenght)
        {
            HashSet<SentenceItem> words = new HashSet<SentenceItem>();
            foreach (var sentenceItem in _sentenceItems)
            {
                if (sentenceItem is Word && sentenceItem.Lenght == wordLenght)
                {
                    words.Add(sentenceItem);
                }
            }

            return words;
        }

        public bool IsQuestions()
        {
            if (_sentenceItems[_sentenceItems.Count].ToString().Equals("?"))
            {
                return true;
            }

            return false;
        }

        public void DeleteWordByLenghtBeginningByConsonant(int wordLenght)
        {
            foreach (var sentenceItem in _sentenceItems)
            {
                if (sentenceItem is Word && sentenceItem.Lenght == wordLenght && sentenceItem.IsBeginningByConsonant())
                {
                    _sentenceItems.Remove(sentenceItem);
                }
            }
        }

        public void ReplaceWordBySubstring(int wordLenght, string subString)
        {
            Word newWord = new Word(subString);
            for (int i = 0; i < _sentenceItems.Count; i++)
            {
                if (_sentenceItems[i] is Word && _sentenceItems[i].Lenght == wordLenght)
                {
                    _sentenceItems[i] = newWord;
                }
            }
        }

//getReplaceWordByLength +-
    }
}