using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Users.Entities;
using Users.Helpers;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<User> Users = FileHelpers.ReadUsers();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new UserAddViewModel();
            vm.User = new User();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(UserAddViewModel vm)
        {
            var user = vm.User;
            user.Id = Guid.NewGuid().ToString();
            Users.Add(user);
            var indexvm = new UsersViewModel()
            {
                Users = Users
            };
            return View("Index", indexvm);
        }

        public IActionResult Details(string id)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        public IActionResult Index()
        {
            var vm = new UsersViewModel()
            {
                Users = Users
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}