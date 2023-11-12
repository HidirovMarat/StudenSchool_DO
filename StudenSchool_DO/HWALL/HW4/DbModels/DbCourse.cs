namespace DbModels;

public class DbCourse : ICopyable<DbCourse>
{
    public  Guid Id { get; set; }

    public string NameCourse { get; set; } = null!;

    public int Credit {  get; set; }

    public List<DbGrade> Grades { get; set; } = null!;

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
