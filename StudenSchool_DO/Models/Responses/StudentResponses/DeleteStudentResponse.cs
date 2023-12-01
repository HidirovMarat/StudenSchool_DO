namespace Models.Responses.StudentResponses;

public class DeleteStudentResponse
{
    public Guid Id { get; set; }

    public List<string> Erorrs { get; set; }
}
