using System;
using System.Collections.Generic;
using System.Text;
using BibleComonInterface;
using BibleData.DataEntities;
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

        public bool AddUserPassage(IPassage passage)
        {
            using (var db = new BibleData.DataRetrieval.BibleUserDataContext(_connectionString))
            {
                db.Passage.Add(new Passage(passage));
                db.SaveChanges();

            }
            return true;
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
            Passage dbPassage = new Passage(passage);
            using (var db = new BibleData.DataRetrieval.BibleUserDataContext(_connectionString))
            {
                db.Passage.Add(dbPassage);

                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateUserPassage(IPassage passage)
        {
            throw new NotImplementedException();
        }
    }
}
