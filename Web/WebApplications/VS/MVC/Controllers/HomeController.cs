using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

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

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse Response)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(Response);
                return View("Thanks", Response);
            }
            else return View();
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(item => item.WillAttend == true));
        }
    }
}