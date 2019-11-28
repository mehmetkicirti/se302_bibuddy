using BiBuddy.Entities.Utility;
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
        [DisplayName(FieldNames.Note), MinLength(2, ErrorMessage =ErrorMessages.NoteMinLength ), MaxLength(250, ErrorMessage =ErrorMessages.NoteMaxLength )]
        public string note { get; set; }
    }
}
