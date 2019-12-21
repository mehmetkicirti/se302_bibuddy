using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiBuddy.Entities.Concrete;
using FluentValidation;

namespace BiBuddy.Entities.ValidationRules.FluentValidation
{
    public class ManualValidate : AbstractValidator<manual>
    {
        public ManualValidate()
        {
            #region Author
            RuleFor(a => a.author).NotEmpty().WithMessage(errorMessage: ErrorMessages.AuthorIsRequired);
            RuleFor(a => a.author).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.AuthorMinLength);
            RuleFor(a => a.author).MaximumLength(75).WithMessage(errorMessage: ErrorMessages.AuthorMaxLength);
            #endregion

            #region Title
            RuleFor(a => a.title).NotEmpty().WithMessage(errorMessage: ErrorMessages.TitleIsRequired);
            RuleFor(a => a.title).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.TitleMinLength);
            RuleFor(a => a.title).MaximumLength(250).WithMessage(errorMessage: ErrorMessages.TitleMaxLength);
            #endregion


            #region Address
            //RuleFor(a => a.address).NotEmpty().WithMessage(errorMessage: ErrorMessages.AddresIsRequired);
            RuleFor(a => a.address).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.AddressMinLength);
            RuleFor(a => a.address).MaximumLength(250).WithMessage(errorMessage: ErrorMessages.AddressMaxLength);
            #endregion

            #region Organization
            RuleFor(a => a.organization).MinimumLength(2).WithMessage(errorMessage: ErrorMessages.OrganizationMinLength);
            RuleFor(a => a.organization).MaximumLength(250).WithMessage(errorMessage: ErrorMessages.OrganizationMaxLength);
            #endregion


            #region Year
            RuleFor(a => a.year).Must(YearRange).WithMessage(errorMessage: ErrorMessages.YearRange);
            #endregion

            #region Month
            RuleFor(a => a.month).Must(MonthRange).WithMessage(errorMessage: ErrorMessages.MonthRange);
            #endregion
        }
        private static bool MonthRange(int? arg)
        {
            if (arg.HasValue)
            {
                if (arg.Value < DateTime.MinValue.Month || arg.Value > DateTime.MaxValue.Month)
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
