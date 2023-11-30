using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;

namespace SS_Web.Commands.Grade.Interfaces;

public interface IEditGradeCommand
{
    public EditGradeResponse Execute(EditGradeRequest request);
}
