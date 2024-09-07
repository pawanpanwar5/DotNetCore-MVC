using Microsoft.AspNetCore.Mvc;

namespace TechnologyKeeda.Web.Controllers
{
    public class TestController : Controller
    {
        static int a = 0;
        public IActionResult ShowButton()
        {
            //++a;
            return View(a);
        }
        public IActionResult ClickAction() 
        {
            ++a;
            return View("ShowButton",a);
        }
    }
}
