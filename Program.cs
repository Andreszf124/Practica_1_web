using Microsoft.EntityFrameworkCore;
using Practica_1_web.Application.Services;
using Practica_1_web.Application.Interfaces;
using Practica_1_web.Infrastructure.Data;
using Practica_1_web.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=(localdb)\\mssqllocaldb;Database=Practica1Db;Trusted_Connection=true;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

// Register Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITelefonoRepository, TelefonoRepository>();

// Register Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<TelefonoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();
