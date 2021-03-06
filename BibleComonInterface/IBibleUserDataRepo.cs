using System;
using System.Collections.Generic;

namespace BibleComonInterface
{
    public interface IBibleUserDataRepo
    {
        public bool SaveUserPassage(IPassage passage);
        public bool UpdateUserPassage(IPassage passage);
        public bool RemoveUserPassage(IPassage passage);
        public bool RemoveUserPassageByID(string id);
        public bool AddUserPassage(IPassage passage);

        public List<IPassageData> GetPassages();

    }
}
