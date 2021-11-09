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
        public virtual DbSet<EmploySkill> EmploySkill { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employ>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.Employees)
                    .UsingEntity<EmploySkill>(
                         x => x.HasOne(x => x.Skill).WithMany().HasForeignKey(k=>k.SkillId),
                         x => x.HasOne(x => x.Employ).WithMany().HasForeignKey(k => k.EmployId)
                    );
        }
    }
}