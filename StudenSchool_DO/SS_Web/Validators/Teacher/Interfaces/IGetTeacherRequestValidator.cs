using FluentValidation;
using SS_Web.Requests.Student;
using SS_Web.Requests.Teacher;

namespace SS_Web.Validators.Teacher.Interfaces
{
    public interface IGetTeacherRequestValidator : IValidator<GetTeacherRequest>
    {
    }
}
