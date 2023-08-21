using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaravanMVC.DataAccess;
using CaravanMVC.Models;

namespace CaravanMVC.Controllers
{
    public class OverviewController : Controller
    {
        private readonly CaravanMvcContext _context;

        public OverviewController(CaravanMvcContext context)
        {
            _context = context;
        }


        [Route("/overview")]
        public IActionResult Show()
        {
            var passengers = _context.Passengers;
            
            List<string> Destinations = new List<string>();

            foreach (var passenger in passengers)
            {
                Destinations.Add(passenger.Destination);
            }
            ViewBag.Destinations = Destinations;
            return View();
        }


    }
}