namespace Models.Requests.Grade;

public class GetGradeRequest
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
}
