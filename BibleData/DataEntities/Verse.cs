using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleData.DataEntities
{
    [Serializable]
    class Verse : IVerse
    {
        public string Text { get ; set; }
        public int verseNumber { get ; set; }
    }
}
