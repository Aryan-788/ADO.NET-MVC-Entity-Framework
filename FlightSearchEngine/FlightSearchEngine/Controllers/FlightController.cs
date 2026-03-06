using FlightSearchEngine.Data;
using Microsoft.AspNetCore.Mvc;
using FlightSearchEngine.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightSearchEngine.Controllers
{
    public class FlightController : Controller
    {
        private readonly DatabaseHelper _db;

        public FlightController(IConfiguration configuration) {
            _db = new DatabaseHelper(configuration);

        }
       

        public async Task<IActionResult> Index()
        {
            var model = new SearchViewModel();

            var source = await _db.GetSourcesAsync();
            var destination = await _db.GetDestinationsAsync();

            model.SourceList = new SelectList(source);
            model.DestinationList = new SelectList(destination);


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchFlights(SearchViewModel model)
        {
            var results = await _db.SearchFlightsAsync(
            model.Source,
            model.Destination,
            model.NumberOfPersons);

            Console.WriteLine("Result Count: " + results.Count);

            foreach (var modelState in ModelState)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    Console.WriteLine($"Error in {modelState.Key}: {error.ErrorMessage}");
                }
            }

            if (!ModelState.IsValid)
            {
                var source = await _db.GetSourcesAsync();
                var destination = await _db.GetDestinationsAsync();

                model.SourceList = new SelectList(source);
                model.DestinationList = new SelectList(destination);

                return View("Index", model);
            }

            var result = await _db.SearchFlightsAsync(model.Source, model.Destination, model.NumberOfPersons);

            return View("Results", result);
        }
    }
}
