using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface ITeacherActions
{
    public CreateTeacherResponse Create(TeacherInfo request);

    public IEnumerable<TeacherInfo> ReadAll();

    public CreateTeacherResponse Read(Guid id);

    public CreateTeacherResponse Edit(TeacherInfo request);

    public CreateTeacherResponse Delete(Guid id);
}
