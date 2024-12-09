using Microsoft.AspNetCore.Mvc;
using MVC_EGOR_2.Data;
using System.Data;

namespace MVC_EGOR_2.Controllers
{
    public class ClubsController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public ClubsController()
        {
            // Укажите правильный путь к вашей базе данных Access
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\path_to\\EGORMVC.accdb";
            _dbHelper = new DatabaseHelper(connectionString);
        }

        public IActionResult Index()
        {
            string query = "SELECT * FROM Clubs";
            DataTable clubsTable = _dbHelper.ExecuteQuery(query);
            return View(clubsTable);
        }
    }
}
