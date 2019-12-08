using BiBuddy.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class book : BaseEntity,IEntity
    {
        [Required]
        public string author { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string journal { get; set; }
        public int? volume { get; set; }
        public int? series { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
        public string isbn { get; set; }
    }
}
