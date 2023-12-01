using Provider;
using SS_WEB.Commands.Course.Interfaces;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using Models.Validators.Course.Interfaces;

namespace SS_WEB.Commands.Course;

public class GetCourseCommand : IGetCourseCommand
{
    private IGetCourseRequestValidator _validator;
    private GetCourseResponse _response;
    private CourseRepository _repository;

    public GetCourseCommand(IGetCourseRequestValidator validator, GetCourseResponse response, CourseRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

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
