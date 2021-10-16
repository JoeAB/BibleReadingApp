using NUnit.Framework;
using BibleDomain;
using BibleComonInterface;
using System.Collections.Generic;
using System.Linq;

namespace BibleDomainTest
{
    public class Tests
    {
        private BibleDomain.Managers.BibleBookManager _bibleBookManager;
        [SetUp]
        public void Setup()
        {
            _bibleBookManager = new BibleDomain.Managers.BibleBookManager(new MockLoader());
        }

        [Test]
        public void BookManagerTests()
        {
            IBook book = _bibleBookManager.GetBook("Test");

            Assert.That(book.BookName.Equals("Test"));

            IChapter chapter = _bibleBookManager.GetChapter(book, 5);

            Assert.That(chapter.ChapterNumber == 5);
            Assert.Null(_bibleBookManager.GetChapter(book, 20));

            IPassage passage = _bibleBookManager.GetPassage(book, chapter, 1, 3);

            Assert.That(passage.Verses[1].Text.Equals("text 2"));
        }

        public class MockLoader : IBibleLoader
        {
            private List<IBook> _books { get; set; }
            public MockLoader()
            {
                _books = new List<IBook>();
                MockBook book = new MockBook();
                book.BookName = "Test";
                book.ChapterCount = 10;
                book.Chapters = new List<IChapter>();
                for(int i = 1; i <= 10; i++)
                {
                    IChapter chapter = new MockChapter();
                    chapter.ChapterNumber = i;
                    chapter.VerseCount = 5;
                    chapter.Verses = new List<IVerse>();
                    for(int k = 1; k <= 5; k++)
                    {
                        IVerse verse = new MockVerse();
                        verse.verseNumber = k;
                        verse.Text = "text " + k;
                        chapter.Verses.Add(verse);
                    }
                    book.Chapters.Add(chapter);
                }
                _books.Add(book);
            }
            List<IBook> IBibleLoader.GetBooks()
            {
                return _books;
            }

            public IBook GetBook(string bookID)
            {
                return _books.Single(x => x.BookName.Equals(bookID));
            }
        }
        public class MockBook : IBook
        {
            public string BookName { get ; set ; }
            public int ChapterCount { get ; set ; }
            public List<IChapter> Chapters { get ; set ; }
        }

        public class MockChapter : IChapter
        {
            public List<IVerse> Verses { get; set ; }
            public int VerseCount { get; set; }
            public int ChapterNumber { get; set; }
        }
        public class MockVerse : IVerse
        {
            public string Text { get; set ; }
            public int verseNumber { get; set; }
        }
    }
}