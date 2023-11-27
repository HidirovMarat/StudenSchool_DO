using Azure.Core;
using DbModels;
using Provider;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses;
using SS_Web.Validators.@base;

namespace SS_Web.Actions;

public class StudentActions : IStudentActions
{
    private StudentRepository _repository;
    private CreateStudentResponse _response;
    private ICreateStudentRequestValidator _validator;

    public StudentActions(StudentRepository repository, CreateStudentResponse response, ICreateStudentRequestValidator validator)
    {
        _repository = repository;
        _response = response;
        _validator = validator;
    }

    public CreateStudentResponse Create(StudentInfo request)
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

        request.Id = id;

        _response.StudentInfo = request;

        return _response;
    }

    public CreateStudentResponse Delete(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        _repository.Delete(id);

        return _response;
    }

    public CreateStudentResponse Read(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        var result = _repository.Get(id);

        _response.StudentInfo = new();

        _response.StudentInfo.DateOfAdmission = result.DateOfAdmission;
        _response.StudentInfo.Faculty = result.Faculty;
        _response.StudentInfo.FirstName = result.FirstName;
        _response.StudentInfo.LastName = result.LastName;
        _response.StudentInfo.Id = result.Id;

        return _response;
    }

    public IEnumerable<StudentInfo> ReadAll()
    {
        var result = _repository.GetAll();

        foreach (var student in result)
        {
            var studentInfo = new StudentInfo()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Faculty = student.Faculty,
                DateOfAdmission = student.DateOfAdmission,
            };

            yield return studentInfo;
        }

        yield break;
    }

    public CreateStudentResponse Edit(StudentInfo request)
    {
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

        _response.StudentInfo = request;

        return _response;
    }
}
