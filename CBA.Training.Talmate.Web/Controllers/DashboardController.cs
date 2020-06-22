﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CBA.Training.Talmate.Web.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }
    }
}
