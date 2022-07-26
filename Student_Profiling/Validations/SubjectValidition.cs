using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Student_Profiling.Models;
using Student_Profiling.Objects;

namespace Student_Profiling.Validations
{
    class SubjectValidition:AbstractValidator<Subject>
    {
        string subjID;
        SubjectModel subjectModel = new SubjectModel();
        public SubjectValidition(string SubjectID)
        {
            subjID = SubjectID;
            RuleFor(subj => subj.SubjectCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MinimumLength(3).WithMessage("{PropertyName} field must be at least ({MinLength}) characters")
                .Must(CheckDuplication).WithMessage("{PropertyValue} is already registered.");

            RuleFor(subj => subj.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MinimumLength(4).WithMessage("{PropertyName} field must be at least ({MinLength}) characters");

            RuleFor(subj => subj.Lecture)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} is empty")
               .Matches("^[0-9]+$").WithMessage("{PropertyName} field, enter numbers only");

            RuleFor(subj => subj.Lab)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("{PropertyName} is empty")
              .Matches("^[0-9]+$").WithMessage("{PropertyName} field, enter numbers only");

            RuleFor(subj => subj.CourseCode)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("{PropertyName} field is empty");

            RuleFor(subj => subj.year)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("{PropertyName} field is empty");

            RuleFor(subj => subj.sem)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("{PropertyName} field is empty");

        }

        protected bool CheckDuplication(string SubjectCode)
        {
            return (subjectModel.ValidateSubject(SubjectCode, subjID)) ? false:true;
        }

    }
}
