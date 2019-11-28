using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.Utility;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class book : BaseEntity,IEntity
    {
        [MinLength(2, ErrorMessage = ErrorMessages.AuthorMinLength), MaxLength(75, ErrorMessage = ErrorMessages.AuthorMaxLength), Required, DisplayName(FieldNames.Author)]
        public string author { get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.TitleMinLength), MaxLength(250, ErrorMessage = ErrorMessages.TitleMaxLength), Required, DisplayName(FieldNames.Title)]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.JournalMinLength), MaxLength(50, ErrorMessage = ErrorMessages.JournalMaxLength), Required, DisplayName(FieldNames.Journal)]
        public string journal { get; set; }
        [Required, DisplayName(FieldNames.Year)]
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
        [DisplayName(FieldNames.Volume)]
        public int? volume { get; set; }
        [DisplayName(FieldNames.Series)]
        public int? series { get; set; }
        [DisplayName(FieldNames.Address), MinLength(2, ErrorMessage = ErrorMessages.AddressMinLength), MaxLength(250, ErrorMessage = ErrorMessages.AddressMaxLength)]
        public string address { get; set; }
        [DisplayName(FieldNames.Edition)]
        public int? edition { get; set; }
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
        [DisplayName(FieldNames.ISBN), MinLength(2, ErrorMessage = ErrorMessages.ISBNMinLength), MaxLength(50, ErrorMessage = ErrorMessages.ISBNMaxLength)]
        public string isbn { get; set; }
    }
}
