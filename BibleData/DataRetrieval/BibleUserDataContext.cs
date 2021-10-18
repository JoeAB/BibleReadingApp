using BibleComonInterface;
using BibleData.DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibleData.DataRetrieval
{
    class BibleUserDataContext: DbContext
    {
        public DbSet<Passage> Passage { get; set; }

        private String DbPath;

        public BibleUserDataContext(String path)
        {
            DbPath = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(DbPath);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passage>().ToTable("Passage");
        }
    }
}
