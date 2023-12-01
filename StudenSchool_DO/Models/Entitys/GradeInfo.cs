namespace Models.Entitys;

public class GradeInfo
{
    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }

    public int Grade { get; set; }
}
