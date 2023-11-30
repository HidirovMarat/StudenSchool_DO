using SS_Web.Responses.CourseResponses;

namespace SS_Web.Commands.Course.Interfaces;

public interface IGetAllCourseCommand
{
    public GetAllCourseResponse Execute();
}
