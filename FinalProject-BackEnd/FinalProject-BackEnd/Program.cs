using FinalProject_BackEnd.DataBase;
using FinalProject_BackEnd.Repositories;
using FinalProject_BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    //.AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"Config/connectionStrings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"Config/appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddDbContext<DBContextFinalProject>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringsFinalProject")));

builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
