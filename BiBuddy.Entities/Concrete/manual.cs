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
    public class manual:BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = "Author text length greater than 2"), MaxLength(250, ErrorMessage = "Author text length less than 250"), Required, DisplayName("Yazar")]
        public string author { get; set; }
        [MinLength(2, ErrorMessage = "Title text length greater than 2"), MaxLength(100, ErrorMessage = "Title text length less than 100"), Required, DisplayName("Başlık")]
        public string title { get; set; }
        [DisplayName("Organizasyon"), MinLength(2, ErrorMessage = "Organization text length greater than 2"), MaxLength(150, ErrorMessage = "Organization text length less than 150")]
        public string organization { get; set; }
        [DisplayName("Adres"), MinLength(2, ErrorMessage = "Address text length greater than 2"), MaxLength(250, ErrorMessage = "Address text length less than 250")]
        public string address { get; set; }
        [DisplayName("Baskı")]
        public int? edition { get; set; }
        [DisplayName("Yıl")]
        public int year
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
        [DisplayName("Ay")]
        public int? month
        {
            get
            {
                return month;
            }
            set
            {
                if (month >= 0 && month < 12)
                {
                    this.month = month;
                }
                else
                {
                    var message = String.Format("Month is not valid. It should be between {0} and {1}", 0, 11);
                    throw new ArgumentOutOfRangeException(message);
                }
            }
        }
        
    }
}
