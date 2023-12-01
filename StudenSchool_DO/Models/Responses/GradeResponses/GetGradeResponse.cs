using Models.Entitys;

namespace Models.Responses.GradeResponses;

public class GetGradeResponse
{
    public GradeInfo GradeInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
