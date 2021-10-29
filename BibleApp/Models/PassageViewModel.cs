using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    [Serializable]
    public class PassageViewModel
    {
        public PassageViewModel() { }

        public IPassage Passage { get; set; }
        public String BookName { get; set; }
        public int ChapterNumber { get; set; }
        public int MaxChapter { get; set; }
        public int MaxVerse { get; set; }

        public PassageViewModel(IPassage passage)
        {
            Passage = passage;
        }
    }
}
