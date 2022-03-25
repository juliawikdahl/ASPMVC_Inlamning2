using Microsoft.AspNetCore.Mvc;

namespace MVC_Inlamning_2.Controllers
{
    public class PageNotFound : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
