using Provider;
using SS_WEB.Commands.Course.Interfaces;
using Models.Entitys;
using Models.Responses.CourseResponses;

namespace SS_WEB.Commands.Course;

public class GetAllCourseCommand : IGetAllCourseCommand
{
    private GetAllCourseResponse _response;
    private CourseRepository _repository;

    public GetAllCourseCommand(GetAllCourseResponse response, CourseRepository repository)
    {
        _response = response;
        _repository = repository;
    }

    public GetAllCourseResponse Execute()
    {
        var result = _repository.GetAll();

        foreach (var course in result)
        {
            CourseInfo courseInfo = new()
            {
                NameCourse = course.NameCourse,
                Credit = course.Credit,
            };

            _response.CoursesInfo.Add(courseInfo);
        }

        return _response;
    }
}
