using FluentValidation;
using Models.Requests.Grade;

namespace Models.Validators.Grade.Interfaces;

public interface ICreateGradeRequestValidator : IValidator<CreateGradeRequest>
{

}
