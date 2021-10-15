using System;
using System.Collections.Generic;
using System.Text;

namespace BibleComonInterface
{
    public interface IBibleBookManager
    {
        public List<IBook> GetBibleBookList();
        public IBook GetBook(String bookID);
    }
}
