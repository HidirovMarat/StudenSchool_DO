using DbModels;
using Provider;
using SS_WEB.Commands.Student.Interfaces;
using Models.Requests.Student;
using Models.Responses.StudentResponses;
using Models.Validators.Student.Interfaces;

namespace SS_WEB.Commands.Student;

public class EditStudentCommand : IEditStudentCommand
{
    private IEditStudentRequestValidator _validator;
    private EditStudentResponse _response;
    private StudentRepository _repository;

    public EditStudentCommand(IEditStudentRequestValidator validator, EditStudentResponse response, StudentRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public EditStudentResponse Execute(EditStudentRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        if (!_repository.IsData(request.Id))
        {
            _response.Erorrs.Add($"Не существует key = {request.Id}");

            return _response;
        }

        var student = new DbStudent()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Faculty = request.Faculty,
            DateOfAdmission = request.DateOfAdmission,
        };

        _repository.Edit(student);

        _response.StudentInfo = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Faculty = request.Faculty,
            DateOfAdmission = request.DateOfAdmission,
        };

        return _response;
    }
}
