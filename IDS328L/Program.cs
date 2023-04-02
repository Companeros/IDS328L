using IDS328L.Models;
using IDS328L.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apikey = builder.Configuration["ConnectionStrings:FinalProject"];
builder.Services.AddDbContext<FinalProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProject")));
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IActividadServices, ActividadServices>();
builder.Services.AddScoped<IPersonaServices, PersonaServices>();

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
