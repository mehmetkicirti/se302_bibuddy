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
    public class conference:BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = "Author text length greater than 2"), MaxLength(75, ErrorMessage = "Author text length less than 75"), Required, DisplayName("Yazar")]
        public string author { get; set; }
        [MinLength(2, ErrorMessage = "Title text length greater than 2"), MaxLength(75, ErrorMessage = "Title text length less than 75"), Required, DisplayName("Başlık")]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = "BookTitle text length greater than 2"), MaxLength(90, ErrorMessage = "BookTitle text length less than 90"), Required, DisplayName("Kitap Başlığı")]
        public string booktitle { get; set; }
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
        [MinLength(2, ErrorMessage = "Editor text length greater than 2"), MaxLength(80, ErrorMessage = "Editor text length less than 80"),DisplayName("Editor")]
        public string editor { get; set; }
        [DisplayName("Cilt")]
        public int? volume { get; set; }
        [DisplayName("Grup")]
        public int? series { get; set; }
        [DisplayName("Sayfalar"), MinLength(2, ErrorMessage = "Pages text length greater than 2"), MaxLength(50, ErrorMessage = "Pages text length less than 50")]
        public string pages { get; set; }
        [DisplayName("Adres"), MinLength(2, ErrorMessage = "Address text length greater than 2"), MaxLength(250, ErrorMessage = "Address text length less than 250")]
        public string address { get; set; }
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
        [DisplayName("Organizasyon"), MinLength(2, ErrorMessage = "Organization text length greater than 2"), MaxLength(150, ErrorMessage = "Organization text length less than 150")]
        public string organization { get; set; }
        [DisplayName("Yayımcı"), MinLength(2, ErrorMessage = "Publisher text length greater than 2"), MaxLength(150, ErrorMessage = "Publisher text length less than 150")]
        public string publisher { get; set; }
    }
}
