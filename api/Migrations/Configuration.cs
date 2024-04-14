namespace api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<api.EF.NewspaperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(api.EF.NewspaperContext context)
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                //api.EF.table.Category c = new EF.table.Category();
                api.EF.table.News n=new EF.table.News();
                n.CategoryID = rand.Next(1, 1000);
                n.TITLE = Guid.NewGuid().ToString().Substring(0, 6);
                n.DATE=DateTime.Now;
                context.News.Add(n);

            }
            context.SaveChanges();
        }
    }
}
