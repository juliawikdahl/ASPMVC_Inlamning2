using Microsoft.AspNetCore.Mvc;

namespace MVC_Inlamning_2.Controllers
{
    public class Services : Controller
    {
        [Route("service")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
