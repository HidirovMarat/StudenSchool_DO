using Models.Requests.Grade;
using Models.Responses.GradeResponses;

namespace SS_WEB.Commands.Grade.Interfaces;

public interface IGetGradeCommand
{
    public GetGradeResponse Execute(GetGradeRequest request);
}
