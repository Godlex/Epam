namespace Parser.Library.Parser
{
    using System;
    using Models;

    public interface IParser : IDisposable
    {
        public Text Parse();
        public new void Dispose();
    }
}