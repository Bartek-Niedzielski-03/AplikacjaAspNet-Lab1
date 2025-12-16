using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium1.Controllers
{
    public class LabelController : Controller
    {
        private readonly AppDbContext _context;

        public LabelController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var labels = _context.Labels
                .AsNoTracking()
                .ToList();

            return View(labels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new LabelEntity());
        }

        [HttpPost]
        public IActionResult Create(LabelEntity model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Labels.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var label = _context.Labels.Find(id);
            if (label == null)
                return NotFound();

            return View(label);
        }

        [HttpPost]
        public IActionResult Edit(LabelEntity model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Labels.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}