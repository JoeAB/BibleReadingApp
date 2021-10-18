using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IPassageData
    {
        public int ID { get; set; }
        public String BookName { get; set; }
        public int ChapterNumber { get; set; }
        public int PassageStart { get; set; }
        public int PassageEnd { get; set; }
    }
}
