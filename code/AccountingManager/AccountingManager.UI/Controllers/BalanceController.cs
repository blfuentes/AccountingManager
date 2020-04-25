using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace AccountingManager.UI.Controllers
{
    public class BalanceController : Controller
    {
        private readonly ILogger<BalanceController> _logger;

        public BalanceController(ILogger<BalanceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Mes(int monthid)
        {
            ViewData["month"] = monthid;

            return View();
        }
    }
}