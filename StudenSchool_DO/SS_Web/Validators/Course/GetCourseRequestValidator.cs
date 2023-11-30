using FluentValidation;
using SS_Web.Requests.Course;
using SS_Web.Validators.Course.Interfaces;

namespace SS_Web.Validators.Course;

public class GetCourseRequestValidator : AbstractValidator<GetCourseRequest>, IGetCourseRequestValidator
{
    public GetCourseRequestValidator()
    {

    }
}
