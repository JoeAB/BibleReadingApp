using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBook
    {
        public string BookName { get; set; }
        public int ChapterCount { get; set; }

        List<IChapter> Chapters { get; set; }
    }
}
