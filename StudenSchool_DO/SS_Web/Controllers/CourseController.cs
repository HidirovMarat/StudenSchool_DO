using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;
using SS_Web.Entitys;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class CourseController : Controller
{
    [HttpPost]
    public IActionResult Create([FromServices] ICourseActions courseActions, [FromBody] CourseInfo courseInfo)
    {
        var result = courseActions.Create(courseInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.CourseInfo.Id);
    }

    [HttpGet]
    public IActionResult Read([FromServices] ICourseActions courseActions, Guid id)
    {
        var result = courseActions.Read(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.CourseInfo);
    }

    [Route("ReadAll")]
    [HttpGet]
    public IActionResult ReadAll([FromServices] ICourseActions courseActions)
    {
        var result = courseActions.ReadAll();

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Edit([FromServices] ICourseActions courseActions, [FromBody] CourseInfo courseInfo)
    {
        var result = courseActions.Edit(courseInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.CourseInfo);
    }

    [HttpDelete]
    public IActionResult Delete([FromServices] ICourseActions courseActions, Guid id)
    {
        var result = courseActions.Delete(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.CourseInfo);
    }
}
