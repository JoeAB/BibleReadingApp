using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IPassage
    {
        public IChapter Chapter { get; set; }
        public int PassageStart { get; set; }
        public int PassageEnd { get; set; }
        public string Text { get; set; }
    }
}
