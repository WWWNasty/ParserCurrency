using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICurrencyProvider _currencyProvider;

        public HomeController(ILogger<HomeController> logger, ICurrencyProvider currencyProvider)
        {
            _logger = logger;

            _currencyProvider = currencyProvider;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _currencyProvider.GetExchangeRate());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}