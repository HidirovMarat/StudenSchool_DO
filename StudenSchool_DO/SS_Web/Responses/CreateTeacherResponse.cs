using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateTeacherResponse
{
    public TeacherInfo TeacherInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
