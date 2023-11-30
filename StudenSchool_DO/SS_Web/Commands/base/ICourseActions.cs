using SS_Web.Entitys;
using SS_Web.Responses.CourseResponses;

namespace SS_Web.Actions.@base;

public interface ICourseActions
{
    public CreateCourseResponse Create(CourseInfo request);

    public GetAllCourseResponse ReadAll();

    public GetCourseResponse Read(Guid id);

    public EditCourseResponse Edit(Guid id, CourseInfo request);

    public DeleteCourseResponse Delete(Guid id);
}
