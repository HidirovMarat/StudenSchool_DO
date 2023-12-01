using Provider;
using SS_WEB.Commands.Teacher.Interfaces;
using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;
using Models.Validators.Teacher.Interfaces;

namespace SS_WEB.Commands.Teacher;

public class GetTeacherCommand : IGetTeacherCommand
{
    private IGetTeacherRequestValidator _validator;
    private GetTeacherResponse _response;
    private TeacherRepository _repository;

    public GetTeacherCommand(IGetTeacherRequestValidator validator, GetTeacherResponse response, TeacherRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public GetTeacherResponse Execute(GetTeacherRequest request)
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

        _response.TeacherInfo = new()
        {
            Faculty = result.Faculty,
            FirstName = result.FirstName,
            LastName = result.LastName,
        };

        return _response;
    }
}
