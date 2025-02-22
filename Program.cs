using Microsoft.EntityFrameworkCore;
using theParodyJournal.Models;
using theParodyJournal.Services.ML;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer("Server=NAYAN-COMP-01\\SQLEXPRESS;Database=USERDB;Trusted_Connection=True;TrustServerCertificate=True;");
}); 




builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<NewsRecommendationService>();
builder.Services.AddSession();
var app = builder.Build();
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
