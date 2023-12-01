using Models.Requests.Course;
using Models.Responses.CourseResponses;

namespace SS_WEB.Commands.Course.Interfaces;

public interface IEditCourseCommand
{
    public EditCourseResponse Execute(EditCourseRequest request);
}
