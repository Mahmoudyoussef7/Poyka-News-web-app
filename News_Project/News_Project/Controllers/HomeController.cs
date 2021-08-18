using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News_Project.Models;

namespace News_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsDbContext context;

        public HomeController(ILogger<HomeController> logger ,NewsDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult contact()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveContact(ContactUS model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Contacts.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }
            else
                return View(model);
        }

        public IActionResult Messages()
        {
            return View(context.Contacts.ToList());
        }
        
        public IActionResult NewsByCategory(int id)
        {
            ViewBag.cat = context.Categories.FirstOrDefault(n => n.ID == id);
            return View(context.News.Where(n=>n.Cat_Id==id).OrderByDescending(e=>e.Date).ToList());
        }
        public IActionResult DeleteNews(int id)
        {
            ViewBag.cat = context.Categories.FirstOrDefault(n => n.ID == id);
            context.News.Remove(context.News.FirstOrDefault(d => d.ID == id));
            context.SaveChanges();
            return RedirectToAction("Index");
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
