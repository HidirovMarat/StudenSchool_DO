using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class FileReaderController : Controller
{
    [HttpGet]
    public IActionResult Get([FromServices] IFileReaderActions fileReaderActions, int numberOfPages, string path)
    {
        return Ok(fileReaderActions.Get(numberOfPages, path));
    }
}
