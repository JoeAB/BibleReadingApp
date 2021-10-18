using System;
using System.Collections.Generic;

namespace BibleComonInterface
{
    public interface IBibleUserDataRepo
    {
         public List<IPassage> GetUserPassages();
        public bool SaveUserPassage(IPassage passage);
        public bool UpdateUserPassage(IPassage passage);
        public bool RemoveUserPassage(IPassage passage);
        public bool AddUserPassage(IPassage passage);

    }
}
