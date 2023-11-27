using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;
using SS_Web.Entitys;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class StudentController : Controller
{
    [HttpPost]
    public IActionResult Create([FromServices] IStudentActions studentActions, [FromBody] StudentInfo studentInfo)
    {
        var result = studentActions.Create(studentInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.StudentInfo.Id);
    }

    [HttpGet]
    public IActionResult Read([FromServices] IStudentActions studentActions, Guid id)
    {
        var result = studentActions.Read(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.StudentInfo);
    }

    [Route("ReadAll")]
    [HttpGet]
    public IActionResult ReadAll([FromServices] IStudentActions studentActions)
    {
        var result = studentActions.ReadAll();

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Edit([FromServices] IStudentActions studentActions, [FromBody] StudentInfo studentInfo)
    {
        var result = studentActions.Edit(studentInfo);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.StudentInfo);
    }

    [HttpDelete]
    public IActionResult Delete([FromServices] IStudentActions studentActions, Guid id)
    {
        var result = studentActions.Delete(id);

        if (result.Erorrs.Count != 0)
        {
            return BadRequest(result.Erorrs);
        }

        return Ok(result.StudentInfo);
    }
}
