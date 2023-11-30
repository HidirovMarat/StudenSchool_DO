using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;

namespace SS_Web.Commands.Grade.Interfaces;

public interface IGetGradeCommand
{
    public GetGradeResponse Execute(GetGradeRequest request);
}
