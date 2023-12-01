using Models.Entitys;

namespace Models.Responses.StudentResponses;

public class EditStudentResponse
{
    public StudentInfo StudentInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
