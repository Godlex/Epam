namespace Parser.Library.Writer
{
    using System;
    using System.IO;
    using Models;

    public class Writer
    {
        private readonly StreamWriter _file;
        private readonly Text _text;
        public Writer(string path,Text text)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Invalid path.", nameof(path));
            }

            _file = new StreamWriter(path);
            _text = new Text();
            _text = text;
        }

        public void Write()
        {
            foreach (var sentence in _text)
            {
                _file.WriteLine(sentence); 
            }
        }
        
    }
}