using DbModels;
using FluentValidation;
using Provider;
using SS_Web.Commands.Teacher.Interfaces;
using SS_Web.Requests.Teacher;
using SS_Web.Responses.TeacherResponses;
using SS_Web.Validators.Teacher.Interfaces;

namespace SS_Web.Commands.Teacher;

public class EditTeacherCommand : IEditTeacherCommand
{
    private IEditTeacherRequestValidator _validator;
    private EditTeacherResponse _response;
    private TeacherRepository _repository;

    public EditTeacherCommand(IEditTeacherRequestValidator validator, EditTeacherResponse response, TeacherRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public EditTeacherResponse Execute(EditTeacherRequest request)
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

        DbTeacher teacherInfo = new()
        {
            Id = request.Id,
            LastName = request.LastName,
            FirstName = request.FirstName,
            Faculty = request.Faculty,
        };

        _repository.Edit(teacherInfo);

        _response.TeacherInfo = new()
        {
            LastName = request.LastName,
            FirstName = request.FirstName,
            Faculty = request.Faculty,
        };


        return _response;
    }
}
