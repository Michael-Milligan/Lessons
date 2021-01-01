using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm(GuestResponse Response)
        {
            //TODO: store response from the guest
            return View();
        }
    }
}