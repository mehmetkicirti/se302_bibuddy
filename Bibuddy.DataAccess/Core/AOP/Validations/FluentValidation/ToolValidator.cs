using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Core.AOP.Validations.FluentValidation
{
    public class ToolValidator
    {
        /*Why We use AOP => 
            it will provide;
                - reusability
                - maintainability
                - modularity of the projects
        */  
        public static void FluentValidate(IValidator validator, object obj)
        {
            var result = validator.Validate(obj);
            if (result.Errors.Count>0)
                throw new ValidationException(result.Errors);
        }
    }
}
