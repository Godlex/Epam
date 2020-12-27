namespace Parser.Library.Writer
{
    using System;

    public interface IWriter : IDisposable
    {
        public void Write();
        public new void Dispose();
    }
}