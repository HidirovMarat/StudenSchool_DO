using FluentValidation;
using SS_Web.Requests.Student;
using SS_Web.Validators.Student.Interfaces;

namespace SS_Web.Validators.Student;

public class GetStudentRequestValidator : AbstractValidator<GetStudentRequest>, IGetStudentRequestValidator
{
    public GetStudentRequestValidator()
    {

    }
}
