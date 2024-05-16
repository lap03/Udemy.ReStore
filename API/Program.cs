using API.Data;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3001", "http://localhost:3000");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<StoreContext>();
            var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
            try
            {
                context.Database.Migrate(); // auto create database if not have
                DbInitializer.Inittialize(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "A problem occurred  during migration");
            }   

            app.Run();
        }
    }
}
