using Microsoft.AspNetCore.Mvc;
using TechnologyKeeda.Web.Data;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PeopleController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var people = _context.Peoples.ToList();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.Peoples.Find(id);
            return View(people);
        }

        [HttpPost]
        public IActionResult Edit(People people)
        {
            _context.Peoples.Update(people);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.Peoples.Find(id);
            return View(people);
        }

        [HttpPost]
        public IActionResult Delete(People people)
        {
            _context.Peoples.Remove(people);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
