using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_EGOR_2.Data;
using System.Data;
 void TestPlayersTable()
{

    try
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\path_to\EGORMVC.accdb;";
        DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

        string query = "SELECT * FROM Roster";
        DataTable playersTable = dbHelper.ExecuteQuery(query);
        if (playersTable.Rows.Count > 0)
        {
            foreach (DataRow row in playersTable.Rows)
            {
                Console.WriteLine($"PlayerID: {row["PlayerID"]}, Name: {row["PlayerName"]}, Position: {row["Position"]}");
            }
        }
        else
        {
            Console.WriteLine("Таблица 'Roster' существует, но она пуста.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DatabaseHelper>(provider =>
    new DatabaseHelper("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=path_to_database.accdb"));

var connectionString = builder.Configuration.GetConnectionString("AccessDatabase");

builder.Services.AddSingleton(new DatabaseHelper(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Clubs}/{action=Index}/{id?}");

app.Run();
