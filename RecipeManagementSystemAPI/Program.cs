using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemAPI;
using RecipeManagementSystemAPI.Models;

var builder = WebApplication.CreateBuilder(args);
// Add this near the top of your Program.cs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Information);


// Add services to the container.
builder.Services.AddControllers();

// This should be in your Program.cs
builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable Swagger in all environments for this project
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Use CORS before authorization
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Check database and log information about existing data
app.SeedDatabase();

app.Run();
