﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountingManager.UI.Controllers
{
    public class SueldoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}