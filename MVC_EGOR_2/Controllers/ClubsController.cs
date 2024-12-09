using Microsoft.AspNetCore.Mvc;
using MVC_EGOR_2.Data;
using MVC_EGOR_2.Models;
using System.Collections.Generic;
using System.Data;

namespace MVC_EGOR_2.Controllers
{
    public class ClubsController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public ClubsController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IActionResult Index()
        {
            string query = "SELECT * FROM Clubs";
            DataTable clubsTable = _dbHelper.ExecuteQuery(query);

            var clubs = new List<Club>();
            foreach (DataRow row in clubsTable.Rows)
            {
                int clubId = row["ClubID"] != DBNull.Value ? Convert.ToInt32(row["ClubID"]) : 0;
                string clubName = row["ClubName"] != DBNull.Value ? row["ClubName"].ToString() : string.Empty;

                clubs.Add(new Club
                {
                    ClubID = clubId,
                    ClubName = clubName
                });
            }

            return View(clubs);
        }

        public IActionResult Players(int clubId)
        {
            string query = $"SELECT * FROM Roster WHERE ClubID = {clubId}";
            DataTable playersTable = _dbHelper.ExecuteQuery(query);

            var players = new List<Player>();
            foreach (DataRow row in playersTable.Rows)
            {
                int playerId = row["PlayerID"] != DBNull.Value ? Convert.ToInt32(row["PlayerID"]) : 0;
                int clubIdFromRow = row["ClubID"] != DBNull.Value ? Convert.ToInt32(row["ClubID"]) : 0;
                string playerName = row["PlayerName"] != DBNull.Value ? row["PlayerName"].ToString() : string.Empty;
                string position = row["Position"] != DBNull.Value ? row["Position"].ToString() : string.Empty;

                players.Add(new Player
                {
                    PlayerID = playerId,
                    PlayerName = playerName,
                    Position = position,
                    ClubID = clubIdFromRow
                });
            }

            return View(players);
        }
    }

}
