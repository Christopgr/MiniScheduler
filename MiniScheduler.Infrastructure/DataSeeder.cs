using MiniScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniScheduler.Infrastructure
{
    public class DataSeeder
    {
        public static void Initialize(MiniSchedulerContext context)
        {
            if (!context.Employ.Any())
            {
                var employees = new List<Employ>()
                 {
                    new Employ { /*Id = 1,*/ Name = "John", Surname="Peristeris", Email = "john@john.com", Telephone="6987092518", Created=DateTime.UtcNow },
                    new Employ { /*Id = 2,*/ Name = "Michael", Surname="Schumacher", Email = "michael@michael.com", Telephone="6972149743", Created=DateTime.UtcNow }
                 };
                context.Employ.AddRange(employees);
                context.SaveChanges();
            }
            if (!context.Skill.Any())
            {
                var skills = new List<Skill>()
                  {
                     new Skill { /* Id = 1 */ Name = "C#", Description = "Programming in c#", Created =DateTime.UtcNow }
                  };
                context.Skill.AddRange(skills);
                context.SaveChanges();
            }
        }
    }
}
