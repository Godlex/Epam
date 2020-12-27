namespace Parser.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Library.Models;
    using Library.Parser;
    using Library.Writer;

    static class Program
    {
        static void Main() //самому проверять null  
        {
            string path = ConfigurationManager.AppSettings["FileInPath"];
            Text text;
            try
            {
                using var parser = new Parser(path);
                text = parser.Parse();
                // text.ReplaceWordBySubstringOnSentence(0,1,"aaaaaaaaa");
                // IList<Sentence> sen = text.GetSortedSentenceByWordCount();
                // foreach (var VARIABLE in sen)
                // {
                //     Console.WriteLine(VARIABLE);
                // }
                //  int wordlenght = 5;
                // text.DeleteWordByLenghtBeginningByConsonant(wordlenght);
                //IEnumerable<SentenceItem> words = text.GetUniqueWordByWordLenghtForQuestions(wordlenght);
                // foreach (var word in words)
                // {
                //     Console.WriteLine(word);
                // }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine($"File parsing failed with error: {exception.Message}");
                return;
            }

            Console.WriteLine("Text:");
            foreach (var sentence in text)
            {
                foreach (var sentenceItem in sentence)
                {
                    Console.Write(sentenceItem);
                }
            }

            string pathout = ConfigurationManager.AppSettings["FileOutPath"];
            try
            {
                var writer = new Writer(pathout,text);
                writer.Write();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"File writing failed with error: {exception.Message}");
                return;
            }
        }
    }
}