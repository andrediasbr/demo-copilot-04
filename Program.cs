var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configuração de endpoints e middlewares
app.MapControllers();

app.Run();
