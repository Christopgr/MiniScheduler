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
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private readonly MiniSchedulerContext _context;
        public SkillRepository(MiniSchedulerContext context) : base(context)
        {
            _context = context; 
        }

        public override async Task<List<Skill>> GetAll()
        {
            return await _context.Skill.Include(s => s.Employees).ToListAsync();
        }
    }
}
