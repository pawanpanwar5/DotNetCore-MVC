using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.WebHost.Controllers
{
    public class VenuesController : Controller
    {
        private readonly IVenueRepo _venueRepo;

        public VenuesController(IVenueRepo venueRepo)
        {
            _venueRepo = venueRepo;
        }

        public async Task<IActionResult> Index()
        {
            
                List<VenueViewModel> venueVm = new List<VenueViewModel>();
                var venues = await _venueRepo.GetAll();
                foreach (var venue in venues)
                {
                venueVm.Add(new VenueViewModel { Id = venue.Id, Name = venue.Name,
                Address = venue.Address, SeatCapacity = venue.SeatCapacity});
                }
                return View(venueVm);
            
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVenueViewModel venueVm)
        {
            var venue = new Venue 
            {
                Name = venueVm.Name,
                Address = venueVm.Address,
                SeatCapacity = venueVm.SeatCapacity
            };
            await _venueRepo.Save(venue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var venue = await _venueRepo.GetById(id);
            VenueViewModel venueVm = new VenueViewModel
            {
                Id = venue.Id,
                Name = venue.Name,
                Address  = venue.Address,
                SeatCapacity = venue.SeatCapacity
            };
            return View(venueVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VenueViewModel venueVm)
        {
            var venue = new Venue
            {
                Id = venueVm.Id,
                Name = venueVm.Name,
                Address = venueVm.Address,
                SeatCapacity = venueVm.SeatCapacity
            };
            await _venueRepo.Edit(venue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _venueRepo.GetById(id);
            await _venueRepo.RemoveData(venue);
            return RedirectToAction("Index");
        }
    }
}
