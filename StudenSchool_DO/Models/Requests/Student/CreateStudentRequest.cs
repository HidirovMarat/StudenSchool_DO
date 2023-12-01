namespace Models.Requests.Student;

public class CreateStudentRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfAdmission { get; set; }

    public string Faculty { get; set; }
}
