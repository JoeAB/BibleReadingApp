using BibleComonInterface;
using BibleDomain.CoreEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleDomain.Managers
{
    public class BibleBookManager : IBibleBookManager
    {
        private IBibleLoader _loader;
        private IBibleUserDataRepo _dbRepo;
        public BibleBookManager(IBibleLoader loader, IBibleUserDataRepo dbRepo)
        {
            _loader = loader;
            _dbRepo = dbRepo;
        }
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

        public IChapter GetChapter(IBook book, int chapterNumber)
        {
            if(book.ChapterCount < chapterNumber)
            {
                //we'll want to return some sort of validation or log something later
                return null;
            }
            int chapterIndex = chapterNumber - 1;//adjust to index
            return book.Chapters[chapterIndex];
        }

        public IPassage GetPassage(IBook book, IChapter chapter, int startVerse, int endVerse)
        {
            if(chapter.VerseCount < endVerse || startVerse < 1 || endVerse < startVerse)
            {
                return null;
            }
            IPassage passage = new Passage();
            passage.BookName = book.BookName;
            passage.ChapterNumber = chapter.ChapterNumber;
            passage.Verses = new List<IVerse>();
            passage.PassageStart = startVerse;
            passage.PassageEnd = endVerse;
            for(int i = startVerse -1; i <= endVerse -1; i++)
            {
                passage.Verses.Add(chapter.Verses[i]);
            }
            return passage;
        }

        public bool AddUserPassage(IPassage passage)
        {
            return _dbRepo.AddUserPassage(passage);
        }
    }
}
