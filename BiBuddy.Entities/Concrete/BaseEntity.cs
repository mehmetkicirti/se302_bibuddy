using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string note { get; set; }
        public string bibtexkey { get; set; }
        public string entrytype{ get; set; }
    }
}
