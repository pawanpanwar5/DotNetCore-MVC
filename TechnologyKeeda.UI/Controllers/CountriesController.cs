using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;
using TechnologyKeeda.UI.ViewModels.CountryViewModels;

namespace TechnologyKeeda.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            List<CountryViewModel> countryVm = new List<CountryViewModel>();
            var countries = _countryRepo.GetAll();
            foreach(var country in countries)
            {
                countryVm.Add(new CountryViewModel { Id=country.Id, Name = country.Name });
            }
            return View(countryVm);
        }
        [HttpGet]
        public IActionResult Create()
        {
           CreateCountryViewModel country = new CreateCountryViewModel();
            return View(country);
        }
        [HttpPost]
        public IActionResult Create(CreateCountryViewModel countryVm)
        {
            var country = new Country { Name = countryVm.Name }; 
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var country = _countryRepo.GetById(id);
            CountryViewModel countryVm = new CountryViewModel 
            { 
                Id =  country.Id, Name = country.Name
            };
            return View(countryVm);
        }
        [HttpPost]
        public IActionResult Edit(CountryViewModel countryVm)
        {
            var country = new Country
            {
                Id = countryVm.Id,
                Name = countryVm.Name
            };
           _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
