using FluentValidation;
using SS_Web.Entitys;
using SS_Web.Validators.@base;

namespace SS_Web.Validators;

public class CreateCourseRequestValidator : AbstractValidator<CourseInfo>, ICreateCourseRequestValidator
{
    public CreateCourseRequestValidator()
    {

    }
}
