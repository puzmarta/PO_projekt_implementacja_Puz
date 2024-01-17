using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PO_projekt_implementacja_Puz.Data;
using PO_projekt_implementacja_Puz.Models;

namespace PO_projekt_implementacja_Puz.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ApplicationViewModelContext _context;

        public ApplicationsController(ApplicationViewModelContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.GetApplicationViewModels();
            return View(await applicationContext);

        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

         

            return View();
        }

    }
}
