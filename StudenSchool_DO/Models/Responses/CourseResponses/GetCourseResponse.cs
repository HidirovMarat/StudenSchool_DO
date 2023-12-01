using Models.Entitys;

namespace Models.Responses.CourseResponses;

public class GetCourseResponse
{
    public CourseInfo CourseInfo { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
