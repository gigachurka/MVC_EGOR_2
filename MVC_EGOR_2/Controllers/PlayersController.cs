
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EGOR_2.Data;
using MVC_EGOR_2.Models;
namespace MVC_EGOR_2.Controllers
{
    public class PlayersController : Controller
    {
        private readonly AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _context.Players.FindAsync(id);
            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            _context.Update(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Clubs", new { id = player.ClubID });
        }
    }

}
