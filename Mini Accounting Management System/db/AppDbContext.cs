using Microsoft.EntityFrameworkCore;

namespace Mini_Accounting_Management_System.db
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
