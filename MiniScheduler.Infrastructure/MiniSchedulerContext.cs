using Microsoft.EntityFrameworkCore;
using MiniScheduler.Domain.Models;

namespace MiniScheduler.Infrastructure
{
    public class MiniSchedulerContext : DbContext
    {
        public MiniSchedulerContext(DbContextOptions<MiniSchedulerContext> options) : base(options)
        {

        }

        public virtual DbSet<Employ> Employ { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employ>()
            .HasMany(p => p.Skills)
            .WithMany(p => p.Employees)
            .UsingEntity(j => j.ToTable("EmploySkill"));
        }
    }
}