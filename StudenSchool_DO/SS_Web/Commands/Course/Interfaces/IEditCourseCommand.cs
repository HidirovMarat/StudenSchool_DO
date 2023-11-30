using SS_Web.Entitys;
using SS_Web.Requests.Course;
using SS_Web.Responses.CourseResponses;

namespace SS_Web.Commands.Course.Interfaces;

public interface IEditCourseCommand
{
    public EditCourseResponse Execute(EditCourseRequest request);
}
