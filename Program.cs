
using API_RESTful_Project.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de las pol�ticas de Cross-Origin Resource Sharing (CORS) para permitir que ReactJS acceda a la API.
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

// Configuraci�n de la base de datos y la clase de contexto
builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuraci�n de Swagger/OpenAPI
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

app.UseRouting();

app.UseCors("ReactAppPolicy"); // Usar la pol�tica CORS creada

app.UseAuthorization();

app.MapControllers();

app.Run();
