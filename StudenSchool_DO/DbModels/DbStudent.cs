namespace DbModels;

public class DbStudent
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfAdmission { get; set; }

    public string Faculty {  get; set; }

    public List<DbGrade> Grades { get; set; } = new();

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName} {DateOfAdmission} {Faculty}";
    }
}