namespace Parser.Library.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class SentenceItem : ISentenceItem, IEnumerable<Symbol>, IEquatable<SentenceItem>
    {
        private readonly string _value;
        private readonly IList<Symbol> _symbols;

        protected SentenceItem(string value)
        {
            _value = value;
            _symbols = value.Select(variable => new Symbol(variable)).ToList();
        }

        public int Lenght => _symbols.Count;

        public IEnumerator<Symbol> GetEnumerator()
        {
            return _symbols.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsBeginningByConsonant()
        {
            return _symbols[0].IsConsonant();
        }

        public bool Equals(SentenceItem other)
        {
            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(this, other)) return true;

            return ToString().Equals(other.ToString());
        }

        public override int GetHashCode()
        {
            int hashProductName = _value == null ? 0 : _value.GetHashCode();
            return hashProductName;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}