using static System.Formats.Asn1.AsnWriter;

namespace DbModels;

public class DbGrade : ICopy<DbGrade>
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public DbStudent? Student { get; set; }

    public Guid CourseId { get; set; }

    public DbCourse? Course { get; set; }

    public int Grade { get; set; }

    public override string ToString()
    {
        return $"{Id} {StudentId} {CourseId} {Grade}";
    }

    public void Copy(DbGrade fromGrade)
    {
        Id = fromGrade.Id ;
        StudentId = fromGrade.StudentId ;
        CourseId = fromGrade.CourseId ;
        Grade = fromGrade.Grade ;
    }
}
