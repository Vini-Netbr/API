using API.Data;
using API.Services.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API.Services;
using API.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando o DbContext com a string de conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>

{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); // Correção aqui
});

builder.Services.AddScoped<Interface_Produto, Service_Produto>();
builder.Services.AddScoped<Usuario_Interface, Usuario_Service>();

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
