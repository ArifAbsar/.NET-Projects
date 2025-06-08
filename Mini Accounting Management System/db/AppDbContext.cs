using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_Accounting_Management_System.db.Tables;
using Mini_Accounting_Management_System.Models;


namespace Mini_Accounting_Management_System.db
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; } = default!;
        public DbSet<SubAccount> SubAccounts { get; set; } = default!;
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherDC> VoucherDCS { get; set; } = default!;
        public DbSet<Journal_Voucher> Journal_Vouchers { get; set; } = default!;
        public DbSet<Payment_Voucher> Payment_Vouchers { get; set; } = default!;
        public DbSet<Reciept_Voucher> Reciept_Vouchers { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* base.OnModelCreating(builder);
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
             );*/
            base.OnModelCreating(builder);


            //AccountType configuration

            builder.Entity<AccountType>(entity =>
            {

                entity.HasKey(e => e.A_ID);

                entity.Property(e => e.A_ID)
                      .ValueGeneratedNever();


                entity.Property(e => e.Acc_Type)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(e => e.Acc_Type)
                      .IsUnique();
                //UNIQUE(Acc_Type)

                entity.Property(e => e.TotalBalance)
                      .HasPrecision(18, 2)
                      .HasDefaultValue(0m);

            });



            //SubAccount configuration
            builder.Entity<SubAccount>(entity =>
            {
                //Primary Key
                entity.HasKey(e => e.S_ID);

                entity.Property(e => e.S_ID)
                      .ValueGeneratedNever();



                entity.Property(e => e.Sub_Acc)
                      .IsRequired()
                      .HasMaxLength(100);


                entity.Property(e => e.Balance)
                      .HasPrecision(18, 2)
                      .HasDefaultValue(0m);

                //Foreign Key to AccountType
                entity.HasOne(e => e.AccountType)
                      .WithMany(t => t.SubAccounts)
                      .HasForeignKey(e => e.Type_A_ID)
                      .OnDelete(DeleteBehavior.Restrict);


                //Unique constraint on (Type_P_ID, Sub_Acc)
                entity.HasIndex(e => new { e.Type_A_ID, e.Sub_Acc })
                      .IsUnique();
            });
            builder.Entity<Journal_Voucher>(entity =>
            {
                entity.HasOne(jv => jv.SubAccount)
                      .WithMany(sa => sa.JournalVouchers)
                      .HasForeignKey(jv => jv.SubAccountID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Payment_Voucher>(entity =>
            {
                entity.HasOne(jv => jv.SubAccount)
                      .WithMany(sa => sa.PaymentVouchers)
                      .HasForeignKey(jv => jv.SubAccountID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Reciept_Voucher>(entity =>
            {
                entity.HasOne(jv => jv.SubAccount)
                      .WithMany(sa => sa.RecieptVouchers)
                      .HasForeignKey(jv => jv.SubAccountID)
                      .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}
