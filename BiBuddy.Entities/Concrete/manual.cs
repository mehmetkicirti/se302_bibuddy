using BiBuddy.Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class manual:BaseEntity,IEntity
    {
        [Required]
        public string author { get; set; }
        [Required]
        public string title { get; set; }
        public string organization { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
    }
}
