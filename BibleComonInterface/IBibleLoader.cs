using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBibleLoader
    {
        public bool Initialize();
        public List<IBook> GetBooks();
        public IBook GetBook(String bookID);
        public List<IChapter> GetChapters(IBook book);
        public IChapter GetChapter(IBook book, int chapterNumber);
        public IPassage GetPassage(IBook book, IChapter chapter, int startVerse, int endVerse);
    }
}
