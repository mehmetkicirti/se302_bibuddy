using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string note { get; set; }
        public int? year { get; set; }
        public int? month { get; set; }
    }
}
