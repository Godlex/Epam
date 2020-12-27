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
        private readonly IList<SentenceItem> _currentItems = new List<SentenceItem>();

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

            FlushText();
            return _result;
        }

        private void ParseLine(string lineText)
        {
            lineText = ReplaceTabsBySpaces(lineText);
            MatchCollection matchCollection = MatchSentencesItems(lineText);

            foreach (Match match in matchCollection)
            {
                string currentMatch = match.Value;

                if (IsWord(currentMatch))
                {
                    Word word = new Word(currentMatch);
                    _currentItems.Add(word);
                }
                else if (IsPunctuationMark(currentMatch))
                {
                    if (_currentItems.Any() || !currentMatch.Equals(" "))
                    {
                        PunctuationPoint punctuationPoint = new PunctuationPoint(currentMatch);
                        _currentItems.Add(punctuationPoint);
                    }
                }
                else if (IsSentenceDivider(currentMatch))
                {
                    PunctuationPoint divider = new PunctuationPoint(currentMatch);
                    _currentItems.Add(divider);
                    FlushText();
                }
            }
        }

        private static MatchCollection MatchSentencesItems(string lineText)
        {
            return Regex.Matches(lineText, @"(\w+\-)+(\w+)|(\w+)|([\W_-[\s]]+)|(\s)|(\w+\')+(\w+)");
        }

        private static string ReplaceTabsBySpaces(string lineText)
        {
            return Regex.Replace(lineText, @"( +\t+)|( +)|(\t+)|(\r+)|(\n+)", " ");
        }

        private void FlushText()
        {
            if (!_currentItems.Any())
            {
                return;
            }

            Sentence sentence = new Sentence(_currentItems);
            _currentItems.Clear();
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