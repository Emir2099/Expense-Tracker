using Expense_Tracker.Models;
using Expense_Tracker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));



// Register AIService for dependency injection
builder.Services.AddHttpClient<AIService>(); // If it uses HttpClient
// or
builder.Services.AddScoped<AIService>(); // Depending on how you want to register the service

builder.Services.AddHttpClient<GeminiService>(client =>
{
    client.BaseAddress = new Uri("https://api.gemini.com/");
});


var app = builder.Build();









// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
