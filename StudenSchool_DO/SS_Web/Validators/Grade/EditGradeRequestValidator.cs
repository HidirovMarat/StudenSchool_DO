using FluentValidation;
using SS_Web.Requests.Grade;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Validators.Grade;

public class EditGradeRequestValidator : AbstractValidator<EditGradeRequest>, IEditGradeRequestValidator
{
    public EditGradeRequestValidator()
    {

    }
}
