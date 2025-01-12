var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session and memory cache
builder.Services.AddDistributedMemoryCache(); // Required for session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout duration
    options.Cookie.HttpOnly = true; // Make the session cookie accessible only on the server
    options.Cookie.IsEssential = true; // Ensure cookie is always stored
});

var app = builder.Build();

// Ensure session middleware is added
app.UseSession();

app.UseStaticFiles(); // To serve static files like CSS

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "zadanie1",
    pattern: "{controller=Zadanie1}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "zadanie2",
    pattern: "{controller=Zadanie2}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "zadanie3",
    pattern: "{controller=Zadanie3}/{action=Index}/{id?}");

app.Run();