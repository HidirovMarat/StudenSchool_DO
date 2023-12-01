using FluentValidation;
using Models.Requests.Course;

namespace Models.Validators.Course.Interfaces;

public interface ICreateCourseRequestValidator : IValidator<CreateCourseRequest>
{

}
