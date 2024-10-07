using Microsoft.EntityFrameworkCore;
using StarterMicroservice.API;

// Create the application
var builder = WebApplication.CreateBuilder(args);

// Aspire service defaults
builder.AddServiceDefaults();

// Extension method to DI services
builder.AddApplicationServices();

// Build the application
var app = builder.Build();

// Aspire health checks
app.MapDefaultEndpoints();

// Env-specific configuration
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // We need to seed the local db
    /* Uncomment this after running ef migration
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<MyUserContext>();
        context.Database.Migrate();
    }
    */
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Add Swagger page
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarterMicroservice.API v1");
});

// Add custom endpoints via extension
// This is essentially our controller
app.AddApiEndpoints();

// Configure HTTP Pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseRequestTimeouts();
app.UseOutputCache();

// Setup UserRecordController route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();