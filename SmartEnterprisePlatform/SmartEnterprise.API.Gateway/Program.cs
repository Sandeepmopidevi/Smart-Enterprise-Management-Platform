using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add ocelot.json to configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// 🔹 Add Ocelot services
builder.Services.AddOcelot();

// Optional: Add Swagger (for gateway debugging, not required for routing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Swagger for dev environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Use Ocelot Middleware as final step
await app.UseOcelot();

app.Run();
