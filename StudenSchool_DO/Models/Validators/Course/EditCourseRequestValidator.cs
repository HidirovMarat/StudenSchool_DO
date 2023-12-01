using FluentValidation;
using Models.Requests.Course;
using Models.Validators.Course.Interfaces;

namespace Models.Validators.Course;

public class EditCourseRequestValidator : AbstractValidator<EditCourseRequest>, IEditCourseRequestValidator
{
    public EditCourseRequestValidator()
    {

    }
}
