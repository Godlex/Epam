namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;

    public class Text : IText, IEnumerable<Sentence>
    {
        private readonly IList<Sentence> _sentences;

        public Text()
        {
            _sentences = new List<Sentence>();
        }
        public Text(IList<Sentence> sentence)
        {
            _sentences = sentence;
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return _sentences.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Sentence sentence)
        {
            _sentences.Add(sentence);
        }

        public IList<Sentence> GetSortedSentenceByWordCount()
        {
            var newSentencesList = _sentences.OrderBy(x => x.GetWordCount).ToList();
            return newSentencesList;
        }
        
        public IEnumerable<SentenceItem> GetUniqueWordByWordLenghtForQuestions(int wordLenght)
        {
            IList<SentenceItem> words = new List<SentenceItem>();
            foreach (var sentence in _sentences)
            {
                if (sentence.IsQuestions())
                {
                    words = new List<SentenceItem>(wordLenght);
                }
            }
            return words;
        }

        public void DeleteWordByLenghtBeginningByConsonant(int wordLenght)
        {
            foreach (var sentence in _sentences)
            {
                sentence.DeleteWordByLenghtBeginningByConsonant(wordLenght);
            }
        }

        public void ReplaceWordBySubstringOnSentence(int sentenceNumber, int wordLenght, string subString)
        {
            _sentences[sentenceNumber].ReplaceWordBySubstring(wordLenght,subString);
        }
        //GetSortedSentenceByWordCount +
        //GetWordByWordLenghtForQautions +-
        //Delete +-
        //Replace   
    }
}