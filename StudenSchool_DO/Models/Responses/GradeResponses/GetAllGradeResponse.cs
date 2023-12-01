using Models.Entitys;

namespace Models.Responses.GradeResponses;

public class GetAllGradeResponse
{
    public List<GradeInfo> GradesInfo { get; set; }

    public List<string> Erorrs {  get; set; } = new();
}
