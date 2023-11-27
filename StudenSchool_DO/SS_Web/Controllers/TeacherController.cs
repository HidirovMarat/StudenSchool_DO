using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;
using SS_Web.Entitys;

namespace SS_Web.Controllers;

public class TeacherController : Controller
{
    [HttpPost]
    public IActionResult Create([FromServices] ITeacherActions teacherActions, [FromBody] TeacherInfo studentInfo)
    {
        var result = teacherActions.Create(studentInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.TeacherInfo.Id);
    }

    [HttpGet]
    public IActionResult Read([FromServices] ITeacherActions teacherActions, Guid id)
    {
        var result = teacherActions.Read(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.TeacherInfo);
    }

    [Route("ReadAll")]
    [HttpGet]
    public IActionResult ReadAll([FromServices] ITeacherActions teacherActions)
    {
        var result = teacherActions.ReadAll();

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Edit([FromServices] ITeacherActions teacherActions, [FromBody] TeacherInfo teacherInfo)
    {
        var result = teacherActions.Edit(teacherInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.TeacherInfo);
    }

    [HttpDelete]
    public IActionResult Delete([FromServices] ITeacherActions teacherActions, Guid id)
    {
        var result = teacherActions.Delete(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.TeacherInfo);
    }
}
