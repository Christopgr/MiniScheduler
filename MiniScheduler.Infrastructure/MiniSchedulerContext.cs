using Microsoft.EntityFrameworkCore;
using MiniScheduler.Domain.Models;

namespace MiniScheduler.Infrastructure
{
    public class MiniSchedulerContext : DbContext
    {
        public MiniSchedulerContext(DbContextOptions<MiniSchedulerContext> options) : base(options)
        {

        }

        public virtual DbSet<Employ> Employees { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
    }
}