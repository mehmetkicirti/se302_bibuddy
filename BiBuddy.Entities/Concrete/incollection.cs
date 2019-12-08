using BiBuddy.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class incollection:BaseEntity,IEntity
    {
        [Required]
        public string author { get; set; }
        [Required]
        public string title { get; set; }
        public int? chapter { get; set; }
        [Required]
        public string booktitle { get; set; }
        public string publisher { get; set; }
        public string editor { get; set; }
        public int? volume { get; set; }
        public int? series { get; set; }
        public string pages { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
    }
}
