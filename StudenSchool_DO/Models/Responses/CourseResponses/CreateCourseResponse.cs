namespace Models.Responses.CourseResponses;

public class CreateCourseResponse
{
    public Guid? Id { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
