using FluentValidation;
using SS_Web.Requests.Student;
using SS_Web.Validators.Student.Interfaces;

namespace SS_Web.Validators.Student;

public class DeleteStudentRequestValidator : AbstractValidator<DeleteStudentRequest>, IDeleteStudentRequestValidator
{
    public DeleteStudentRequestValidator()
    {

    }
}
