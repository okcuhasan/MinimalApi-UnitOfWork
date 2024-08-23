using System.ComponentModel.DataAnnotations;

namespace UnitOfWorks.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
