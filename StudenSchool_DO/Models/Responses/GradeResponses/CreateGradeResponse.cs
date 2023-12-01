namespace Models.Responses.GradeResponses;

public class CreateGradeResponse
{
    public Guid Id { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
