using Microsoft.EntityFrameworkCore;
using Mini_Accounting_Management_System.db;
using Microsoft.AspNetCore.Identity;
using Mini_Accounting_Management_System.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mini_Accounting_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                option.UseSqlServer(connectionString);
            });

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("CanEditVouchers", policy =>
                    policy.RequireRole("Admin", "Accountant"));
                options.AddPolicy("CanEditCOA", policy =>
                    policy.RequireRole("Admin", "Accountant"));
                options.AddPolicy("CanViewCOA", policy =>
                    policy.RequireRole("Viewer", "Accountant", "Admin"));
                options.AddPolicy("CanViewVouchers", policy =>
                    policy.RequireRole("Viewer", "Accountant", "Admin"));
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
