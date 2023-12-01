using Models.Responses.GradeResponses;

namespace SS_WEB.Commands.Grade.Interfaces;

public interface IGetAllGradeCommand
{
    public GetAllGradeResponse Execute();
}
