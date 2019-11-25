using BiBuddy.Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class book : BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = "Author text length greater than 2"), MaxLength(75, ErrorMessage = "Author text length less than 50"), Required, DisplayName("Yazar")]
        public string author { get; set; }
        [MinLength(2, ErrorMessage = "Title text length greater than 2"), MaxLength(250, ErrorMessage = "Title text length less than 250"), Required, DisplayName("Başlık")]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = "Journal text length greater than 2"), MaxLength(50, ErrorMessage = "Journal text length less than 50"), Required, DisplayName("Dergi")]
        public string journal { get; set; }
        [Required, DisplayName("Yıl")]
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
        [DisplayName("Cilt")]
        public int? volume { get; set; }
        [DisplayName("Grup")]
        public int? series { get; set; }
        [DisplayName("Adres"), MinLength(2, ErrorMessage = "Address text length greater than 2"), MaxLength(250, ErrorMessage = "Address text length less than 250")]
        public string address { get; set; }
        [DisplayName("Baskı")]
        public int? edition { get; set; }
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
        [DisplayName("ISBN"), MinLength(2, ErrorMessage = "ISBN text length greater than 2"), MaxLength(50, ErrorMessage = "ISBN text length less than 50")]
        public string isbn { get; set; }
    }
}
