namespace Parser.Library.Parser
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Models;

    public class Parser : IParser
    {
        private static readonly string[] PunctuationMarks = {",", ";", "\"", "'", "\n", " ", "—", "-"};

        private static readonly string[] SentenceDividers = {".", "!", "?", "?!", "!?", "..."};

        public static Text Parse(string path)
        {
            string _text;
            
            IList<Sentence> sentences = new List<Sentence>();
            
            IList<SentenceItem> currentItems = new List<SentenceItem>();
            
            StreamReader reader = new StreamReader(path);
            
            _text = (string) reader.ReadToEnd();
            
            _text = Regex.Replace(_text, @"( +)|(\t+)|(\r)", " ");
            
            MatchCollection matchCollection = Regex.Matches(_text, @"(\w+\-)+(\w+)|(\w+)|([\W_-[\s]]+)|(\s)");
            
            foreach (Match match in matchCollection)
            {
                string s = match.Value;
                
                if (IsWord(s))
                {
                    Word word = new Word(s);
                    currentItems.Add(word);
                }

                if (IsPunctuationMark(s))
                {
                    PunctuationPoint punctuationPoint = new PunctuationPoint(s);
                    currentItems.Add(punctuationPoint);
                }

                if (IsSentenceDivider(s))
                {
                    PunctuationPoint divider = new PunctuationPoint(s);
                    currentItems.Add(divider);

                    Sentence sentence = new Sentence(currentItems);
                    currentItems.Clear();
                    sentences.Add(sentence);
                }
            }

            Text t = new Text(sentences);
            
            return t;
        }


        private static bool IsWord(string s)
        {
            return Regex.IsMatch(s, @"(\w+)|(\w+\-)+(\w+)");
        }

        private static bool IsPunctuationMark(string s)
        {
            return ((IList) PunctuationMarks).Contains(s);
        }

        private static bool IsSentenceDivider(string s)
        {
            return ((IList) SentenceDividers).Contains(s);
        }
    }
}

    