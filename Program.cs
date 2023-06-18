global using coreprac.Models;
global using coreprac.Services;
global using coreprac.Dtos.Character;
global using Microsoft.EntityFrameworkCore;
global using coreprac.Data;
global using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: "corepracOrigins",
    policy => {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();

    // "DefaultConnection": "Server=(localdb)\\mssqllocaldb; Database=coreprac1; Trusted_Connection=true; TrustServerCertificate=true;"
    // "DefaultConnection": "Server=DESKTOP-F5JKMJA; Initial Catalog=coreproc2;Integrated Security=true;"
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
