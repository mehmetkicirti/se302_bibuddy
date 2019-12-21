using System;
using System.Text.RegularExpressions;
using BiBuddy.Entities.Concrete;
using BiBuddy.Entities.ValidationRules;
using FluentValidation;

namespace Bibuddy.Entities.ValidationRules.FluentValidation
{
    public class ArticleValidate:AbstractValidator<article>
    {
        public ArticleValidate()
        {
            #region Author
            RuleFor(a => a.author).NotEmpty().WithMessage(errorMessage: ErrorMessages.AuthorIsRequired);
            RuleFor(a => a.author).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.AuthorMinLength);
            RuleFor(a => a.author).MaximumLength(75).WithMessage(errorMessage: ErrorMessages.AuthorMaxLength);
            #endregion
           
            #region Title
            RuleFor(a => a.title).NotEmpty().WithMessage(errorMessage:ErrorMessages.TitleIsRequired);
            RuleFor(a => a.title).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.TitleMinLength);
            RuleFor(a => a.title).MaximumLength(250).WithMessage(errorMessage: ErrorMessages.TitleMaxLength);
            #endregion

            #region Journal
            RuleFor(a => a.journal).NotEmpty().WithMessage(errorMessage: ErrorMessages.JournalIsRequired);
            RuleFor(a => a.journal).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.JournalMinLength);
            RuleFor(a => a.journal).MaximumLength(250).WithMessage(errorMessage: ErrorMessages.JournalMaxLength);
            #endregion
            
            #region Year
            RuleFor(a => a.year).Must(YearRange).WithMessage(errorMessage: ErrorMessages.YearRange);
            #endregion

            #region Month

            RuleFor(a => a.month).Must(MonthRange).WithMessage(errorMessage:ErrorMessages.MonthRange);
            

            #endregion
        }
        private static bool MonthRange(int? arg)
        {
            if (arg.HasValue)
            {
                if (arg.Value<DateTime.MinValue.Month || arg.Value>DateTime.MaxValue.Month)
                    return false;
                return true;
            }
            else
                return true;
        }

        private static bool YearRange(int? arg)
        {
            if (arg.HasValue)
            {
                if (arg.Value < DateTime.MinValue.Year || arg.Value > DateTime.MaxValue.Year)
                    return false;
                return true;
            }
            else
                return true;
        }
    }
}
