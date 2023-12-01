using FluentValidation;
using Models.Requests.Grade;
using Models.Validators.Grade.Interfaces;

namespace Models.Validators.Grade;

public class EditGradeRequestValidator : AbstractValidator<EditGradeRequest>, IEditGradeRequestValidator
{
    public EditGradeRequestValidator()
    {

    }
}
