using FluentValidation;
using SS_Web.Requests.Grade;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Validators.Grade;

public class CreateGradeRequestValidator : AbstractValidator<CreateGradeRequest>, ICreateGradeRequestValidator
{
    public CreateGradeRequestValidator()
    {

    }
}
