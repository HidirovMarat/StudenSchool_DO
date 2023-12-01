using FluentValidation;
using Models.Requests.Student;
using Models.Validators.Student.Interfaces;

namespace Models.Validators.Student;

public class GetStudentRequestValidator : AbstractValidator<GetStudentRequest>, IGetStudentRequestValidator
{
    public GetStudentRequestValidator()
    {

    }
}
