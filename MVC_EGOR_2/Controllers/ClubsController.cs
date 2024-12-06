using Microsoft.AspNetCore.Mvc;
using MVC_EGOR_2.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC_EGOR_2.Controllers
{
    public class ClubsController : Controller
    {
        private readonly AppDbContext _context;

        public ClubsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _context.Clubs.ToListAsync();
            return View(clubs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var players = await _context.Players.Where(p => p.ClubID == id).ToListAsync();
            return View(players);
        }
    }

}
