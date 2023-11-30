using SS_Web.Entitys;

namespace SS_Web.Responses.CourseResponses;

public class GetAllCourseResponse
{
    public List<CourseInfo> CoursesInfo { get; set; } = new();

    public List<string> Erorrs { get; set; } = new();
}
