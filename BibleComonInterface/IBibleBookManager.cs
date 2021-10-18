using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBibleBookManager
    {
        public List<IBook> GetBibleBookList();
        public IBook GetBook(String bookID);
        public IChapter GetChapter(IBook book, int chapterNumber);
        public IPassage GetPassage(IBook bookID, IChapter chapterNumber, int startVerse, int endVerse);
        public bool AddUserPassage(IPassage passage);
    }
}
