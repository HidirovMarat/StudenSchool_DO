using FluentValidation;
using Models.Requests.Student;
using Models.Validators.Student.Interfaces;

namespace Models.Validators.Student;

public class DeleteStudentRequestValidator : AbstractValidator<DeleteStudentRequest>, IDeleteStudentRequestValidator
{
    public DeleteStudentRequestValidator()
    {

    }
}
