using System;
using System.Collections.Generic;
using System.Text;
using BibleComonInterface;
using BibleData.DataEntities;
using Microsoft.Data.Sqlite;
using System.Linq;

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

        public List<IPassage> GetPassages()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserPassage(IPassage passage)
        {
            return true;
        }

        public bool RemoveUserPassageByID(string id)
        {
            int idInt;
            if(Int32.TryParse(id, out idInt))
            {
                using (var db = new BibleData.DataRetrieval.BibleUserDataContext(_connectionString))
                {
                    Passage removalItem = db.Passage.Single(x => x.ID.Equals(idInt));
                    db.Passage.Remove(removalItem);

                    db.SaveChanges();
                    return true;
                }
            }
            return false;
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

        List<IPassageData> IBibleUserDataRepo.GetPassages()
        {
            List<IPassageData> passages = new List<IPassageData>();
            using (var db = new BibleData.DataRetrieval.BibleUserDataContext(_connectionString))
            {
                foreach(var item in db.Passage)
                {
                    passages.Add(item);
                }
            }
            return passages;
        }
    }
}
