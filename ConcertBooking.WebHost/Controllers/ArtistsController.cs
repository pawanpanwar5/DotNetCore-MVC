using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.ConcertBooking.Repositories;

namespace ConcertBooking.WebHost.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistRepo _artistRepo;
        private readonly IUtilityRepo _utilityRepo;
        private string containerName = "ArtistImage";

        public ArtistsController(IArtistRepo artistRepo, IUtilityRepo utilityRepo)
        {
            _artistRepo = artistRepo;
            _utilityRepo = utilityRepo;
        }

        public async Task<IActionResult> Index()
        {

            List<ArtistViewModel> artistVm = new List<ArtistViewModel>();
            var artists = await _artistRepo.GetAll();
            foreach (var artist in artists)
            {
                artistVm.Add(new ArtistViewModel
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Bio = artist.Bio,
                    ImageUrl = artist.ImageUrl
                });
            }
            return View(artistVm);


        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateArtistViewModel artistVm)
        {
            var artist = new Artist
            {
                Name = artistVm.Name,
                Bio = artistVm.Bio,
            };
            if(artistVm.ImageUrl != null)
            {
                artist.ImageUrl = await _utilityRepo.SaveImage(containerName, artistVm.ImageUrl);
            }
            await _artistRepo.Save(artist);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var artist = await _artistRepo.GetById(id);
            EditArtistViewModel venueVm = new EditArtistViewModel
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                ImageUrl = artist.ImageUrl
                
            };
            return View(venueVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditArtistViewModel artistVm)
        {
            var artist = await _artistRepo.GetById(artistVm.Id);


            artist.Name = artistVm.Name;
            artist.Bio = artistVm.Bio;
            
            if(artistVm.ChooseImage != null)
            {
                artist.ImageUrl = await _utilityRepo.EditImage(containerName, artistVm.ChooseImage, artist.ImageUrl);
            }
            await _artistRepo.Edit(artist);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var artist = await _artistRepo.GetById(id);
            await _artistRepo.RemoveData(artist);
            return RedirectToAction("Index");
        }
    }
}
