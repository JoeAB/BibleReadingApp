using BibleComonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Models
{
    [Serializable]
    public class AddPassageViewModel
    {
        public String Book { get; set; }
        public int Chapter { get; set; }
        public int PassageStart { get; set; }
        public int PassageEnd { get; set; }
    }
}
