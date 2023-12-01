using Models.Entitys;

namespace Models.Responses.CourseResponses;

public class GetAllCourseResponse
{
    public List<CourseInfo> CoursesInfo { get; set; } = new();

    public List<string> Erorrs { get; set; } = new();
}
