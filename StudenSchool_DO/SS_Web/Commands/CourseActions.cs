using Azure.Core;
using DbModels;
using MenuItem;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Provider;
using Services;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses.CourseResponses;
using SS_Web.Validators.Course.Interfaces;
using System.Runtime.CompilerServices;

namespace SS_Web.Actions;

public class CourseActions : ICourseActions
{
    private CourseRepository _repository;
    private CreateCourseResponse _response;
    private ICreateCourseRequestValidator _validator;

    public CourseActions(CourseRepository repository, CreateCourseResponse response, ICreateCourseRequestValidator validator)
    {
        _repository = repository;
        _response = response;
        _validator = validator;
    }

    public CreateCourseResponse Create(CourseInfo request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var id = Guid.NewGuid();

        var course = new DbCourse()
        {
            Id = id,
            NameCourse = request.NameCourse,
            Credit = request.Credit,
        };

        _repository.Create(course);

        _response.Id = id;

        return _response;
    }

    public DeleteCourseResponse Delete(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        _repository.Delete(id);

        return _response;
    }

    public CreateCourseResponse Read(Guid id)
    {
        if (!_repository.IsData(id))
        {
            _response.Erorrs.Add($"Не существует key = {id}");

            return _response;
        }

        var result = _repository.Get(id);

        _response.CourseInfo = new();

        _response.CourseInfo.NameCourse = result.NameCourse;
        _response.CourseInfo.Credit = result.Credit;
        _response.CourseInfo.Id = result.Id;

        return _response;
    }

    public IEnumerable<CourseInfo> ReadAll()
    {
        var result = _repository.GetAll();

        foreach (var course in result)
        {
            CourseInfo courseInfo = new()
            {
                Id = course.Id,
                NameCourse = course.NameCourse,
                Credit = course.Credit,
            };

            yield return courseInfo;
        }

        yield break;
    }

    public CreateCourseResponse Edit(CourseInfo request)
    {
        if (!_repository.IsData(request.Id))
        {
            _response.Erorrs.Add($"Не существует key = {request.Id}");

            return _response;
        }

        var course = new DbCourse()
        {
            Id = request.Id,
            NameCourse = request.NameCourse,
            Credit = request.Credit,
        };

        _repository.Edit(course);

        _response.CourseInfo = request;

        return _response;
    }
}
