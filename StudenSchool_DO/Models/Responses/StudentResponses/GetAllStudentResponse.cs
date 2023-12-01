using Models.Entitys;

namespace Models.Responses.StudentResponses;

public class GetAllStudentResponse
{
    public List<StudentInfo> StudentsInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
