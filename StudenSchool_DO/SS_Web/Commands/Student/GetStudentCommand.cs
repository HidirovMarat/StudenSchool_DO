using Provider;
using SS_WEB.Commands.Student.Interfaces;
using Models.Requests.Student;
using Models.Responses.StudentResponses;
using Models.Validators.Student.Interfaces;

namespace SS_WEB.Commands.Student;

public class GetStudentCommand : IGetStudentCommand
{
    private IGetStudentRequestValidator _validator;
    private GetStudentResponse _response;
    private StudentRepository _repository;

    public GetStudentCommand(IGetStudentRequestValidator validator, GetStudentResponse response, StudentRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public GetStudentResponse Execute(GetStudentRequest request)
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

        var result = _repository.Get(request.Id);

        _response.StudentInfo = new();

        _response.StudentInfo.DateOfAdmission = result.DateOfAdmission;
        _response.StudentInfo.Faculty = result.Faculty;
        _response.StudentInfo.FirstName = result.FirstName;
        _response.StudentInfo.LastName = result.LastName;

        return _response;
    }
}
