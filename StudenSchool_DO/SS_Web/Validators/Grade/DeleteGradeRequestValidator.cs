using FluentValidation;
using SS_Web.Requests.Grade;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Validators.Grade;

public class DeleteGradeRequestValidator : AbstractValidator<DeleteGradeRequest>, IDeleteGradeRequestValidator
{
    public DeleteGradeRequestValidator()
    {

    }
}
