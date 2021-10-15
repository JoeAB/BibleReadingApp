using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    public class BookListViewModel
    {
        public List<IBook> Books { get; set; }
    }
}
