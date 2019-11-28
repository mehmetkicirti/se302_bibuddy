using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.Utility;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiBuddy.Entities.Concrete
{
    public class article:BaseEntity,IEntity
    {

        [MinLength(2, ErrorMessage = ErrorMessages.AuthorMinLength ), MaxLength(75, ErrorMessage = ErrorMessages.AuthorMaxLength), Required, DisplayName(FieldNames.Author)]
        public string author{ get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.TitleMinLength), MaxLength(250, ErrorMessage = ErrorMessages.TitleMaxLength), Required, DisplayName(FieldNames.Title)]
        public string title { get; set; }
        [MinLength(2, ErrorMessage = ErrorMessages.JournalMinLength), MaxLength(250, ErrorMessage = ErrorMessages.JournalMaxLength), Required, DisplayName(FieldNames.Journal)]
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
                {
                    this.year = year;
                }
                else
                {
                    
                    throw new ArgumentOutOfRangeException(ErrorMessages.YearRange);
                }
            }
        }
        [DisplayName(FieldNames.Number)]
        public int? number { get; set; }
        [DisplayName(FieldNames.Volume)]
        public int? volume { get; set; }
        [DisplayName(FieldNames.Pages), MinLength(2, ErrorMessage = ErrorMessages.PagesMinLength), MaxLength(50, ErrorMessage = ErrorMessages.PagesMaxLength)]
        public string pages { get; set; }
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
                {
                    this.month = month;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(ErrorMessages.MonthRange);
                }
            }
        }
        
    }
   

}
