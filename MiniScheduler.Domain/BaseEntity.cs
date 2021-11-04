using System.ComponentModel.DataAnnotations.Schema;

namespace MiniScheduler.Domain

{
    public class BaseEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}