using SS_Web.Entitys;

namespace SS_Web.Responses
{
    public class CreateCourseResponse
    {
        public CourseInfo CourseInfo { get; set; }

        public List<string> Erorrs { get; set; } = new();
    }
}
