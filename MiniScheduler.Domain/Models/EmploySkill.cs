using System.ComponentModel.DataAnnotations;

namespace MiniScheduler.Domain.Models
{
    public class EmploySkill : BaseEntity
    {
        public int EmployId { get; set; }
        public int SkillId { get; set; }

        public virtual Employ Employ { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
