using SS_Web.Entitys;
using SS_Web.Responses.StudentResponses;

namespace SS_Web.Actions.@base;

public interface IStudentActions
{
    public CreateStudentResponse Create(StudentInfo request);

    public GetAllStudentResponse ReadAll();

    public GetStudentResponse Read(Guid id);

    public EditStudentResponse Edit(Guid id, StudentInfo request);

    public DeleteStudentResponse Delete(Guid id);
}
