using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleData.DataEntities
{
    class Chapter : IChapter
    {
        public List<IVerse> Verses { get ; set ; }
        public int VerseCount { get ; set; }
        public int ChapterNumber { get; set; }
    }
}
