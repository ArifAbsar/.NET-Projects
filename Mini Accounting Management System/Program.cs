using Microsoft.EntityFrameworkCore;
using Mini_Accounting_Management_System.db;
using Microsoft.AspNetCore.Identity;
using Mini_Accounting_Management_System.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount =false).AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
