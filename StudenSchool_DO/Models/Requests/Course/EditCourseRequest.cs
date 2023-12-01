namespace Models.Requests.Course;

public class EditCourseRequest
{
    public Guid Id { get; set; }

    public string NameCourse { get; set; }

    public int Credit { get; set; }
}
