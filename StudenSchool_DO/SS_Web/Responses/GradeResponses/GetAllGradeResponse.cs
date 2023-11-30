using SS_Web.Entitys;

namespace SS_Web.Responses.GradeResponses;

public class GetAllGradeResponse
{
    public List<GradeInfo> GradesInfo { get; set; }

    public List<string> Erorrs {  get; set; } = new();
}
