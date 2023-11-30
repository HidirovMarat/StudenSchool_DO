using Azure;
using Provider;
using SS_Web.Commands.Course.Interfaces;
using SS_Web.Requests.Course;
using SS_Web.Responses.CourseResponses;
using SS_Web.Validators.Course.Interfaces;

namespace SS_Web.Commands.Course;

public class DeleteCourseCommand : IDeleteCourseCommand
{
    private IDeleteCourseRequestValidator _validator;
    private DeleteCourseResponse _response;
    private CourseRepository _repository;

    public DeleteCourseCommand(IDeleteCourseRequestValidator validator, DeleteCourseResponse response, CourseRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }
    public DeleteCourseResponse Execute(DeleteCourseRequest request)
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

        return _response;
    }
}
