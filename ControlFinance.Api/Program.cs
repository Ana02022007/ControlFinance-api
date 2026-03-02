using Microsoft.EntityFrameworkCore;
using ControlFinance.Application;
using ControlFinance.Infrastructure;

// Cria o builder da aplicação ASP.NET.
var builder = WebApplication.CreateBuilder(args);

// Registra suporte a controllers.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters
            .Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Configura o DbContext com SQLite e assembly de migrations.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=ControlFinance.db",
        b => b.MigrationsAssembly("ControlFinance.Infrastructure")));

// Registra serviços de documentação da API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra dependências da camada de aplicação.
builder.Services.AddApplication();
// Registra dependências da camada de infraestrutura.
builder.Services.AddInfrastructure();

// Configura política de CORS para o front-end em desenvolvimento.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDev", policy =>
    {
        policy
            .WithOrigins(
    "http://localhost:5173",
    "http://localhost:5174",
    "http://localhost:5175"
) // ← VITE
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Habilita geração da documentação Swagger.
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

// Força redirecionamento para HTTPS.
app.UseHttpsRedirection();

app.UseCors("AllowReactDev");
// Mapeia os endpoints dos controllers.
app.MapControllers();

// Inicia a aplicação.
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}