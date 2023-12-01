using Provider;
using SS_WEB.Commands.Course.Interfaces;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using Models.Validators.Course.Interfaces;

namespace SS_WEB.Commands.Course;

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

        _response.Id = request.Id;

        return _response;
    }
}
