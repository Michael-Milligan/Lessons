using Microsoft.AspNetCore.Mvc;
namespace SportsStore.Controllers
{
    class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
