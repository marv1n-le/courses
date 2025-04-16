using Microsoft.AspNetCore.Authentication.Cookies;
using Skincare.Services.Interface;
using Skincare.Services.Service;

namespace Skincare.RazorWebApp.AnhLD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ISystemAccountAccountService, SystemUserAccountService>();
            builder.Services.AddScoped<IServiceProviderInfoService, ServiceProviderInfoService>();
            builder.Services.AddScoped<ICustomerServiceHistoryService, CustomerServiceHistoryService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

            builder.Services.AddRazorPages();

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

            app.MapRazorPages().RequireAuthorization();

            app.Run();
        }
    }
}
