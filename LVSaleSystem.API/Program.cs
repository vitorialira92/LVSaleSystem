
using LVSaleSystem.API.Data;
using LVSaleSystem.API.Filters;
using LVSaleSystem.API.Repositories;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LVSaleSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policyFlex", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:5500");
                });

            });

            builder.Services.AddScoped<IContentTypeProvider, FileExtensionContentTypeProvider>();
            builder.Services.AddScoped<TokenRepository>();
            builder.Services.AddScoped<TokenService>();

            builder.Services.AddScoped<CustomerRepository>();
            builder.Services.AddScoped<ProductsRepository>();
            builder.Services.AddScoped<SellingRepository>();
            builder.Services.AddScoped<ManagerRepository>();
            builder.Services.AddScoped<ReturnsRepository>();

            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<SellingService>();
            builder.Services.AddScoped<ReturnsService>();
            builder.Services.AddScoped<LoginService>();

            builder.Logging.ClearProviders();

            builder.Logging.AddConsole();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<LoggingAttributeFilter>();
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LVContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlite(builder.Configuration.GetConnectionString("LVSaleSystemSqlite"));
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("policyFlex");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
