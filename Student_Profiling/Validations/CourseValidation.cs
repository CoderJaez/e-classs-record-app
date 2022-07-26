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
    class CourseValidation:AbstractValidator<Course>
    {
        private int courseID;
        private CourseModel courseModel = new CourseModel();
        public CourseValidation(int _courseID)
        {
            courseID = _courseID;
            RuleFor(course => course.CourseCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty.")
                .Length(3, 10).WithMessage("{PropertyName} must at least 3-10 Character")
                .Must(DuplicateCourseCode).WithMessage("{PropertyName} is already registered.");

            RuleFor(course => course.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(5, 100).WithMessage("{PropertyName} must at least 5-100 Character");
        }

        protected bool DuplicateCourseCode(string CourseCode)
        {
            return (courseModel.validateCourseCode(CourseCode,courseID)) ? false:true;
        }

        
    }
}
