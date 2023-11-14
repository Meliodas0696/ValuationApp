using Microsoft.EntityFrameworkCore;
using ValuationApp.DataAccess;
using ValuationApp.DataAccess.Repository.Contracts;
using ValuationApp.DataAccess.Repository;
using ValuationApp.Services.Contract;
using ValuationApp.Services;
using ValuationApp.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Could not load 'Default' connection string");
}

builder.Services.AddDbContext<ValauatioDbContext>(options =>
            options.UseSqlServer(connectionString));


builder.Services.AddScoped<IVesselRepository, VesselRepository>();
builder.Services.AddScoped<IVesselService, VesselService>();

builder.Services.AddAutoMapper(typeof(VesselProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
