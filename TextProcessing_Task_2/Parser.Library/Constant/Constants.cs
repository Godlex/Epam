namespace Parser.Library.Constant
{
    using System.Collections.Generic;

    public static class Constants
    {
        public static readonly IReadOnlyList<string> PunctuationMarks =new List<string>() {",", ";", "\"", "'", " ", "—", "-","–"};

        public static readonly IReadOnlyList<string> SentenceDividers =new List<string>() {".", "!", "?", "?!", "!?", "..."};
        
        public static readonly IReadOnlyList<string> Consonant =new List<string>() {"q", "w", "e", "r", "t", "p","s","d","f","g","h","j","k","l","z","x","c","v","b","n","m"};
    }
}