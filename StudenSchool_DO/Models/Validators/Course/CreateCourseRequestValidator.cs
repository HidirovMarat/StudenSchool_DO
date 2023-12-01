using FluentValidation;
using Models.Requests.Course;
using Models.Validators.Course.Interfaces;

namespace Models.Validators.Course;

public class CreateCourseRequestValidator : AbstractValidator<CreateCourseRequest>, ICreateCourseRequestValidator
{
    public CreateCourseRequestValidator()
    {

    }
}
