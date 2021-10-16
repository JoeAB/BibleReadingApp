using BibleComonInterface;
using BibleData.DataEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BibleData.DataRetrieval
{
    public class BibleJsonLoader : IBibleLoader
    {
        private String _dataPath { get; set; }

        private String LoadJSONString()
        {
            return File.ReadAllText(_dataPath);
        }
        public BibleJsonLoader(String dataPath)
        {
            _dataPath = dataPath;
        }

        public IBook GetBook(string bookID)
        {
            String result = LoadJSONString();
            JArray jArray = JArray.Parse(result);
            JObject node = JObject.Parse(jArray.First(n => n.SelectToken("name").ToString() == bookID)
                                   .ToString());

            Book book = new Book(node["name"].ToString(), node["chapters"].Children().Count());
            book.Chapters = new List<IChapter>();
            int chapterIndex = 1;
            foreach(var chapterNode in node["chapters"].Children())
            {
                Chapter chapter = new Chapter();
                chapter.VerseCount = chapterNode.Children().Count();
                chapter.Verses = new List<IVerse>();
                chapter.ChapterNumber = chapterIndex;
                chapterIndex++;
                int indexVerse = 1;
                foreach(var verseNode in chapterNode.Children())
                {
                    Verse verse = new Verse();
                    verse.Text = verseNode.ToString();
                    verse.verseNumber = indexVerse;
                    indexVerse++;
                    chapter.Verses.Add(verse);
                }
                book.Chapters.Add(chapter);
            }
            return book;
        }

        //only loading the name, so we don't need to initialize the entire Bible at once
        public List<IBook> GetBooks()
        {
            String result = LoadJSONString();

            JArray jArray = JArray.Parse(result);
            List<IBook> books = new List<IBook>();

            foreach (JObject item in jArray)
            {
                Book book = new Book(item["name"].ToString(), item["chapters"].Children().Count());
                books.Add(book);
            }
            return books;
        }

    }
}
