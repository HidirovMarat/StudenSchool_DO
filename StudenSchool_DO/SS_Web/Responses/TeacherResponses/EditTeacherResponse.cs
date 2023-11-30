using SS_Web.Entitys;

namespace SS_Web.Responses.TeacherResponses;

public class EditTeacherResponse
{
    public TeacherInfo TeacherInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
