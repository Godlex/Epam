namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Sentence : ISentence, IEnumerable<SentenceItem>
    {
        private IList<SentenceItem> _sentenceItems = new List<SentenceItem>();

        public Sentence(IList<SentenceItem> sentenceItems)
        {
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
                builder.Append(item.ToString());
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
            return _sentenceItems.Where(sentenceItem => sentenceItem is Word && sentenceItem.Lenght == wordLenght)
                .Distinct().ToList();
        }

        public bool IsQuestions()
        {
            return _sentenceItems[^1].ToString().Equals("?");
        }

        public void DeleteWordByLenghtBeginningByConsonant(int wordLenght)
        {
            _sentenceItems = _sentenceItems
                .Where(item => !(item is Word) || item.Lenght != wordLenght || !item.IsBeginningByConsonant()).ToList();
            /*foreach (var word in _sentenceItems.Where(item => !(item is Word && item.Lenght == wordLenght && item.IsBeginningByConsonant())).ToList())
            {
                
                if (_sentenceItems.IndexOf(word) != -1)
                {
                    int index = _sentenceItems.IndexOf(word);
                    _sentenceItems.RemoveAt(index);
                    if (index > 0)
                    {
                        _sentenceItems.RemoveAt(index - 1);
                    }
                }
            }*/

            // return _sentenceItems
            //     .Where(item => item is Word && item.Lenght == wordLenght && item.IsBeginningByConsonant()).ToList();
        }

        public void ReplaceWordBySubstring(int wordLenght, string subString)
        {
            _sentenceItems =
                _sentenceItems.Select(item => item is Word && item.Lenght == wordLenght ? new Word(subString) : item)
                    .ToList();
            /*return _sentenceItems.Select(item => item is Word && item.Lenght == wordLenght ? new Word(subString) : item)
                .ToList();*/
        }
    }
}