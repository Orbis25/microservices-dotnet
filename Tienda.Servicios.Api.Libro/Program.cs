
using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.Libro.Services;
using Tienda.Servicios.RabbitMQ.Bus.BusRabbit;
using Tienda.Servicios.RabbitMQ.Bus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<IService, Service>();
builder.Services.AddCors(opt => opt.AddPolicy("allow",(x) =>
{
    x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddTransient<IRabbitEventBus, RabbitEventBusService>();

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
