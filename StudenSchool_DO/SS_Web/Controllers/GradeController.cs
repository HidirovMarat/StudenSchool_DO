using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;
using SS_Web.Entitys;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class GradeController : Controller
{
    [HttpPost]
    public IActionResult Create([FromServices] IGradeActions gradeActions, [FromBody] GradeInfo gradeInfo)
    {
        var result = gradeActions.Create(gradeInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok($"CourseId = {result.GradeInfo.CourseId}   StudentId = {result.GradeInfo.StudentId}" );
    }

    [HttpGet]
    public IActionResult Read([FromServices] IGradeActions gradeActions, Guid studetId, Guid courseId)
    {
        var result = gradeActions.Read(courseId, studetId);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.GradeInfo);
    }

    [Route("ReadAll")]
    [HttpGet]
    public IActionResult ReadAll([FromServices] IGradeActions gradeActions)
    {
        var result = gradeActions.ReadAll();

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Edit([FromServices] IGradeActions gradeActions, [FromBody] GradeInfo gradeInfo)
    {
        var result = gradeActions.Edit(gradeInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.GradeInfo);
    }

    [HttpDelete]
    public IActionResult Delete([FromServices] IGradeActions gradeActions, Guid studentId, Guid courseId)
    {
        var result = gradeActions.Delete(courseId, studentId);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.GradeInfo);
    }
}
