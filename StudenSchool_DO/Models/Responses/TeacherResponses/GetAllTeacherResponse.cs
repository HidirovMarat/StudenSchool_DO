using Models.Entitys;

namespace Models.Responses.TeacherResponses;

public class GetAllTeacherResponse
{
    public List<TeacherInfo> TeachersInfo { get; set; }

    public List<string> Erorrs { get; set; }
}
