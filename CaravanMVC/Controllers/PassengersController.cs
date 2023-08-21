using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaravanMVC.DataAccess;
using CaravanMVC.Models;

namespace CaravanMVC.Controllers
{
    public class PassengersController : Controller
    {
        private readonly CaravanMvcContext _context;

        public PassengersController(CaravanMvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var passengers = _context.Passengers.ToList();
            return View(passengers);
        }

        [Route("/passengers/{id:int}")]
        public IActionResult Show(int Id)
        {
            var passengers = _context.Passengers;

            return View(passengers);
        }


        [Route("/wagons/{wagonId:int}/passengers/new")]
        public IActionResult New(int wagonId)
        {
            var wagon = _context.Wagons.Where(w => w.Id == wagonId).Include(w => w.Passengers).First();
            return View(wagon);
        }


        [HttpPost]
        [Route("/wagons/{wagonId:int}/passengers")]
        public IActionResult Create(Passenger passenger, int wagonId)
        {
            var wagon = _context.Wagons.Where(w => w.Id == wagonId).Include(w => w.Passengers).First();

            wagon.Passengers.Add(passenger);
            _context.SaveChanges();

            return Redirect($"/wagons/{wagon.Id}");
        }


    }
}