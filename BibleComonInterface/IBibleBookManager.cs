using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBibleBookManager
    {
        public List<IBook> GetBibleBookList();
        public IBook GetBook(String bookID);
        public IChapter GetChapter(String bookID, int chapterNumber);
        public IPassage GetPassage(String bookID, int chapterNumber, int startVerse, int endVerse);

    }
}
