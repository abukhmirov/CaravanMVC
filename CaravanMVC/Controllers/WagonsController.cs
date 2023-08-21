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

        [Route("/wagons/{id:int}")]
        public IActionResult Show(int Id)
        {
            var wagon = _context.Wagons.Include(w => w.Passengers).FirstOrDefault(w => w.Id == Id);

            return View(wagon);
        }


        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Wagon wagon)
        {
            _context.Wagons.Add(wagon);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


    }
}
