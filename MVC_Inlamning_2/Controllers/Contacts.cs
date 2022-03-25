using Microsoft.AspNetCore.Mvc;

namespace MVC_Inlamning_2.Controllers
{
    public class Contacts : Controller
    {
        [Route("contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
