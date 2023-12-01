using Models.Responses.CourseResponses;

namespace SS_WEB.Commands.Course.Interfaces;

public interface IGetAllCourseCommand
{
    public GetAllCourseResponse Execute();
}
