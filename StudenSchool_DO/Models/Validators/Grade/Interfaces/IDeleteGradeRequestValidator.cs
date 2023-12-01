using FluentValidation;
using Models.Requests.Grade;

namespace Models.Validators.Grade.Interfaces;

public interface IDeleteGradeRequestValidator : IValidator<DeleteGradeRequest>
{
}
