
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using FinalProject_BackEnd.Application;
using FinalProject.Application;
using FinalProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    //.AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"Config/connectionStrings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"Config/appsettings.json", optional: true, reloadOnChange: true);

//builder.Services.AddDbContext<DBContextFinalProject>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringsFinalProject")));

//builder.Services.AddScoped<IUsersRepository, UsersRepository>();

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
