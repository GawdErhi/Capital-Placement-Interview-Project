using CapitalPlacementInterviewProject.API.DB;
using CapitalPlacementInterviewProject.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementInterviewProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProjectDBContext>(options =>
            {
                options.UseCosmos(builder.Configuration.GetConnectionString("Default"), builder.Configuration.GetSection("DatabaseNames").GetValue<string>("Default"));
            });
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRepositories();
            builder.Services.AddCoreServices();
            builder.Services.AddHandlers();
            builder.Services.AddLog4NetLogger();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            var dbContext = new ProjectDBContext();
            dbContext.Database.EnsureCreated();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
