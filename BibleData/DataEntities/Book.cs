using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleData.DataEntities
{
    public class Book : IBook
    {
        public Book(String name)
        {
            BookName = name;
        }
        public Book(String name, int countChapter)
        {
            BookName = name;
            ChapterCount = countChapter;
        }
        public string BookName { get; set; }
        public int ChapterCount { get; set; }
    }
}
