namespace Parser.Library.Parser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Models;
    using Constant;

    public class Parser : IParser
    {
        public static Text Parse(string text)
        {
            Text t = new Text(); //text add
            
            IList<SentenceItem> currentItems = new List<SentenceItem>();
            
            text = Regex.Replace(text, @"( +)|(\t+)|(\r)|(\n)", " ");
            
            MatchCollection matchCollection = Regex.Matches(text, @"(\w+\-)+(\w+)|(\w+)|([\W_-[\s]]+)|(\s)|(\w+\')+(\w+)");
            
            foreach (Match match in matchCollection)
            {
                string currentMatch = match.Value;
                
                if (Constants.IsWord(currentMatch))
                {
                    Word word = new Word(currentMatch);
                    currentItems.Add(word);
                }

                if (Constants.IsPunctuationMark(currentMatch))
                {
                    PunctuationPoint punctuationPoint = new PunctuationPoint(currentMatch);
                    currentItems.Add(punctuationPoint);
                }

                if (Constants.IsSentenceDivider(currentMatch))
                {
                    PunctuationPoint divider = new PunctuationPoint(currentMatch);
                    currentItems.Add(divider);

                    Sentence sentence = new Sentence(currentItems);
                    currentItems.Clear();

                    t.Add(sentence);
                }
            }
            return t;
        }


        
    }
}

    