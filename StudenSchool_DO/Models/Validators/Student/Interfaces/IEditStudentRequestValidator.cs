using FluentValidation;
using Models.Requests.Student;

namespace Models.Validators.Student.Interfaces;

public interface IEditStudentRequestValidator : IValidator<EditStudentRequest>
{
}
