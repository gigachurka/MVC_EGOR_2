


using Microsoft.AspNetCore.Mvc;
using MVC_EGOR_2.Data;
using MVC_EGOR_2.Models;

namespace MVC_EGOR_2.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DatabaseHelper _dbHelper;

        public PlayersController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpPost("update/{playerId}")]
        public IActionResult UpdatePlayer(int playerId, [FromBody] Player player)
        {
            try
            {
                string query = $@"
            UPDATE Roster
            SET PlayerName = '{player.PlayerName}',
                Position = '{player.Position}'
            WHERE PlayerID = {playerId}";

                _dbHelper.ExecuteNonQuery(query);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
