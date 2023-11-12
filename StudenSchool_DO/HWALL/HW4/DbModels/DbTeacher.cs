namespace DbModels;

public class DbTeacher : ICopyable<DbTeacher>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Faculty { get; set; }

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName} {Faculty}";
    }

    public void Copy(DbTeacher fromTeacher)
    {
        Id = fromTeacher.Id ;
        FirstName = fromTeacher.FirstName ;
        LastName = fromTeacher.LastName ;
        Faculty = fromTeacher.Faculty ;
    }
}
