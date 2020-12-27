namespace Parser.Library.Models
{
    using System.Collections.Generic;

    public interface ISentence
    {
        public int GetWordCount { get; }
        public IEnumerable<SentenceItem> GetUniqueWordByLenght(int wordLenght);
        public bool IsQuestions();
        public void DeleteWordByLenghtBeginningByConsonant(int wordLenght);
        public void ReplaceWordBySubstring(int wordLenght, string subString);
    }
}