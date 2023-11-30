using SS_Web.Entitys;

namespace SS_Web.Responses.StudentResponses;

public class GetAllStudentResponse
{
    public List<StudentInfo> StudentsInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
