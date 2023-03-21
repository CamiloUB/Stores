using Microsoft.EntityFrameworkCore;
using Stores.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

  
// Inyecci�n de dependencia del servicio SQL Server     
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* La sgte instrucci�n sirve para que nuestra API pueda ser consumida desde
cualquier sitio */

app.UseHttpsRedirection();

app.UseAuthorization(); app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());




app.MapControllers();



app.Run();
