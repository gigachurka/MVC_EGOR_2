using Microsoft.EntityFrameworkCore;
using MVC_EGOR_2.Data;
using EntityFrameworkCore.Jet; // Подключение библиотеки

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к Access через Jet
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseJet(builder.Configuration.GetConnectionString("AccessDatabase")));

// Добавление MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
