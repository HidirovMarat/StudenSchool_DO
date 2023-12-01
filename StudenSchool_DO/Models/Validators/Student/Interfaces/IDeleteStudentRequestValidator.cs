using FluentValidation;
using Models.Requests.Student;

namespace Models.Validators.Student.Interfaces;

public interface IDeleteStudentRequestValidator : IValidator<DeleteStudentRequest>
{
}
