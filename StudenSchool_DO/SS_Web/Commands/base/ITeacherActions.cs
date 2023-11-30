using SS_Web.Entitys;
using SS_Web.Responses.TeacherResponses;

namespace SS_Web.Actions.@base;

public interface ITeacherActions
{
    public CreateWebsiteSaveRequestResponse Create(TeacherInfo request);

    public GetAllTeacherResponse ReadAll();

    public GetTeacherResponse Read(Guid id);

    public EditTeacherResponse Edit(Guid id, TeacherInfo request);

    public DeleteTeacherResponse Delete(Guid id);
}
