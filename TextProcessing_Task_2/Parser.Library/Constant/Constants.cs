namespace Parser.Library.Constant
{
    using System.Collections.Generic;

    public static class Constants
    {
        public static readonly IReadOnlyList<string> PunctuationMarks =new List<string> {",", ";", "\"", "'", " ", "—", "-"};

        public static readonly IReadOnlyList<string> SentenceDividers =new List<string>() {".", "!", "?", "?!", "!?", "..."};
    }
}