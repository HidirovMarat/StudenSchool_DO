using static System.Formats.Asn1.AsnWriter;

namespace DbModels;

public class DbStudent : ICopy<DbStudent>
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

    public void Copy(DbStudent fromStudent)
    {
        Id = fromStudent.Id ;
        FirstName = fromStudent.FirstName ;
        LastName = fromStudent.LastName ;
        DateOfAdmission = fromStudent.DateOfAdmission ;
        Faculty = fromStudent.Faculty ;
    }
}