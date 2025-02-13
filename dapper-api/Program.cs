using dapper_api.DTOs;
using dapper_api.Entities;
using dapper_api.Interfaces;
using dapper_api.Models;
using FluentValidation;
using System.Reflection;

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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IApiDbContext, ApiDbContext>();
builder.Services.AddScoped<IValidator<ClientDTO>, ClientDTOValidator>();
builder.Services.AddRazorPages();
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5001;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// app.UseSwagger();
// app.UseSwaggerUI();


app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Debe ser (para que coincida con la política definida arriba)
app.UseCors("AllowBlazorApp");

app.MapRazorPages();

app.Urls.Add("http://localhost:5000/");

app.Run();