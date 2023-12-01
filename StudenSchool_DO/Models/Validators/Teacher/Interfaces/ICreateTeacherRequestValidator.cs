using FluentValidation;
using Models.Entitys;
using Models.Requests.Student;
using Models.Requests.Teacher;

namespace Models.Validators.Teacher.Interfaces;

public interface ICreateTeacherRequestValidator : IValidator<CreateTeacherRequest>
{
}
