using api.EF.table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.EF
{
    public class NewspaperContext: DbContext
    {
        public NewspaperContext() : base("name=NewspaperContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}