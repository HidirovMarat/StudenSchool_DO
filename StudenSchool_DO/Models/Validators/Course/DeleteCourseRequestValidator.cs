using FluentValidation;
using Models.Requests.Course;
using Models.Validators.Course.Interfaces;

namespace Models.Validators.Course;

public class DeleteCourseRequestValidator : AbstractValidator<DeleteCourseRequest>, IDeleteCourseRequestValidator
{
    public DeleteCourseRequestValidator()
    {

    }
}
