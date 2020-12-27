namespace Parser.Library.Parser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Constant;
    using Models;

    public class Parser : IParser
    {
        private readonly StreamReader _file;
        private readonly Text _result;

        public Parser(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Invalid path.", nameof(path));
            }

            _file = new StreamReader(path);
            _result = new Text();
        }

        public Text Parse()
        {
            while (!_file.EndOfStream)
            {
                var line = _file.ReadLine();
                ParseLine(line);
            }

            return _result;
        }

        private void ParseLine(string lineText)
        {
            IList<SentenceItem> currentItems = new List<SentenceItem>();
            lineText = Regex.Replace(lineText, @"( +\t+)|( +)|(\t+)|(\r+)|(\n+)", " ");

            MatchCollection matchCollection =
                Regex.Matches(lineText, @"(\w+\-)+(\w+)|(\w+)|([\W_-[\s]]+)|(\s)|(\w+\')+(\w+)");
            int i = 1;
            foreach (Match match in matchCollection)
            {
                string currentMatch = match.Value;

                if (IsWord(currentMatch))
                {
                    Word word = new Word(currentMatch);
                    currentItems.Add(word);
                }
                else if (IsPunctuationMark(currentMatch))
                {
                    if (i ==1 && currentMatch.Equals(" "))
                    {
                        
                    }
                    else
                    {
                        PunctuationPoint punctuationPoint = new PunctuationPoint(currentMatch);
                        currentItems.Add(punctuationPoint);
                    }
                }
                else if (IsSentenceDivider(currentMatch))
                {
                    PunctuationPoint divider = new PunctuationPoint(currentMatch);
                    currentItems.Add(divider);
                    i = 0;
                    FlushText(currentItems);
                }

                i++;
            }

            FlushText(currentItems);
        }

        private void FlushText(IList<SentenceItem> currentItems)
        {
            if (!currentItems.Any())
            {
                return;
            }

            Sentence sentence = new Sentence(currentItems);
            currentItems.Clear();
            _result.Add(sentence);
        }

        private static bool IsWord(string s)
        {
            return Regex.IsMatch(s, @"(\w+)|(\w+\-)+(\w+)");
        }

        private static bool IsPunctuationMark(string s)
        {
            return Constants.PunctuationMarks.Contains(s);
        }

        private static bool IsSentenceDivider(string s)
        {
            return Constants.SentenceDividers.Contains(s);
        }

        public void Dispose()
        {
            _file?.Dispose();
        }
    }
}