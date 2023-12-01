using Models.Entitys;

namespace Models.Responses.CourseResponses;

public class EditCourseResponse
{
    public CourseInfo CourseInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
