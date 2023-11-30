using DbModels;
using Provider;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses.TeacherResponses;
using SS_Web.Validators.Teacher.Interfaces;

namespace SS_Web.Actions;

public class TeacherActions : ITeacherActions
{
    private TeacherRepository _repository;
    private CreateWebsiteSaveRequestResponse _response;
    private ICreateTeacherRequestValidator _validator;

    public TeacherActions(TeacherRepository repository, CreateWebsiteSaveRequestResponse response, ICreateTeacherRequestValidator validator)
    {
        _repository = repository;
        _response = response;
        _validator = validator;
    }

    public CreateWebsiteSaveRequestResponse Create(TeacherInfo request)
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

        request.Id = id;

        _response.TeacherInfo = request;

        return _response;
    }

    public CreateWebsiteSaveRequestResponse Delete(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        _repository.Delete(id);

        return _response;
    }

    public CreateWebsiteSaveRequestResponse Read(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        var result = _repository.Get(id);

        _response.TeacherInfo = new();

        _response.TeacherInfo.Faculty = result.Faculty;
        _response.TeacherInfo.FirstName = result.FirstName;
        _response.TeacherInfo.LastName = result.LastName;
        _response.TeacherInfo.Id = result.Id;

        return _response;
    }

    public IEnumerable<TeacherInfo> ReadAll()
    {
        var result = _repository.GetAll();

        foreach (var teacher in result)
        {
            TeacherInfo teacherInfo = new()
            {
                Id = teacher.Id,
                LastName = teacher.LastName,
                FirstName = teacher.FirstName,
                Faculty = teacher.Faculty,
            };

            yield return teacherInfo;
        }

        yield break;
    }

    public CreateWebsiteSaveRequestResponse Edit(TeacherInfo request)
    {
        if (!_repository.IsData(request.Id))
        {
            _response.Erorrs.Add($"Не существует key = {request.Id}");

            return _response;
        }

        DbTeacher teacherInfo = new()
        {
            Id = request.Id,
            LastName = request.LastName,
            FirstName = request.FirstName,
            Faculty = request.Faculty,
        };

        _repository.Edit(teacherInfo);

        _response.TeacherInfo = request;

        return _response;
    }
}
