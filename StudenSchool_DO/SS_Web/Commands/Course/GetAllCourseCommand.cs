using Azure.Core;
using Provider;
using SS_Web.Commands.Course.Interfaces;
using SS_Web.Entitys;
using SS_Web.Responses.CourseResponses;
using SS_Web.Validators.Course.Interfaces;

namespace SS_Web.Commands.Course;

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
