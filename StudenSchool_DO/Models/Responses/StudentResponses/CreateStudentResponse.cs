namespace Models.Responses.StudentResponses;

public class CreateStudentResponse
{
    public Guid Id { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
