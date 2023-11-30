using Azure;
using DbModels;
using Provider;
using SS_Web.Commands.Course.Interfaces;
using SS_Web.Entitys;
using SS_Web.Requests.Course;
using SS_Web.Responses.CourseResponses;
using SS_Web.Validators.Course.Interfaces;

namespace SS_Web.Commands.Course;

public class CreateCourseCommand : ICreateCourseCommand
{
    private ICreateCourseRequestValidator _validator;
    private CreateCourseResponse _response;
    private CourseRepository _repository;

    public CreateCourseCommand(ICreateCourseRequestValidator validator, CreateCourseResponse response, CourseRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public CreateCourseResponse Execute(CreateCourseRequest request)
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
}
