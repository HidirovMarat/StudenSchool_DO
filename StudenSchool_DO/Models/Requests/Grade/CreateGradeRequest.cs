namespace Models.Requests.Grade;

public class CreateGradeRequest
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    public int Grade { get; set; }
}
