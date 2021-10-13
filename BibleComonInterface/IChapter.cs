using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IChapter
    {
        public IBook Book { get; set; }
        public string Text { get; set; }
        public int VerseCount { get; set; }
    }
}
