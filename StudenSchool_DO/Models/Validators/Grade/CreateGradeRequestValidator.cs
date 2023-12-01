using FluentValidation;
using Models.Requests.Grade;
using Models.Validators.Grade.Interfaces;

namespace Models.Validators.Grade;

public class CreateGradeRequestValidator : AbstractValidator<CreateGradeRequest>, ICreateGradeRequestValidator
{
    public CreateGradeRequestValidator()
    {

    }
}
