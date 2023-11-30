using FluentValidation;
using SS_Web.Requests.Teacher;
using SS_Web.Validators.Teacher.Interfaces;

namespace SS_Web.Validators.Teacher;

public class DeleteTeacherRequestValidator : AbstractValidator<DeleteTeacherRequest>, IDeleteTeacherRequestValidator
{
    public DeleteTeacherRequestValidator()
    {

    }
}
