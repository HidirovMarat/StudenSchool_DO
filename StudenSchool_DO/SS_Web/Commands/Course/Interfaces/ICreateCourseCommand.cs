using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace SS_WEB.Commands.Course.Interfaces;

public interface ICreateCourseCommand
{
    public CreateCourseResponse Execute(CreateCourseRequest request);
}
