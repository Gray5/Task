using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Task_ac73.Models;

namespace Task_ac73.Controllers
{
    public class Adresses2Controller : Controller
    {
        private ApplicationDbContext _context;

        public Adresses2Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Adresses2
        public IActionResult Index()
        {
            return View(_context.Adress.ToList());
        }

        // GET: Adresses2/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Adress adress = _context.Adress.Single(m => m.id == id);
            if (adress == null)
            {
                return HttpNotFound();
            }

            return View(adress);
        }

        // GET: Adresses2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adresses2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Adress.Add(adress);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        // GET: Adresses2/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Adress adress = _context.Adress.Single(m => m.id == id);
            if (adress == null)
            {
                return HttpNotFound();
            }
            return View(adress);
        }

        // POST: Adresses2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Update(adress);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        // GET: Adresses2/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Adress adress = _context.Adress.Single(m => m.id == id);
            if (adress == null)
            {
                return HttpNotFound();
            }

            return View(adress);
        }

        // POST: Adresses2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Adress adress = _context.Adress.Single(m => m.id == id);
            _context.Adress.Remove(adress);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
