using Microsoft.EntityFrameworkCore;
using Tareas.Api.Application.Contracts;
using Tareas.Api.Application.Tarea;
using Tareas.Api.Automapper.Tareas;
using Tareas.Api.Domain.Contracts;
using Tareas.Api.Domain.Services;
using Tareas.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITareaAppService, TareaAppService>();
builder.Services.AddTransient<ITareaDomainService, TareaDomainService>();


// Añade el DbContext al contenedor de servicios
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TareasDataBase")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


// Registra AutoMapper
builder.Services.AddAutoMapper(typeof(TareasMapperProfile));  

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(); // habilitar CORS
app.MapControllers();
app.Run();
