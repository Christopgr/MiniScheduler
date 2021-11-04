using System.ComponentModel.DataAnnotations;

namespace MiniScheduler.Domain.Models
{
    public class Employ : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
