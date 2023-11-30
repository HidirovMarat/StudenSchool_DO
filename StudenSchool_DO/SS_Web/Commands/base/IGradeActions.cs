using SS_Web.Entitys;
using SS_Web.Responses.GradeResponses;

namespace SS_Web.Actions.@base;

public interface IGradeActions
{
    public CreateGradeResponse Create(GradeInfo request);

    public GetAllGradeResponse ReadAll();

    public GetGradeResponse Read(Guid courseId, Guid studentId);

    public EditGradeResponse Edit(GradeInfo request);

    public DeleteGradeResponse Delete(Guid courseId, Guid studentId);
}
