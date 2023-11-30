using SS_Web.Entitys;

namespace SS_Web.Responses.StudentResponses;

public class EditStudentResponse
{
    public StudentInfo StudentInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
