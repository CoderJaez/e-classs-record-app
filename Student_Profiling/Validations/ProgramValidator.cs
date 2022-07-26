using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Student_Profiling.Validations
{
   public class ProgramValidator:AbstractValidator<program>
    {
        public  ProgramValidator()
        {
            RuleFor(prg => prg.Programs)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(4, 50).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid")
                .Must(isValidCourse).WithMessage("{PropertyName} Contains Invalid Characters");
        }

        protected bool isValidCourse(string course)
        {
            course = course.Replace(" ", "");
            return course.All(char.IsLetter);
        }
    }
}
