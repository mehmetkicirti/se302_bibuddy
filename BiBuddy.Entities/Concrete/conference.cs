using BiBuddy.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
namespace BiBuddy.Entities.Concrete
{
    public class conference:BaseEntity,IEntity
    {
        [ Required]
        public string author { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string booktitle { get; set; }
        public string editor { get; set; }
        public int? volume { get; set; }
        public int? series { get; set; }
        public string pages { get; set; }
        public string address { get; set; }
        public string organization { get; set; }
        public string publisher { get; set; }
    }
}
