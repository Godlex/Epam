namespace Parser.Library.Models
{
    public interface ISentenceItem
    {
        public int Lenght { get; }
        public bool IsBeginningByConsonant();
        public bool Equals(SentenceItem other);
    }
}