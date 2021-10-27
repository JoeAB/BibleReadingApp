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
        public AddPassageViewModel AddPassage { get; set; }

        public String BookName { get; set; }
        public int ChapterNumber { get; set; }
        public int MaxChapter { get; set; }
        public int MaxVerse { get; set; }

        public PassageViewModel(IPassage passage)
        {
            Passage = passage;
            //Set the values of the AddPassageViewModel
            //so that the viewer can hit 'Save Passage for Later'
            //and post the values back to record it in the DB.
            AddPassage = new AddPassageViewModel();
            AddPassage.BookName = Passage.BookName;
            AddPassage.ChapterNumber = Passage.ChapterNumber;
            AddPassage.StartVerse = Passage.PassageStart;
            AddPassage.EndVerse = Passage.PassageEnd;
        }
    }
}
