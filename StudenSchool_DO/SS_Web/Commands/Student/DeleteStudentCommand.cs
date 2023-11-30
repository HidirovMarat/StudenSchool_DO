using Provider;
using SS_Web.Commands.Student.Interfaces;
using SS_Web.Requests.Student;
using SS_Web.Responses.StudentResponses;
using SS_Web.Validators.Student.Interfaces;

namespace SS_Web.Commands.Student;

public class DeleteStudentCommand : IDeleteStudentCommand
{
    private IDeleteStudentRequestValidator _validator;
    private DeleteStudentResponse _response;
    private StudentRepository _repository;

    public DeleteStudentCommand(IDeleteStudentRequestValidator validator, DeleteStudentResponse response, StudentRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public DeleteStudentResponse Execute(DeleteStudentRequest request)
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

        _response.Id = request.Id;

        return _response;
    }
}
