using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Student_Profiling.Models;
namespace Student_Profiling.Validations
{
    class SchoolYearValidation:AbstractValidator<SchoolYearObj>
    {
        public SchoolYearValidation()
        {
            RuleFor(sy => sy.SchoolYear)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required.")
                .Length(9).WithMessage("{PropertyName} Field must be exact to {Length} length");
            RuleFor(sy => sy.Sem)
                .NotEmpty().WithMessage("{PropertyName} field is required");
        }
    }
}
