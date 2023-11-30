using SS_Web.Entitys;

namespace SS_Web.Responses.CourseResponses;

public class EditCourseResponse
{
    public CourseInfo CourseInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
