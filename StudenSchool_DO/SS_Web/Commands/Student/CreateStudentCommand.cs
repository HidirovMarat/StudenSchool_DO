using DbModels;
using Provider;
using SS_Web.Commands.Student.Interfaces;
using SS_Web.Requests.Student;
using SS_Web.Responses.StudentResponses;
using SS_Web.Validators.Student.Interfaces;

namespace SS_Web.Commands.Student;

public class CreateStudentCommand : ICreateStudentCommand
{
    private ICreateStudentRequestValidator _validator;
    private CreateStudentResponse _response;
    private StudentRepository _repository;

    public CreateStudentCommand(ICreateStudentRequestValidator validator, CreateStudentResponse response, StudentRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public CreateStudentResponse Execute(CreateStudentRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var id = Guid.NewGuid();
        var student = new DbStudent()
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Faculty = request.Faculty,
            DateOfAdmission = request.DateOfAdmission,
        };

        _repository.Create(student);

        _response.Id = id;

        return _response;
    }
}
