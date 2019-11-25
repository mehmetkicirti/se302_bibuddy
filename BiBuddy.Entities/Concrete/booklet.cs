using BiBuddy.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBuddy.Entities.Concrete
{
    public class booklet :BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = "Title text length greater than 2"), MaxLength(50, ErrorMessage = "Title text length less than 50"), Required, DisplayName("Başlık")]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = "Author text length greater than 2"), MaxLength(50, ErrorMessage = "Author text length less than 50"), Required, DisplayName("Yazar")]
        public string author { get; set; }
        [DisplayName("NasılYayınlandı"),MinLength(2, ErrorMessage = "HowPublished text length greater than 2"), MaxLength(50, ErrorMessage = "HowPublished text length less than 50")]
        public string howpublished { get; set; }
        [DisplayName("Adres"), MinLength(2, ErrorMessage = "Address text length greater than 2"), MaxLength(250, ErrorMessage = "Address text length less than 250")]
        public string address { get; set; }
        public int month{ get; set; }
        [DisplayName("Yıl")]
        public int? year
        {
            get
            {
                return year;
            }
            set
            {
                if (year >= 1800 && year <= DateTime.Now.Year)
                {
                    this.year = year;
                }
                else
                {
                    var message = String.Format("Year is not valid. It should be between {0} and {1}", 1800, DateTime.Now.Year);
                    throw new ArgumentOutOfRangeException(message);
                }
            }
        }
    }
}
