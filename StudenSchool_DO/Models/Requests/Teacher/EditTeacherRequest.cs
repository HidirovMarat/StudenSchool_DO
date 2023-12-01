namespace Models.Requests.Teacher;

public class EditTeacherRequest
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Faculty { get; set; }
}
