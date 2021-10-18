using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleData.DataEntities
{
    class Passage 
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public int ChapterNumber { get; set; }
        public int PassageStart { get; set; }
        public int PassageEnd { get; set; }

        public Passage(IPassage ipassage)
        {
            BookName = ipassage.BookName;
            ChapterNumber = ipassage.ChapterNumber;
            PassageStart = ipassage.PassageStart;
            PassageEnd = ipassage.PassageEnd;
        }
        public Passage() { }

    }
}
