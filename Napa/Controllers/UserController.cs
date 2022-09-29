using Microsoft.AspNetCore.Mvc;
using Napa.Models;
using Napa.Services;
using Napa.ViewModels;

namespace Napa.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(new LoginVM());

        [HttpPost]
        public IActionResult Index(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = new User()
            {
                Username = loginVM.Username,
                Password = loginVM.Password
            };
            _service.InsertUserAsync(user);
            return RedirectToAction("Index", "Home");
        }

    }
}

