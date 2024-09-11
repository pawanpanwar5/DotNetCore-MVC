using ConcertBooking.Repositories.Implementations;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.ConcertBooking.Repositories;

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

            builder.Services.AddScoped<IVenueRepo, VenueRepo>();
            builder.Services.AddScoped<IArtistRepo, ArtistRepo>();
            builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
            builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();


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

            app.Run();
        }
    }
}
