
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using FinalProject.Application;
using FinalProject.Infrastructure;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("https://localhost:44376/api", "http://localhost:5173")
//                                                    .AllowAnyHeader()
//                                                    .AllowAnyMethod();
//                      });
//});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configure =>
    {
        configure.AllowAnyHeader();
        configure.AllowAnyMethod();
        configure.AllowAnyOrigin();
    });
});
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

app.UseCors();

app.Run();
