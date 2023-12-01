using FluentValidation;
using Models.Requests.Course;

namespace Models.Validators.Course.Interfaces;

public interface IDeleteCourseRequestValidator : IValidator<DeleteCourseRequest>
{
}
