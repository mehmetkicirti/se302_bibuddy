using BiBuddy.Entities.Abstract;
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
    public class booklet :BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = ErrorMessages.TitleMinLength), MaxLength(50, ErrorMessage = ErrorMessages.TitleMaxLength), Required, DisplayName(FieldNames.Title)]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.AuthorMinLength), MaxLength(75, ErrorMessage = ErrorMessages.AuthorMaxLength), Required, DisplayName(FieldNames.Author)]
        public string author { get; set; }
        [DisplayName(FieldNames.HowPublished),MinLength(2, ErrorMessage =  ErrorMessages.HowPublishedMinLength), MaxLength(50, ErrorMessage = ErrorMessages.HowPublishedMaxLength)]
        public string howpublished { get; set; }
        [DisplayName(FieldNames.Address), MinLength(2, ErrorMessage = ErrorMessages.AddressMinLength), MaxLength(250, ErrorMessage = ErrorMessages.AddressMaxLength)]
        public string address { get; set; }
        [DisplayName(FieldNames.Month)]
        public int month
        {
            get
            {
                return month;
            }
            set
            {
                if (month >= 0 && month < 12)
                    this.month = month;
                else
                    throw new ArgumentOutOfRangeException(ErrorMessages.MonthRange);
            }
        }
        [DisplayName(FieldNames.Year)]
        public int? year
        {
            get
            {
                return year;
            }
            set
            {
                if (year >= 1800 && year <= DateTime.Now.Year)
                    this.year = year;
                else
                    throw new ArgumentOutOfRangeException(ErrorMessages.YearRange);
            }
        }
    }
}
