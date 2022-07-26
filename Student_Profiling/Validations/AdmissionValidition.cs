using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Student_Profiling.Models;
using System.Drawing;
using Student_Profiling.Objects;
namespace Student_Profiling.Validations
{
    class AdmissionValidition:AbstractValidator<Student>
    {
        public AdmissionValidition()
        {
            RuleFor(stud => stud.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required.")
                .MinimumLength(3).WithMessage("{PropertyName} Field required at least ({MinLength}) characters")
                .Must(IsValidName).WithMessage("{PropertyName} Field is invalid");

            RuleFor(stud => stud.LastName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} Field is required.")
               .MinimumLength(2).WithMessage("{PropertyName} Field required at least ({MinLength}) characters")
               .Must(IsValidName).WithMessage("{PropertyName} Field is invalid");

            RuleFor(stud => stud.Gender)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("{PropertyName} Field is required.");

            RuleFor(stud => stud.DateOfBirth)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required.")
                .Must(isValidDate).WithMessage("{PropertyName} Field is invalid");

            RuleFor(stud => stud.PlaceOfBirth)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required")
                .MinimumLength(5).WithMessage("{PropertyName} Field: Please provide a proper place of birth");
            RuleFor(stud => stud.Address)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required.")
                .MinimumLength(5).WithMessage("{PropertyName} Field: Please provide a proper addess");

            RuleFor(stud => stud.Religion)
                .NotEmpty().WithMessage("{PropertyName} Field is required.");

            RuleFor(stud => stud.Barangay)
                .NotEmpty().WithMessage("{PropertyName} Field is required");


            RuleFor(stud => stud.CityMunicipality)
                .NotEmpty().WithMessage("{PropertyName} Field is required");

            RuleFor(stud => stud.Province)
                .NotEmpty().WithMessage("{PropertyName} Field is required");

            RuleFor(stud => stud.ContactNo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required")
                .Length(11, 13).WithMessage("{PropertyName} Field: Minimum to {MinLength} - {MaxLength} digits")
                .Matches("^[0-9]+$").WithMessage("{PropertyName} Field: Enter numbers only");

            RuleFor(stud => stud.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Field is required")
                .EmailAddress().WithMessage("{PropertyName} Field is invalid");

            RuleFor(stud => stud.year)
                .NotEmpty().WithMessage("Year Field is required.");

            RuleFor(stud => stud.Course)
                .NotEmpty().WithMessage("{PropertyName} Field is required.");

            RuleFor(stud => stud.CourseMajor)
                .NotEmpty().WithMessage("Major Field is required");

            


        }

    

        protected bool isValidDate(DateTime date)
        {
            int currentDate = DateTime.Now.Year;

            return ((currentDate - date.Year) > 10) ? true : false;
        }

        protected bool IsValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(char.IsLetter);
        }
    }
}
