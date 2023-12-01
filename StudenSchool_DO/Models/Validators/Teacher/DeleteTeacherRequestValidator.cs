using FluentValidation;
using Models.Requests.Teacher;
using Models.Validators.Teacher.Interfaces;

namespace Models.Validators.Teacher;

public class DeleteTeacherRequestValidator : AbstractValidator<DeleteTeacherRequest>, IDeleteTeacherRequestValidator
{
    public DeleteTeacherRequestValidator()
    {

    }
}
