namespace Models.Requests.Student;

public class EditStudentRequest
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfAdmission { get; set; }

    public string Faculty { get; set; }
}
