namespace DbModels;

public class DbCourse
{
    public  Guid Id { get; set; }

    public string NameCourse { get; set; }

    public int Credit {  get; set; }

    public List<DbGrade> Grades { get; set; } = new ();

    public override string ToString()
    {
        return $"{Id} {NameCourse} {Credit}";
    }
}
