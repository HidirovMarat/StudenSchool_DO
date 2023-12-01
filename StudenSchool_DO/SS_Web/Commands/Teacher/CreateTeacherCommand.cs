using DbModels;
using Provider;
using SS_WEB.Commands.Teacher.Interfaces;
using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;
using Models.Validators.Teacher.Interfaces;

namespace SS_WEB.Commands.Teacher;

public class CreateTeacherCommand : ICreateTeacherCommand
{
    private ICreateTeacherRequestValidator _validator;
    private CreateTeacherResponse _response;
    private TeacherRepository _repository;

    public CreateTeacherCommand(ICreateTeacherRequestValidator validator, CreateTeacherResponse response, TeacherRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public CreateTeacherResponse Execute(CreateTeacherRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var id = Guid.NewGuid();
        var teacher = new DbTeacher()
        {
            Id = id,
            LastName = request.LastName,
            FirstName = request.FirstName,
            Faculty = request.Faculty,
        };

        _repository.Create(teacher);

        _response.Id = id;

        return _response;
    }
}
