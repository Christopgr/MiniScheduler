using Microsoft.EntityFrameworkCore;
using MiniScheduler.Domain.Models;
using MiniScheduler.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniScheduler.DataAccessLayer.Repositories
{
    public class EmployRepository : RepositoryBase<Employ>, IEmployRepository
    {
        private readonly MiniSchedulerContext _context;
        public EmployRepository(MiniSchedulerContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Employ>> GetAll()
        {
            return await _context.Employ.Include(e=>e.Skills).ToListAsync();
        }

        public override async Task<Employ> Update(Employ employ)
        {
            _context.Update(employ);
            await _context.SaveChangesAsync();
            return employ;
        }
    }
}
