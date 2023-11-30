using FluentValidation;
using SS_Web.Requests.Teacher;
using SS_Web.Validators.Teacher.Interfaces;

namespace SS_Web.Validators.Teacher;

public class CreateTeacherRequestValidator : AbstractValidator<CreateTeacherRequest>, ICreateTeacherRequestValidator
{
    public CreateTeacherRequestValidator()
    {

    }
}
