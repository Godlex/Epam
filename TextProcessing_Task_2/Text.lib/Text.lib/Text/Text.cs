using System;

namespace Text.lib.Text
{
    using System.Collections.Generic;
    using Models;

    public class Text
    {
        private IList<Sentence> _sentences;
        public Text()
        {
            _sentences = new List<Sentence>();
        }
    }
}