using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Data;
using WebApplication2.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//添加EF依赖注入连接字符串
var server = builder.Configuration["DatabaseServer"] ?? "";
var port = builder.Configuration["DatabasePort"] ?? "";
var user = builder.Configuration["DatabaseUser"] ?? "";
var password = builder.Configuration["DatabasePassword"] ?? "";
var database = builder.Configuration["DatabaseName"] ?? "";

var connectionString = $"Server={server}, {port}; Initial Catalog={database}; User ID={user}; Password={password};";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//添加错误页中间件
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//数据库migration
DatabaseManagementService.MigrationInitializasation(app);

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

