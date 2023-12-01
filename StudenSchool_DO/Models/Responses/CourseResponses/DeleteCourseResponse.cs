namespace Models.Responses.CourseResponses;

public class DeleteCourseResponse
{
    public Guid? Id {  get; set; }

    public List<string> Erorrs { get; set; } = new();
}
