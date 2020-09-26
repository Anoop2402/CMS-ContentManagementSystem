using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CMSViewEngine1.Models.VAL;

namespace CMSViewEngine1.Models
{
    public class DBViewEngineContext : DbContext
    {
        public DBViewEngineContext()
            : base("name=DefaultConnection")
        {



        }

        public DbSet<MainPage> MainPage { get; set; }

        public DbSet<PageLayout> PageLayout { get; set; }

        public DbSet<Content> PageContent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}