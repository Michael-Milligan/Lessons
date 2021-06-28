using Microsoft.AspNetCore.Mvc;

namespace SportsStore
{
    public class HomeController: Controller
    {
        public IActionResult Index() => View();
    }
}