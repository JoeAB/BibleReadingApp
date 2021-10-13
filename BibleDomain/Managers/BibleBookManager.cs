using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleDomain.Managers
{
    public class BibleBookManager : IBibleBookManager
    {
        private IBibleLoader _loader;
        public BibleBookManager(IBibleLoader loader)
        {
            _loader = loader;
        }

        public List<IBook> GetBibleBookList()
        {
            return _loader.GetBooks();
        }
    }
}
