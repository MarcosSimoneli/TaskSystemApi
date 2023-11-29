
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Sinks.MSSqlServer;
using System.Diagnostics;
using TaskSystemApi.Data;
using TaskSystemApi.Repository;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            _ = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false, reloadOnChange: true);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TasksSystemDBContext>(
                 options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .MSSqlServer(
                    connectionString: "Server=SIMONELI;Database=DBTADEV;User Id=usertest;Password=password123;TrustServerCertificate=True;",
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = true,
                        TableName = "LogEvents"
                    })
                .MinimumLevel.Information()
                .Filter.ByExcluding(Matching.FromSource("Microsoft.Hosting.Lifetime"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Hosting.Diagnostics"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.EntityFrameworkCore"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker"))
                .CreateLogger();

            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
            });

            builder.Logging.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
