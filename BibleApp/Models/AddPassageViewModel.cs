using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    [Serializable]
    public class AddPassageViewModel
    {
        public String BookName { get; set; }
        public int ChapterNumber { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }
    }
}
