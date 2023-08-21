using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaravanMVC.DataAccess;
using CaravanMVC.Models;

namespace CaravanMVC.Controllers
{
    public class WagonsController : Controller
    {
        private readonly CaravanMvcContext _context;

        public WagonsController(CaravanMvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var wagons = _context.Wagons.ToList();
            return View(wagons);
        }
        
        
    }
}
