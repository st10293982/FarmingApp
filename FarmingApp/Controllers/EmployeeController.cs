using FarmingApp.Data;
using FarmingApp.Data.Migrations;
using FarmingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FarmingApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var farmingitems = await _context.FarmingItems
                  .Include(f => f.Employee)
                  .ToListAsync();
            return View(farmingitems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee farmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmers);
        }
        public async Task<IActionResult> Products(int id)
        {
            var farmer = await _context.Employees
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }
    }
}
