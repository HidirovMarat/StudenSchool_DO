using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface IGradeActions
{
    public CreateGradeResponse Create(GradeInfo request);

    public IEnumerable<GradeInfo> ReadAll();

    public CreateGradeResponse Read(Guid courseId, Guid studentId);

    public CreateGradeResponse Edit(GradeInfo request);

    public CreateGradeResponse Delete(Guid courseId, Guid studentId);
}
