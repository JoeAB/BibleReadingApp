using NUnit.Framework;
using BibleData;
using BibleComonInterface;
using System.Collections.Generic;

namespace BibleDataTest
{
    public class Tests
    {
        private BibleData.DataRetrieval.BibleJsonLoader _loader;
        private IBook _testBook;
        [OneTimeSetUp]
        public void Setup()
        {
            _loader = new BibleData.DataRetrieval.BibleJsonLoader("C:\\\\Keys\\en_bbe.JSON");
            _testBook = new TestBook();
            _testBook.BookName = "Genesis";
            _testBook.ChapterCount = 50;
            _testBook.Chapters = new List<IChapter>();
            for(int i = 0; i < 50; i++)
            {
                IChapter chapter = new TestChapter();
                chapter.ChapterNumber = i + 1;
                chapter.VerseCount = 10;
                chapter.Verses = new List<IVerse>();
                for (int k = 0; k < 10; k++)
                {
                    IVerse verse = new TestVerse();
                    verse.verseNumber = k + 1;
                    verse.Text = (k + 1) + " Verse text. ";
                    chapter.Verses.Add(verse);
                }
                _testBook.Chapters.Add(chapter);
            }
        }

        [Test]
        public void GetBooksTest()
        {
            List<IBook> books = _loader.GetBooks();
            Assert.That(books.Count > 0);
            Assert.That(books[0].BookName.Equals("Genesis"));
        }

        [Test]
        public void GetBook()
        {
            IBook book = _loader.GetBook("John");
            Assert.That(book != null);
            Assert.That(book.BookName.Equals("John"));
        }



        private class TestBook : IBook
        {
            public string BookName { get; set; }
            public int ChapterCount { get; set ; }
            public List<IChapter> Chapters { get; set; }
        }
        private class TestChapter : IChapter
        {
            public List<IVerse> Verses { get; set; }
            public int VerseCount { get ; set ; }
            public int ChapterNumber { get; set ; }
        }
        private class TestVerse : IVerse
        {
            public string Text { get; set; }
            public int verseNumber { get ; set; }
        }

    }
}