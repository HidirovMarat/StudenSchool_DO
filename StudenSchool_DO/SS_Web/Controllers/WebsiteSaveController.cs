using Microsoft.AspNetCore.Mvc;
using SS_Web.Actions.@base;
using SS_Web.Entitys;

namespace SS_Web.Controllers;

[Route("[controller]")]
public class WebsiteSaveController : Controller
{
    [HttpPost]
    public IActionResult Create([FromServices] IWebsiteSaveActions websiteSaveActions, [FromBody] WebsiteSaveInfo websiteSaveInfo)
    {
        return Ok(websiteSaveActions.Create(websiteSaveInfo));
    }
}
