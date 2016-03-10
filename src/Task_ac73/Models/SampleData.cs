using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Task_ac73.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            for (int i = 0; i < 100000; i++)
            {
                context.Adress.Add(new Adress()
                {
                    Building = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray()),
                    Country = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray()),
                    Postcode = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray()),
                    Town = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray()),
                    Street = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray())
                });
            }
            context.SaveChanges();
        }
    }
}
