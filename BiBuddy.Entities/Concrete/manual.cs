using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.Utility;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class manual:BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = ErrorMessages.AuthorMinLength), MaxLength(75, ErrorMessage = ErrorMessages.AuthorMaxLength), Required, DisplayName(FieldNames.Author)]
        public string author { get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.TitleMinLength), MaxLength(75, ErrorMessage = ErrorMessages.TitleMaxLength), Required, DisplayName(FieldNames.Title)]
        public string title { get; set; }
        [DisplayName(FieldNames.Organization), MinLength(2, ErrorMessage = ErrorMessages.OrganizationMinLength), MaxLength(150, ErrorMessage = ErrorMessages.OrganizationMaxLength)]
        public string organization { get; set; }
        [DisplayName(FieldNames.Address), MinLength(2, ErrorMessage = ErrorMessages.AddressMinLength), MaxLength(250, ErrorMessage = ErrorMessages.AddressMaxLength)]
        public string address { get; set; }
        [DisplayName(FieldNames.Edition)]
        public int? edition { get; set; }
        [DisplayName(FieldNames.Year)]
        public int year
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
        [DisplayName(FieldNames.Month)]
        public int? month
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
        
    }
}
