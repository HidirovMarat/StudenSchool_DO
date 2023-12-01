using Provider;
using SS_WEB.Commands.Teacher.Interfaces;
using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;
using Models.Validators.Teacher.Interfaces;

namespace SS_WEB.Commands.Teacher;

public class DeleteTeacherCommand : IDeleteTeacherCommand
{
    private IDeleteTeacherRequestValidator _validator;
    private DeleteTeacherResponse _response;
    private TeacherRepository _repository;

    public DeleteTeacherCommand(IDeleteTeacherRequestValidator validator, DeleteTeacherResponse response, TeacherRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public DeleteTeacherResponse Execute(DeleteTeacherRequest request)
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

        _repository.Delete(request.Id);

        return _response;
    }
}
