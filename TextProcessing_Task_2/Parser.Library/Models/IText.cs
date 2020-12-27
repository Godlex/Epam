namespace Parser.Library.Models
{
    using System.Collections.Generic;

    public interface IText
    {
        public void Add(Sentence sentence);
        public IList<Sentence> GetSortedSentenceByWordCount();
        public IEnumerable<SentenceItem> GetUniqueWordByWordLenghtForQuestions(int wordLenght);
        public void DeleteWordByLenghtBeginningByConsonant(int wordLenght);
        public void ReplaceWordBySubstringOnSentence(int sentenceNumber, int wordLenght, string subString);
    }
}