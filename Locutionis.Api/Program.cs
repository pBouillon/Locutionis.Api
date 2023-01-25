using Locutionis.Api.Feature.FigureOfSpeech;
using Locutionis.Api.Persistence;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = "DataSource=locutionis_shared_db;mode=memory;cache=shared";

var keepAliveConnection = new SqliteConnection(connectionString);
keepAliveConnection.Open();

builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Locutionis API",
        Description = "Locutionis REST API exposing some figures of speech and their definition.",
        Contact = new OpenApiContact
        {
            Name = "Pierre Bouillon",
            Url = new Uri("https://pbouillon.github.io/")
        },
        License = new OpenApiLicense
        {
            Name = "Apache License 2.0",
            Url = new Uri("https://github.com/pBouillon/locutionis/blob/main/LICENSE")
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseOutputCache();

// Endpoints configuration
var api = app.MapGroup("api");

api.MapGroup("figures-of-speech")
    .MapFigureOfSpeechEndpoints();

app.Run();
