using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.Web.Data;

namespace TechnologyKeeda.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DI Container or Services
            var builder = WebApplication.CreateBuilder(args);

             //classname instancename = new classname();
             builder.Services.AddDbContext<ApplicationDBContext>(options=>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Test}/{action=ShowButton}/{id?}");

            app.Run();
        }
    }
}
