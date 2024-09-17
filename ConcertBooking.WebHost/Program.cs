using ConcertBooking.Repositories.Implementations;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.ConcertBooking.Repositories;

using Microsoft.AspNetCore.Identity;
using ConcertBooking.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;

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

            //builder.Services.AddDefaultIdentity<ApplicationUser>
            //    (options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDBContext>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDBContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            builder.Services.AddScoped<IDBInitial, DBInitial>();

            builder.Services.AddScoped<IVenueRepo, VenueRepo>();
            builder.Services.AddScoped<IArtistRepo, ArtistRepo>();
            builder.Services.AddScoped<IConcertRepo, ConcertRepo>();
            builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();
            builder.Services.AddScoped<ITicketRepo, TicketRepo>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();

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

            DataSeeding();

            void DataSeeding()
            {
                using(var scope = app.Services.CreateScope())
                {
                    var _dbRepo = scope.ServiceProvider.GetRequiredService<IDBInitial>();
                    _dbRepo.Seed();
                }
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
