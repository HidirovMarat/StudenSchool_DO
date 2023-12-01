namespace Models.Responses.GradeResponses;

public class DeleteGradeResponse
{
    public Guid Id { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
