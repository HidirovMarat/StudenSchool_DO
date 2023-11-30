using SS_Web.Entitys;

namespace SS_Web.Responses.GradeResponses;

public class EditGradeResponse
{
    public GradeInfo GradeInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
