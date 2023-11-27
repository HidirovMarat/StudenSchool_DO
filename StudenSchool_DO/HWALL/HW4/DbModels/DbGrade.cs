namespace DbModels;

public class DbGrade : ICopyable<DbGrade>
{
    public Guid StudentId { get; set; }

    public DbStudent? Student { get; set; }

    public Guid CourseId { get; set; }

    public DbCourse? Course { get; set; }

    public int Grade { get; set; }

    public override string ToString()
    {
        return $"{StudentId} {CourseId} {Grade}";
    }

    public void Copy(DbGrade fromGrade)
    {
        StudentId = fromGrade.StudentId;
        CourseId = fromGrade.CourseId;
        Grade = fromGrade.Grade;
    }
}
