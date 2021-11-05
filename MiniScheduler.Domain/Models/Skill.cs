using System.ComponentModel.DataAnnotations;

namespace MiniScheduler.Domain.Models
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            Employees = new List<Employ>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ICollection<Employ> Employees { get; set; }

    }
}
