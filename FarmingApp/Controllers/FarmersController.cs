using FarmingApp.Data.Migrations;
using FarmingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmingApp.Controllers
{
    [Authorize]

    public class FarmersController : Controller
    {
        private readonly AppDbContext _context;

        public FarmersController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var farmers = await _context.Farmers.ToListAsync();
            return View(farmers);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Farmers farmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmers);
        }
    }
}
