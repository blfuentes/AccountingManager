using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountingManager.UI.Models;
using AccountManager.DAL.DataService;
using AccountManager.DAL.DTO;

namespace AccountingManager.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDataService<BalanceDTO> _balanceDataService;

        public HomeController(
            ILogger<HomeController> logger,
            IDataService<BalanceDTO> balanceDataService)
        {
            _logger = logger;
            _balanceDataService = balanceDataService;
        }

        public IActionResult Index()
        {
            var balances = _balanceDataService.GetCollection();
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
    }
}
