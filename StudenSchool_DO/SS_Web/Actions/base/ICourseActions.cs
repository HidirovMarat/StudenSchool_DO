using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface ICourseActions
{
    public CreateCourseResponse Create(CourseInfo request);

    public IEnumerable<CourseInfo> ReadAll();

    public CreateCourseResponse Read(Guid id);

    public CreateCourseResponse Edit(CourseInfo request);

    public CreateCourseResponse Delete(Guid id);
}
