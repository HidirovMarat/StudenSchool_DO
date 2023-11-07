namespace DbModels;

public class DbGrade
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public DbStudent? Student { get; set; }

    public Guid CourseId { get; set; }

    public DbCourse? Course { get; set; }

    public int Grade {  get; set; }

    public override string ToString()
    {
        return $"{Id} {StudentId} {CourseId} {Grade}";
    }
}
