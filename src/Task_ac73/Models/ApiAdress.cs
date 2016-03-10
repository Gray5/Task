using System.Collections.Generic;
using System.Linq;

namespace Task_ac73.Models
{
    public class ApiAdress
    {
        public List<Adress> data;
        public int TotalPageCount;

        public ApiAdress(IQueryable<Adress> rawData, int pageCount)
        {
            data = rawData.ToList();
            TotalPageCount = pageCount;
        }
    }
}
