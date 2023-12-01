using FluentValidation;
using Models.Requests.Course;
using Models.Validators.Course.Interfaces;

namespace Models.Validators.Course;

public class GetCourseRequestValidator : AbstractValidator<GetCourseRequest>, IGetCourseRequestValidator
{
    public GetCourseRequestValidator()
    {

    }
}
