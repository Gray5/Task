using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Task_ac73.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task_ac73.Controllers
{
    [Produces("application/json")]
    [Route("/api/Adresses")]
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
            JObject jdata = JObject.FromObject(data);
            int count = int.Parse(jdata["count"].ToString());
            int page = int.Parse(jdata["page"].ToString());
            bool isAscending = bool.Parse(jdata["sortDirection"].ToString());
            Expression<Func<Adress, bool>> expression = adress => adress.Country.Contains(jdata["filters"]["country"].ToString())
                                                               && adress.Town.Contains(jdata["filters"]["town"].ToString())
                                                               && adress.Street.Contains(jdata["filters"]["street"].ToString())
                                                               && adress.Building.Contains(jdata["filters"]["building"].ToString())
                                                               && adress.Postcode.Contains(jdata["filters"]["postcode"].ToString())
                                                               && adress.Date.ToString().Contains(jdata["filters"]["date"].ToString());
            var outData = _context.Adress.Where(expression);
            switch (jdata["sortColumn"].ToString())
            {
                case "0":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Country) : outData.OrderByDescending(adress => adress.Country);
                    break;
                case "1":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Town) : outData.OrderByDescending(adress => adress.Town);
                    break;
                case "2":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Street) : outData.OrderByDescending(adress => adress.Street);
                    break;
                case "3":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Building) : outData.OrderByDescending(adress => adress.Building);
                    break;
                case "4":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Postcode) : outData.OrderByDescending(adress => adress.Postcode);
                    break;
                case "5":
                    outData = (isAscending) ? outData.OrderBy(adress => adress.Date) : outData.OrderByDescending(adress => adress.Date);
                    break;
                default:
                    break;
            }
            outData = outData.Skip((page - 1) * count).Take(count);
            return Json(new ApiAdress(outData,_context.Adress.Count()/count));
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