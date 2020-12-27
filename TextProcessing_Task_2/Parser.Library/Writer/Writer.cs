namespace Parser.Library.Writer
{
    using System;
    using System.IO;
    using Models;

    public class Writer : IWriter
    {
        private readonly StreamWriter _file;
        private readonly Text _text;

        public Writer(string path, Text text)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Invalid path.", nameof(path));
            }

            _file = new StreamWriter(path) {AutoFlush = true};
            _text = new Text();
            _text = text;
        }

        public void Write()
        {
            foreach (var sentence in _text)
            {
                _file.WriteLine(sentence.ToString());
            }
        }

        public void Dispose()
        {
            _file?.Dispose();
        }
    }
}