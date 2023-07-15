using Microsoft.EntityFrameworkCore;
using si730ebu20201b051.Domain;
using si730ebu20201b051.Domain.Interfaces;
using si730ebu20201b051.Domain.Mapper;
using si730ebu20201b051.Domain.Response;
using si730ebu20201b051.Infraestructure;
using si730ebu20201b051.Infraestructure.Context;
using si730ebu20201b051.Infraestructure.Interfaces;
using si730ebu20201b051.Infraestructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IProductInfrastructure, ProductInfraestructure>();
builder.Services.AddScoped<IMaintenanceActivityInfraestructure, MaintenanceActivityInfraestructure>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();
builder.Services.AddScoped<IMaintenanceActivityDomain, MaintenanceActivityDomain>();
builder.Services.AddAutoMapper(
    typeof(ModelToResponse), 
    typeof(RequestToModel)
    
);


// MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("PruebaConnection");

builder.Services.AddDbContext<U20201b051DBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });


var app = builder.Build();

// Create database if not exists
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<U20201b051DBContext>())
{
    context.Database.EnsureCreated();
}

//Cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

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