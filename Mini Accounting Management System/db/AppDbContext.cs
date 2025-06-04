using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_Accounting_Management_System.db.Tables;
using Mini_Accounting_Management_System.Models;

namespace Mini_Accounting_Management_System.db
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
       /* protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var Admin = new IdentityRole("Admin");
            Admin.NormalizedName = "Admin";
            var Accountant = new IdentityRole("Accountant");
            Accountant.NormalizedName = "Accountant";
            var Viewer = new IdentityRole("Viewer");
            Viewer.NormalizedName = "Viewer";

            builder.Entity<IdentityRole>().HasData(
                Admin,
                Accountant,
                Viewer
            );

        }*/
    }
}
