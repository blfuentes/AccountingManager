using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountingManager.UI.Controllers
{
    public class CalculoController : Controller
    {
        private readonly ILogger<CalculoController> _logger;

        public CalculoController(ILogger<CalculoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}