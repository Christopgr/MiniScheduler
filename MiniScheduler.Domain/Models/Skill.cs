using System.ComponentModel.DataAnnotations;

namespace MiniScheduler.Domain.Models
{
    public class Skill : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

    }
}
