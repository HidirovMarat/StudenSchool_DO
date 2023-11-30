using SS_Web.Entitys;

namespace SS_Web.Responses.TeacherResponses;

public class GetAllTeacherResponse
{
    public List<TeacherInfo> TeachersInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
