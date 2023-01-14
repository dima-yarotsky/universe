using Microsoft.EntityFrameworkCore;
using universe;
using universe.Models;    // ������������ ���� ������ ApplicationContext


var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("Server= MSI\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer("Server= MSI\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();