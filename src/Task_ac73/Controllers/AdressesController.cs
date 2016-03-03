using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Task_ac73.Models;

namespace Task_ac73.Controllers
{
    [Produces("application/json")]
    [Route("api/Adresses")]
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

        // GET: api/Adresses/5
        [HttpGet("{id}", Name = "GetAdress")]
        public IActionResult GetAdress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Adress adress = _context.Adress.Single(m => m.id == id);

            if (adress == null)
            {
                return HttpNotFound();
            }

            return Ok(adress);
        }

        // PUT: api/Adresses/5
        [HttpPut("{id}")]
        public IActionResult PutAdress(int id, [FromBody] Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != adress.id)
            {
                return HttpBadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Adresses
        [HttpPost]
        public IActionResult PostAdress([FromBody] Adress adress)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Adress.Add(adress);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdressExists(adress.id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetAdress", new { id = adress.id }, adress);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdress(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Adress adress = _context.Adress.Single(m => m.id == id);
            if (adress == null)
            {
                return HttpNotFound();
            }

            _context.Adress.Remove(adress);
            _context.SaveChanges();

            return Ok(adress);
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