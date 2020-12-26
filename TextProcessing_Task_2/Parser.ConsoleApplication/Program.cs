namespace Parser.ConsoleApplication
{
    using System;
    using System.Configuration;
    using System.IO;
    using Library.Models;
    using Library.Parser;

    static class Program
    {
        static void Main() //самому проверять null  
        {
            string path = ConfigurationManager.AppSettings["FilePath"];
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            Text text = ReadFile(path);
            // string input = ReadFile("input.txt"); //crate raper ?? Idisposaple
            // Text text = Parser.Parse(input);
            Console.WriteLine("Text:");
            foreach (var sentence in text)
            {
                foreach (var sentenceItem in sentence)
                {
                    Console.Write(sentenceItem);
                }
            }
            //
            // try
            // {
            //
            // }
            // catch
            // {
            //     
            // }
            // catch
            // {
            //     
            // }
            // ...
        }

        static Text ReadFile(string path)
        {
            Text text=new Text();
            string line;
            StreamReader file=null;
            try
            {
                file = new StreamReader(@path);
                
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e.Message);
            }
            while ((line = file.ReadLine()) != null)
            {
                Text t;
                t = Parser.Parse(line);
                foreach (var sentences in t)
                {
                    text.Add(sentences);
                }
            }
            return text;
        }
    }
}