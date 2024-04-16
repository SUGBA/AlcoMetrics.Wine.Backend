using System.Security.Claims;
using DataBase.EF.ConnectionFroWine.DbContexts;
using IdentityServer4.AccessTokenValidation;
using WebApp.Extensions;
using WebApp.Services.Account;
using WebApp.Services.Account.Abstract;

namespace Backend.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WineDbContext>(options => { }, ServiceLifetime.Transient);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "https://localhost:5001";
                options.RequireHttpsMetadata = false;
                options.ApiName = "AlcoMetrics.Wine.Backend";
                options.ApiSecret = "secre_#$forWineApi17782_ahseasd2_$231zmnkmtslaf12&&/";
                options.RoleClaimType = ClaimTypes.Role;
            });

            builder.Services.AddControllers();

            builder.AddWineCoreServices();
            builder.Services.AddTransient<IAccountService, AccountService>();

            var app = builder.Build();

            app.Services.AcceptMigration();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}