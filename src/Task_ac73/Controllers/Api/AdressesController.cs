using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Task_ac73.Models;

namespace Task_ac73.Controllers
{
    [Produces("application/json")]
    [Route("home/api/Adresses")]
    public class AdressesController : Controller
    {
        private ApplicationDbContext _context;

        public AdressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Adresses
        [HttpGet]
        public IEnumerable<Adress> GetAdress()
        {
            return _context.Adress;
        }
        [HttpGet("{count}", Name = "Fill")]
        public IEnumerable<Adress> Fill([FromRoute] int count)
        {
            for (int i = 0; i < count; i++)
            {
                _context.Adress.Add(new Adress()
                {
                    Building = i + "b",
                    Country = i + "C",
                    Postcode = i + "P",
                    Town = i + "T",
                    Street = i + "S"
                });
            }
            _context.SaveChanges();
            return _context.Adress;
        }
        
        // POST: api/Adresses
        [HttpPost]
        public IActionResult PostAdress([FromBody]dynamic data)
        {
            
            return Json(_context.Adress);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdressExists(int id)
        {
            return _context.Adress.Count(e => e.id == id) > 0;
        }
    }
}