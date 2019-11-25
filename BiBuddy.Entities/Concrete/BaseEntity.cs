using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBuddy.Entities.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Note"), MinLength(2, ErrorMessage = "Note text length greater than 2"), MaxLength(250, ErrorMessage = "Note text length less than 250")]
        public string note { get; set; }
    }
}
