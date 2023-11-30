using Azure;
using FluentValidation;
using Provider;
using SS_Web.Commands.Course.Interfaces;
using SS_Web.Requests.Course;
using SS_Web.Responses.CourseResponses;
using SS_Web.Validators.Course.Interfaces;

namespace SS_Web.Commands.Course;

public class GetCourseCommand : IGetCourseCommand
{
    private IGetCourseRequestValidator _validator;
    private GetCourseResponse _response;
    private CourseRepository _repository;

    public GetCourseResponse Execute(GetCourseRequest request)
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

        _response.CourseInfo = new();

        _response.CourseInfo.NameCourse = result.NameCourse;
        _response.CourseInfo.Credit = result.Credit;

        return _response;
    }
}
