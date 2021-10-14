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
            return new Book("test");
        }

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

        public IChapter GetChapter(IBook book, int chapterNumber)
        {
            throw new NotImplementedException();
        }

        public List<IChapter> GetChapters(IBook book)
        {
            throw new NotImplementedException();
        }

        public IPassage GetPassage(IBook book, IChapter chapter, int startVerse, int endVerse)
        {
            throw new NotImplementedException();
        }

        public bool Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
