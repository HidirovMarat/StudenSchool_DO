using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface IStudentActions
{
    public CreateStudentResponse Create(StudentInfo request);

    public IEnumerable<StudentInfo> ReadAll();

    public CreateStudentResponse Read(Guid id);

    public CreateStudentResponse Edit(StudentInfo request);

    public CreateStudentResponse Delete(Guid id);
}
