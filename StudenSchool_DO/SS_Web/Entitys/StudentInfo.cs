using DbModels;

namespace SS_Web.Entitys;

public class StudentInfo
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfAdmission { get; set; }

    public string Faculty { get; set; }
}
