using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleDomain.CoreEntities
{
    class Passage : IPassage
    {
        public int ID { get; set; }
        public int ChapterNumber { get; set; }
        public int PassageStart { get ; set ; }
        public int PassageEnd { get; set; }
        public List<IVerse> Verses { get ; set; }
        public string BookName { get; set ; }
    }
}
