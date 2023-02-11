using Locutionis.Api.Feature.FiguresOfSpeech;
using Locutionis.Api.Feature.Questions;
using Locutionis.Api.Persistence;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Locutionis.UnitTests")]

var builder = WebApplication.CreateBuilder(args);

// Deployment configuration
var port = Environment.GetEnvironmentVariable("PORT");

if (port is not null)
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

// Database configuration
const string connectionString = "DataSource=locutionis_shared_db;mode=memory;cache=shared";

var keepAliveConnection = new SqliteConnection(connectionString);
keepAliveConnection.Open();

builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlite(connectionString));

// DI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Locutionis API",
        Description = "Locutionis API exposing some figures of speech and their definition.",
        Contact = new OpenApiContact
        {
            Name = "Pierre Bouillon",
            Url = new Uri("https://pbouillon.github.io/")
        },
        License = new OpenApiLicense
        {
            Name = "Apache License 2.0",
            Url = new Uri("https://github.com/pBouillon/Locutionis.Api/blob/main/LICENSE")
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

builder.Services.AddOutputCache();

var app = builder.Build();

// Seeding
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Seed();

// HTTP pipeline configuration
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseOutputCache();

// Endpoints configuration
var api = app.MapGroup("api");

api.MapGroup("figures-of-speech")
    .MapFiguresOfSpeechEndpoints();

api.MapGroup("questions")
    .MapQuestionsEndpoints();

app.Run();
