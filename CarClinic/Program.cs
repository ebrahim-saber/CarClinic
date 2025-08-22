using CarClinic.Application.UseCases.User;
using CarClinic.Domain.Interfaces;
using CarClinic.Infrastructure.Data;
using CarClinic.Infrastructure.Repositories;
using CarClinic.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Bind MongoDb settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserUseCase>();

// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
