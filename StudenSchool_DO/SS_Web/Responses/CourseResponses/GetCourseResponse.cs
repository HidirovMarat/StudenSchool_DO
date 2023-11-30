using SS_Web.Entitys;

namespace SS_Web.Responses.CourseResponses;

public class GetCourseResponse
{
    public CourseInfo CourseInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
