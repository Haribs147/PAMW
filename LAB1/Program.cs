var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure middleware for static files
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

// Add an endpoint to handle AJAX POST requests from "Zadanie 4"
app.MapPost("/Zadanie4/SubmitData", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    
    // Here you can process the received data as needed
    return Results.Json($"Dane odebrane essa: {body}");
});

app.Run();
