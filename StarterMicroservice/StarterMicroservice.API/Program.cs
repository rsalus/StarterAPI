using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StarterMicroservice.API;

// Create the application
var builder = WebApplication.CreateBuilder(args);

// Create our (in-memory) database
builder.Services.AddDbContext<MyUserContext>(opt => opt.UseInMemoryDatabase("StarterDb"));

// Add our swagger schema
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "StarterMicroservice API", Version = "v1" });
});

// Build the application
var app = builder.Build();

// Create our Swagger page
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarterMicroservice.API v1");
});

//  ADD OUR API CODE HERE
//  =====================
//  We want a Get, Put, and Delete method
//  These will form the basis of our CRUD
//  operations.

app.Run();