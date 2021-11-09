using System.ComponentModel.DataAnnotations;

namespace MiniScheduler.Domain.Models
{
    public class Employ : BaseEntity
    {
        public Employ()
        {
            Skills = new List<Skill>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
