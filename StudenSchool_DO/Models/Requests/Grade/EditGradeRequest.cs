namespace Models.Requests.Grade;

public class EditGradeRequest
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    public int Grade { get; set; }
}
