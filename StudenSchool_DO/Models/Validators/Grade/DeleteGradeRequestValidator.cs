using FluentValidation;
using Models.Requests.Grade;
using Models.Validators.Grade.Interfaces;

namespace Models.Validators.Grade;

public class DeleteGradeRequestValidator : AbstractValidator<DeleteGradeRequest>, IDeleteGradeRequestValidator
{
    public DeleteGradeRequestValidator()
    {

    }
}
