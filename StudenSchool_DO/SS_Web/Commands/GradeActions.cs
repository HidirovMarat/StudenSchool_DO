using DbModels;
using Provider;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Actions;

public class GradeActions : IGradeActions
{
    private GradeRepository _repository;
    private CreateGradeResponse _response;
    private ICreateGradeRequestValidator _validator;

    public GradeActions(GradeRepository repository, CreateGradeResponse response, ICreateGradeRequestValidator validator)
    {
        _repository = repository;
        _response = response;
        _validator = validator;
    }

    public CreateGradeResponse Create(GradeInfo request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var grade = new DbGrade()
        {
            StudentId = id1,
            CourseId = id2,
            Grade = request.Grade
        };

        _repository.Create(grade);

        request.StudentId = id1;
        request.CourseId = id2;

        _response.GradeInfo = request;

        return _response;
    }

    public CreateGradeResponse Delete(Guid studentId, Guid courseId)
    {
        if (!_repository.IsData(courseId, studentId))
        {
            _response.Erorrs.Add($"Не существует key1 = {studentId} ||| key2 = {courseId}");

            return _response;
        }

        _repository.Delete(studentId, courseId);

        return _response;
    }

    public CreateGradeResponse Read(Guid studentId, Guid courseId)
    {
        if (!_repository.IsData(courseId, studentId))
        {
            _response.Erorrs.Add($"Не существует key1 = {studentId} ||| key2 = {courseId}");

            return _response;
        }

        var result = _repository.Get(studentId, courseId);

        _response.GradeInfo = new();

        _response.GradeInfo.StudentId = result.StudentId;
        _response.GradeInfo.CourseId = result.CourseId;
        _response.GradeInfo.Grade = result.Grade;

        return _response;
    }

    public IEnumerable<GradeInfo> ReadAll()
    {
        var result = _repository.GetAll();

        foreach (var grade in result)
        {
            GradeInfo gradeInfo = new()
            {
                StudentId = grade.StudentId,
                CourseId = grade.CourseId,
                Grade = grade.Grade,
            };

            yield return gradeInfo;
        }

        yield break;
    }

    public CreateGradeResponse Edit(GradeInfo request)
    {
        if (!_repository.IsData(request.CourseId, request.StudentId))
        {
            _response.Erorrs.Add($"Не существует key1 = {request.StudentId} ||| key2 = {request.CourseId}");

            return _response;
        }

        var grade = new DbGrade()
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId,
            Grade = request.Grade,
        };

        _repository.Edit(grade);

        _response.GradeInfo = request;

        return _response;
    }
}
