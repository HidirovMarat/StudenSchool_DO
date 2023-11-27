using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateGradeResponse
{
    public GradeInfo GradeInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
