using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateStudentResponse
{
    public StudentInfo StudentInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
