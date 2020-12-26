namespace Parser.ConsoleApplication
{
    using System;
    using System.Configuration;
    using Library.Models;
    using Library.Parser;

    static class Program
    {
        static void Main() //самому проверять null  
        {
            string path = ConfigurationManager.AppSettings["FilePath"];
            Text text;
            try
            {
                using var parser = new Parser(path);
                text = parser.Parse();
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
        }
    }
}