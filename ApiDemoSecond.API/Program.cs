using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

var logger = NLog.LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));

var allowAnyOrigin = "AllowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OcraContext>(option =>
option.UseSqlServer("server=.;database=OCRA;Integrated Security=true",b=>
b.MigrationsAssembly("ApiDemoSecond.API")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAnyOrigin, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader().AllowAnyMethod();
    }
        );
});
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<ILoggerManager,LoggerService.LoggerService>();
builder.Services.AddScoped<IBirthRepository, BirthRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseCors(allowAnyOrigin);

app.Run();
