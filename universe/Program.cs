using Microsoft.EntityFrameworkCore;
using universe;
using universe.Models;    // пространство имен класса ApplicationContext


var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("Server= MSI\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer("Server= MSI\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();