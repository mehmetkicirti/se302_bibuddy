using BiBuddy.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class booklet :BaseEntity,IEntity
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        public string howpublished { get; set; }
        public string address { get; set; }
    }
}
