namespace Parser.Library.Constant
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Constants
    {
        private static readonly IList<string> PunctuationMarks =new List<string>() {",", ";", "\"", "'", " ", "—", "-"};

        private static readonly IList<string> SentenceDividers =new List<string>() {".", "!", "?", "?!", "!?", "..."};

        public static bool IsWord(string s) 
        {
            return Regex.IsMatch(s, @"(\w+)|(\w+\-)+(\w+)");
        }

        public static bool IsPunctuationMark(string s)
        {
            return PunctuationMarks.Contains(s);
        }

        public static bool IsSentenceDivider(string s)
        {
            return SentenceDividers.Contains(s);
        }
    }
}