using Microsoft.EntityFrameworkCore;
using entities.Models;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddDbContext<CookwareShopContext>(option => option.UseSqlServer("Server=DESKTOP-T7J3RR5\\SQLEXPRESS;Database=CookwareShop;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
