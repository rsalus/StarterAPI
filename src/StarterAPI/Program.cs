//  ADD OUR FIRST CODE HERE
//  =======================



/*
using Microsoft.EntityFrameworkCore;
using StarterAPI;

// Create the application
var builder = WebApplication.CreateBuilder(args);

// Add our database
builder.Services.AddDbContext<MyUserContext>(opt => opt.UseInMemoryDatabase("StarterDb"));

// Add our schema
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Build the application
var app = builder.Build();

// Create our Swagger page
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "StarterAPI v1");
});

//  ADD OUR API CODE HERE
//  =====================
//  We want a Get, Put, and Delete method
//  These will form the basis of our CRUD
//  operations.

app.MapPut("/CreateUser", (int userId, MyUserContext context) =>
{
    var user = new MyUser(userId);
    context.Users.Add(user);
    context.SaveChanges();
    return;
});

app.MapGet("/GetUser", (int userId, MyUserContext context) =>
{
    var user = context.Users.Find(userId);
    return user;
});

app.MapDelete("/DeleteUser", (int userId, MyUserContext context) =>
{
    var user = context.Users.Find(userId);
    context.Users.Remove(user);
    context.SaveChanges();
    return;
});

app.Run();
*/