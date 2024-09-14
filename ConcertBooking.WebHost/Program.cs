using ConcertBooking.Repositories.Implementations;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.ConcertBooking.Repositories;

using Microsoft.AspNetCore.Identity;
using ConcertBooking.Entities;

namespace ConcertBooking.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ConcertBooking.WebHost")));

            builder.Services.AddDefaultIdentity<ApplicationUser>
                (options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDBContext>();

            builder.Services.AddScoped<IVenueRepo, VenueRepo>();
            builder.Services.AddScoped<IArtistRepo, ArtistRepo>();
            builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
            builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();
            builder.Services.AddScoped<ITicketRepo, TicketRepo>();
            builder.Services.AddSingleton<IHttpContextAccessor,  HttpContextAccessor>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}
