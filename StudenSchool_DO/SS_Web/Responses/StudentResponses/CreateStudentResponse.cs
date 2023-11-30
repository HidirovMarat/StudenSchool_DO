using SS_Web.Entitys;

namespace SS_Web.Responses.StudentResponses;

public class CreateStudentResponse
{
    public Guid Id { get; set; }

    public List<string> Erorrs { get; set; } = new();
}
