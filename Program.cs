
using API_RESTful_Project.Models;
using API_RESTful_Project.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de las políticas de Cross-Origin Resource Sharing (CORS) para permitir que ReactJS acceda a la API.
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


builder.Services.AddScoped<PasswordService>();

// Configuración de las interfaces
builder.Services.AddScoped<ILinkService, LinkService>();
builder.Services.AddControllers();

// Configuración de la base de datos y la clase de contexto
builder.Services.AddDbContext<DbContextApp>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuración de Swagger/OpenAPI
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

app.UseCors("ReactAppPolicy"); // Usar la política CORS creada

app.UseAuthorization();

app.MapControllers();

app.Run();

// Realizar una solicitud POST a la ruta "api/register/seed-users"
await SeedUsersAsync();

async Task SeedUsersAsync()
{
    using (HttpClient client = new HttpClient())
    {
        string baseUrl = "https://localhost:5001"; 
        string seedUsersEndpoint = "api/register/seed-users";

        // Configuración de la base URL
        client.BaseAddress = new Uri(baseUrl);

        // Realiza una solicitud POST a la ruta "api/register/seed-users"
        HttpResponseMessage response = await client.PostAsync(seedUsersEndpoint, null);

        // Verifica si la solicitud fue exitosa
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Usuarios ficticios agregados con éxito.");
        }
        else
        {
            Console.WriteLine("Error al agregar usuarios ficticios. Código de estado: " + response.StatusCode);
        }
 }  }