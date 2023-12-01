using FluentValidation;
using Models.Requests.Student;
using Models.Requests.Teacher;

namespace Models.Validators.Teacher.Interfaces
{
    public interface IGetTeacherRequestValidator : IValidator<GetTeacherRequest>
    {
    }
}
