using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_EGOR_2.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы контроллеров с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// Пример использования:
var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\mcb.local\\RoamingProfiles$\\StudentsData\\1227420\\Documents\\EGORMVC.accdb;";
var dbHelper = new DatabaseHelper(connectionString);
dbHelper.TestConnection();  // Это проверит соединение с базой данных

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
