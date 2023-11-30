﻿using SS_Web.Requests.Course;
using SS_Web.Responses.CourseResponses;

namespace SS_Web.Commands.Course.Interfaces;

public interface IDeleteCourseCommand
{
    public DeleteCourseResponse Execute(DeleteCourseRequest request);
}
