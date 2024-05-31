using lab_9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab_9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult ThrowDatabaseException()
        {
            // Симулируем исключение базы данных
            throw new InvalidOperationException("Произошла ошибка при работе с базой данных");
        }

        public IActionResult Throw404Exception()
        {
            throw new BadHttpRequestException("Введенный адрес не найден");
        }

        public IActionResult ThrowGenericException()
        {
            throw new Exception();
        }

        

    }
}
