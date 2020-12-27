namespace Parser.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using Library.Models;
    using Library.Parser;
    using Library.Writer;

    static class Program
    {
        static void Main()
        {
            string path = ConfigurationManager.AppSettings["FileInPath"];
            Text text;
            try
            {
                using var parser = new Parser(path);
                text = parser.Parse();
                text.ReplaceWordBySubstringOnSentence(0, 3, "aaaaaaaaa");
                IList<Sentence> sen = text.GetSortedSentenceByWordCount();
                foreach (var sentence in sen)
                {
                    Console.WriteLine(sentence);
                }
                int wordlenght = 5;
                text.DeleteWordByLenghtBeginningByConsonant(wordlenght);
                IEnumerable<SentenceItem> words = text.GetUniqueWordByWordLenghtForQuestions(wordlenght);
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
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
                using var writer = new Writer(pathout, text);
                writer.Write();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"File writing failed with error: {exception.Message}");
            }
        }
    }
}