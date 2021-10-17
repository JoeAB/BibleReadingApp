using System;
using System.Collections.Generic;
using System.Text;
using BibleComonInterface;
using Microsoft.Data.Sqlite;

namespace BibleData.DataRetrieval
{
    public class BibleUserDataSQLLiteRepo : IBibleUserDataRepo
    {
        private String _connectionString;
        public BibleUserDataSQLLiteRepo(String connectionString)
        {
            _connectionString = connectionString;
        }
        public List<IPassage> GetUserPassages()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserPassage(IPassage passage)
        {
            return true;
        }

        public bool SaveUserPassage(IPassage passage)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserPassage(IPassage passage)
        {
            throw new NotImplementedException();
        }
    }
}
