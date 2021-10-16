using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IPassage
    {
        public String BookName { get;set }
        public int ChapterNumber { get; set; }
        public int PassageStart { get; set; }
        public int PassageEnd { get; set; }
        List<IVerse> Verses { get; set; }
    }
}
