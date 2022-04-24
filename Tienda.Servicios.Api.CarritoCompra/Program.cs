using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tienda.Servicios.Api.CarritoCompra.Persistence;
using Tienda.Servicios.Api.CarritoCompra.Services;
using Tienda.Servicios.Api.CarritoCompra.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IService, Service>();
builder.Services.Configure<MicroServicios>(builder.Configuration.GetSection(nameof(MicroServicios)));
builder.Services.AddCors(x => x.AddPolicy("x", o =>
 {
     o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
 }));


builder.Services.AddHttpClient(nameof(MicroServicios.Libros), cfg =>
 {
     cfg.BaseAddress = new Uri(builder
         .Configuration
         .GetSection(nameof(MicroServicios))[nameof(MicroServicios.Libros)]);
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("x");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
