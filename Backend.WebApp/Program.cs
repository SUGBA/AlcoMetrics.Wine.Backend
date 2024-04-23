using DataBase.EF.ConnectionFroWine.DbContexts;
using MathNet.Numerics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApp.Extensions;
using WebApp.Services.AutoMap.Profiles;
using WebApp.UseCases.Account;
using WebApp.UseCases.Account.Abstract;

namespace Backend.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WineDbContext>(options => { }, ServiceLifetime.Scoped);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            builder.Services.AddCors();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "https://localhost:5001";
                options.RequireHttpsMetadata = false;
                options.ApiName = "AlcoMetrics.Wine.Backend";
                options.ApiSecret = "secre_#$forWineApi17782_ahseasd2_$231zmnkmtslaf12&&/";
            });

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(Client2DomenModeProfile), typeof(IntegrationAPIProfile));
            builder.Services.AddHttpContextAccessor();

            builder.AddRepository();
            builder.ConfigureWineUseCases();
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
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}