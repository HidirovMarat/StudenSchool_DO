using DbModels;
using Provider;
using SS_WEB.Commands.Course.Interfaces;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using Models.Validators.Course.Interfaces;

namespace SS_WEB.Commands.Course;

public class EditCourseCommand : IEditCourseCommand
{
    private IEditCourseRequestValidator _validator;
    private EditCourseResponse _response;
    private CourseRepository _repository;

    public EditCourseCommand(IEditCourseRequestValidator validator, EditCourseResponse response, CourseRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public EditCourseResponse Execute(EditCourseRequest request)
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

        var course = new DbCourse()
        {
            Id = request.Id,
            NameCourse = request.NameCourse,
            Credit = request.Credit,
        };

        _repository.Edit(course);

        _response.CourseInfo = new()
        {
            NameCourse = request.NameCourse,
            Credit = request.Credit,
        };

        return _response;
    }
}
