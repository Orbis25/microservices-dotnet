using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.Autor.Mappings;
using Tienda.Servicios.Api.Autor.Services;
using Tienda.Servicios.Api.Autor.Services.Autor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<AutorLibro>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

builder.Services.AddScoped<IAutorLibroService, AutorService>();

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
