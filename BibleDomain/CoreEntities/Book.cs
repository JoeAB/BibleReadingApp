using System;
using System.Collections.Generic;
using System.Text;
using BibleComonInterface;

namespace BibleDomain.CoreEntities
{
    public class Book : IBook
    {
        public Book() { }
        public Book(String name)
        {
            BookName = name;
        }
        public string BookName { get; set; }
        public int ChapterCount { get; set; }
        public List<IChapter> Chapters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
