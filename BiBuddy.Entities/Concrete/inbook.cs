using BiBuddy.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class inbook:BaseEntity,IEntity
    {
        //[Required]
        public string author { get; set; }
        //[Required]
        public string title { get; set; }
        //[Required]
        public int chapter{ get; set; }
        //[Required]
        public string publisher { get; set; }
        public int? volume { get; set; }
        public int? series { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
        public string type{ get; set; }
    }
}
