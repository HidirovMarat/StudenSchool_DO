using static System.Formats.Asn1.AsnWriter;

namespace DbModels;

public class DbCourse : ICopy<DbCourse>
{
    public  Guid Id { get; set; }

    public string NameCourse { get; set; }

    public int Credit {  get; set; }

    public List<DbGrade> Grades { get; set; } = new ();

    public override string ToString()
    {
        return $"{Id} {NameCourse} {Credit}";
    }

    public void Copy(DbCourse fromCourse)
    {
        Id = fromCourse.Id;
        NameCourse = fromCourse.NameCourse;
        Credit = fromCourse.Credit;
    }
}
