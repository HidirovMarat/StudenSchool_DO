namespace Models.Requests.Grade;

public class DeleteGradeRequest
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
}
