using Microsoft.AspNetCore.Mvc;
using FarmingApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using FarmingApp.Data.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace FarmingApp.Controllers
{
    [Authorize]

    public class FarmingItemsController : Controller
    {
        private readonly AppDbContext _context;

        public FarmingItemsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var farmingitems = await _context.FarmingItems.ToListAsync();
            return View(farmingitems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmingItems farmingitems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmingitems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmingitems);
        }
    }
}
