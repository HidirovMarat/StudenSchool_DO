using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace SS_WEB.Commands.Course.Interfaces;

public interface IDeleteCourseCommand
{
    public DeleteCourseResponse Execute(DeleteCourseRequest request);
}
