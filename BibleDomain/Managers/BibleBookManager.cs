using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleDomain.Managers
{
    public class BibleBookManager : IBibleBookManager
    {
        private IBibleLoader _loader;
        public BibleBookManager(IBibleLoader loader)
        {
            _loader = loader;
        }

        public List<IBook> GetBibleBookList()
        {
            return _loader.GetBooks();
        }

        public IBook GetBook(string bookID)
        {
            return _loader.GetBook(bookID);
        }

        public IChapter GetChapter(string bookID, int chapterNumber)
        {
            IBook book = GetBook(bookID);
            int chapterIndex = chapterNumber - 1;//adjust to index
            return book.Chapters[chapterIndex];
        }

        public IPassage GetPassage(string bookID, int chapterNumber, int startVerse, int endVerse)
        {
            throw new NotImplementedException();
        }
    }
}
