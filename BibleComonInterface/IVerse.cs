using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IVerse
    {
        public string Text { get; set; }
        public int verseNumber { get; set; }
    }
}
