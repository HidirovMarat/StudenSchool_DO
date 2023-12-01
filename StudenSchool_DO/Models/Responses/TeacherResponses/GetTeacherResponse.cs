using Models.Entitys;

namespace Models.Responses.TeacherResponses;

public class GetTeacherResponse
{
    public TeacherInfo TeacherInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
