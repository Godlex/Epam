namespace Parser.ConsoleApplication
{
    using System;
    using System.IO;
    using Library.Models;
    using Library.Parser;

    static class Program
    {
        static void Main()
        {
            string input = ReadFile("input.txt");
            Text text = Parser.Parse(input);
            Console.WriteLine("Text:");
            foreach (var sentence in text)
            {
                foreach (var sentenceItem in sentence)
                {
                    Console.WriteLine(sentenceItem);
                }
            }
        }
        
        static string ReadFile(string name)
        {
            return File.ReadAllText(Environment.CurrentDirectory + "/" + name);
        }
    }
}