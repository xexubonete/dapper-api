using Dapper.Domain.Interfaces;
using Dapper.Infrastructure.Models;
using FluentValidation;
using System.Reflection;
using Dapper.Domain.Dtos;
using Dapper.Application.Validators;

var builder = WebApplication.CreateBuilder(args);
// builder.Configuration
//     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//     .AddEnvironmentVariables();
builder.Configuration.AddEnvironmentVariables();
if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddScoped<IApiDbContext, ApiDbContext>();
builder.Services.AddScoped<IValidator<ClientDto>, ClientDtoValidator>();
builder.Services.AddRazorPages();
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5001;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        b =>
        {
            b.WithOrigins("https://localhost:7035")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseCors("AllowBlazorApp");

app.UseAuthorization();

app.MapControllers();

// Debe ser (para que coincida con la política definida arriba)

app.MapRazorPages();

app.Run();