using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBibleLoader
    {
        public List<IBook> GetBooks();
        public IBook GetBook(String bookID);
    }
}
