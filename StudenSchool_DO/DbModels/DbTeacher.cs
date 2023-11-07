namespace DbModels;

public class DbTeacher
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Faculty { get; set; }

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName} {Faculty}";
    }
}
