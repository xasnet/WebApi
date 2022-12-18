using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Controllers;
using WebApi.DataAccess;
using WebApi.DataAccess.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Connection string to Postgres.
var postgreConnectionString = builder.Configuration.AddUserSecrets<Program>().Build()["ConnectionString"];

if (postgreConnectionString == null)
{
    throw new Exception("Can not find secrets.json");
}

// Add DbContext to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(postgreConnectionString).UseSnakeCaseNamingConvention());

// Links to assemblies.
Assembly controllersAssembly = Assembly.GetAssembly(typeof(CustomersController))!;

// Add services to the container.
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Add libraries to IoC.
builder.Services.AddAutoMapper(controllersAssembly);

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
