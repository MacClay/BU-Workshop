using dotnetRPG.Context;
using dotnetRPG.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<PlayerDBContext>(x => x.UseSqlite("Data Source=workshop.db"));

builder.Services.AddDbContext<PlayerDBContext>(x => x.UseSqlServer("Server=tcp:bu-workshop250365.database.windows.net,1433;Initial Catalog=rpg;Persist Security Info=False;User ID=parinya;Password=Mac123mac456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddTransient<IPlayer, SqlitePlayer>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();
